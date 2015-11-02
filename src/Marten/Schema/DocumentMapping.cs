﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using FubuCore;
using Marten.Codegen;
using Marten.Generation;
using Marten.Util;

namespace Marten.Schema
{
    public class DocumentMapping
    {
        public readonly IList<DuplicatedField> DuplicatedFields = new List<DuplicatedField>();

        public DocumentMapping(Type documentType)
        {
            DocumentType = documentType;

            IdMember = (MemberInfo) documentType.GetProperties().FirstOrDefault(x => x.Name.EqualsIgnoreCase("id"))
                       ?? documentType.GetFields().FirstOrDefault(x => x.Name.EqualsIgnoreCase("id"));

            TableName = TableNameFor(documentType);

            UpsertName = UpsertNameFor(documentType);
        }

        public string UpsertName { get; }

        public Type DocumentType { get; }

        public string TableName { get; set; }

        public MemberInfo IdMember { get; set; }

        // LATER?
        public IdStrategy IdStrategy { get; set; }

        public static string TableNameFor(Type documentType)
        {
            return "mt_doc_" + documentType.Name.ToLower();
        }

        public static string UpsertNameFor(Type documentType)
        {
            return "mt_upsert_" + documentType.Name.ToLower();
        }

        public TableDefinition ToTable(IDocumentSchema schema) // take in schema so that you
            // can do foreign keys
        {
            // TODO -- blow up if no IdMember or no TableName

            var pgIdType = TypeMappings.PgTypes[IdMember.GetMemberType()];
            var table = new TableDefinition(TableName, new TableColumn("id", pgIdType));
            table.Columns.Add(new TableColumn("data", "jsonb NOT NULL"));

            DuplicatedFields.Select(x => x.ToColumn(schema)).Each(x => table.Columns.Add(x));


            return table;
        }

        public void WriteSchemaObjects(IDocumentSchema schema, StringWriter writer)
        {
            var table = ToTable(schema);
            table.Write(writer);
            writer.WriteLine();
            writer.WriteLine();

            var pgIdType = TypeMappings.PgTypes[IdMember.GetMemberType()];

            var args = new List<UpsertArgument>
            {
                new UpsertArgument {Arg = "docId", PostgresType = pgIdType},
                new UpsertArgument {Arg = "doc", PostgresType = "JSON"}
            };

            var duplicates = DuplicatedFields.Select(x => x.UpsertArgument).ToArray();
            args.AddRange(duplicates);

            var argList = args.Select(x => x.ArgumentDeclaration()).Join(", ");
            var valueList = args.Select(x => x.Arg).Join(", ");

            var updates = "data = doc";
            if (duplicates.Any())
            {
                updates += ", " + duplicates.Select(x => $"{x.Column} = {x.Arg}").Join(", ");
            }


            writer.WriteLine($"CREATE OR REPLACE FUNCTION {UpsertName}({argList}) RETURNS VOID AS");
            writer.WriteLine("$$");
            writer.WriteLine("BEGIN");
            writer.WriteLine($"INSERT INTO {TableName} VALUES ({valueList})");
            writer.WriteLine($"  ON CONFLICT ON CONSTRAINT pk_{TableName}");
            writer.WriteLine($"  DO UPDATE SET {updates};");
            writer.WriteLine("END;");
            writer.WriteLine("$$ LANGUAGE plpgsql;");


            writer.WriteLine();
            writer.WriteLine();
        }

        public void GenerateDocumentStorage(SourceWriter writer)
        {
            writer.Write(
                $@"
BLOCK:public class {DocumentType.Name
                    }Storage : IDocumentStorage
public Type DocumentType => typeof ({DocumentType.Name
                    });

public string TableName {{ get; }} = `{TableName
                    }`;

BLOCK:public NpgsqlCommand UpsertCommand(object document, string json)
return UpsertCommand(({
                    DocumentType.Name
                    })document, json);
END

BLOCK:public NpgsqlCommand LoaderCommand(object id)
return new NpgsqlCommand(`select data from {
                    TableName
                    } where id = :id`).WithParameter(`id`, id);
END

BLOCK:public NpgsqlCommand DeleteCommandForId(object id)
return new NpgsqlCommand(`delete from {
                    TableName
                    } where id = :id`).WithParameter(`id`, id);
END

BLOCK:public NpgsqlCommand DeleteCommandForEntity(object entity)
return DeleteCommandForId((({
                    DocumentType.Name})entity).{IdMember.Name
                    });
END

BLOCK:public NpgsqlCommand LoadByArrayCommand<T>(T[] ids)
return new NpgsqlCommand(`select data from {
                    TableName
                    } where id = ANY(:ids)`).WithParameter(`ids`, ids);
END

BLOCK:public NpgsqlCommand AnyCommand(QueryModel queryModel)
return new DocumentQuery<{
                    DocumentType.Name}>(`{TableName
                    }`, queryModel).ToAnyCommand();
END

BLOCK:public NpgsqlCommand CountCommand(QueryModel queryModel)
return new DocumentQuery<{
                    DocumentType.Name}>(`{TableName
                    }`, queryModel).ToCountCommand();
END

// TODO: This wil need to get fancier later
BLOCK:public NpgsqlCommand UpsertCommand({
                    DocumentType.Name} document, string json)
return new NpgsqlCommand(`{UpsertName
                    }`)
    .AsSproc()
    .WithParameter(`id`, document.{IdMember.Name
                    })
    .WithJsonParameter(`doc`, json);
END

END

");
        }

        public static DocumentMapping For<T>()
        {
            return new DocumentMapping(typeof (T));
        }
    }

    // There would be others for sequences and hilo, etc.
    public interface IdStrategy
    {
    }

    public class AssignGuid : IdStrategy
    {
    }

    public enum DuplicatedFieldRole
    {
        Search,
        ForeignKey
    }

    public class UpsertArgument
    {
        public string Arg { get; set; }
        public string PostgresType { get; set; }

        public string Column { get; set; }

        public string ArgumentDeclaration()
        {
            return $"{Arg} {PostgresType}";
        }
    }
}