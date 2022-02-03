// <auto-generated/>
#pragma warning disable
using Marten.Internal;
using Marten.Internal.Storage;
using Marten.Schema;
using Marten.Schema.Arguments;
using Marten.Testing.Bugs;
using Npgsql;
using System;
using System.Collections.Generic;
using Weasel.Core;
using Weasel.Postgresql;

namespace Marten.Generated.DocumentStorage
{
    // START: UpsertDocHolderOperation140118734
    public class UpsertDocHolderOperation140118734 : Marten.Internal.Operations.StorageOperation<Marten.Testing.Bugs.DocHolder, System.Guid>
    {
        private readonly Marten.Testing.Bugs.DocHolder _document;
        private readonly System.Guid _id;
        private readonly System.Collections.Generic.Dictionary<System.Guid, System.Guid> _versions;
        private readonly Marten.Schema.DocumentMapping _mapping;

        public UpsertDocHolderOperation140118734(Marten.Testing.Bugs.DocHolder document, System.Guid id, System.Collections.Generic.Dictionary<System.Guid, System.Guid> versions, Marten.Schema.DocumentMapping mapping) : base(document, id, versions, mapping)
        {
            _document = document;
            _id = id;
            _versions = versions;
            _mapping = mapping;
        }


        public const string COMMAND_TEXT = "select public.mt_upsert_docholder(?, ?, ?, ?)";


        public override string CommandText()
        {
            return COMMAND_TEXT;
        }


        public override NpgsqlTypes.NpgsqlDbType DbType()
        {
            return NpgsqlTypes.NpgsqlDbType.Uuid;
        }


        public override void ConfigureParameters(Npgsql.NpgsqlParameter[] parameters, Marten.Testing.Bugs.DocHolder document, Marten.Internal.IMartenSession session)
        {
            parameters[0].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Jsonb;
            parameters[0].Value = session.Serializer.ToJson(_document);
            // .Net Class Type
            parameters[1].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar;
            parameters[1].Value = _document.GetType().FullName;
            parameters[2].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Uuid;
            parameters[2].Value = document.Id;
            setVersionParameter(parameters[3]);
        }


        public override void Postprocess(System.Data.Common.DbDataReader reader, System.Collections.Generic.IList<System.Exception> exceptions)
        {
            storeVersion();
        }


        public override System.Threading.Tasks.Task PostprocessAsync(System.Data.Common.DbDataReader reader, System.Collections.Generic.IList<System.Exception> exceptions, System.Threading.CancellationToken token)
        {
            storeVersion();
            // Nothing
            return System.Threading.Tasks.Task.CompletedTask;
        }


        public override Marten.Internal.Operations.OperationRole Role()
        {
            return Marten.Internal.Operations.OperationRole.Upsert;
        }

    }

    // END: UpsertDocHolderOperation140118734
    
    
    // START: InsertDocHolderOperation140118734
    public class InsertDocHolderOperation140118734 : Marten.Internal.Operations.StorageOperation<Marten.Testing.Bugs.DocHolder, System.Guid>
    {
        private readonly Marten.Testing.Bugs.DocHolder _document;
        private readonly System.Guid _id;
        private readonly System.Collections.Generic.Dictionary<System.Guid, System.Guid> _versions;
        private readonly Marten.Schema.DocumentMapping _mapping;

        public InsertDocHolderOperation140118734(Marten.Testing.Bugs.DocHolder document, System.Guid id, System.Collections.Generic.Dictionary<System.Guid, System.Guid> versions, Marten.Schema.DocumentMapping mapping) : base(document, id, versions, mapping)
        {
            _document = document;
            _id = id;
            _versions = versions;
            _mapping = mapping;
        }


        public const string COMMAND_TEXT = "select public.mt_insert_docholder(?, ?, ?, ?)";


        public override string CommandText()
        {
            return COMMAND_TEXT;
        }


        public override NpgsqlTypes.NpgsqlDbType DbType()
        {
            return NpgsqlTypes.NpgsqlDbType.Uuid;
        }


        public override void ConfigureParameters(Npgsql.NpgsqlParameter[] parameters, Marten.Testing.Bugs.DocHolder document, Marten.Internal.IMartenSession session)
        {
            parameters[0].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Jsonb;
            parameters[0].Value = session.Serializer.ToJson(_document);
            // .Net Class Type
            parameters[1].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar;
            parameters[1].Value = _document.GetType().FullName;
            parameters[2].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Uuid;
            parameters[2].Value = document.Id;
            setVersionParameter(parameters[3]);
        }


        public override void Postprocess(System.Data.Common.DbDataReader reader, System.Collections.Generic.IList<System.Exception> exceptions)
        {
            storeVersion();
        }


        public override System.Threading.Tasks.Task PostprocessAsync(System.Data.Common.DbDataReader reader, System.Collections.Generic.IList<System.Exception> exceptions, System.Threading.CancellationToken token)
        {
            storeVersion();
            // Nothing
            return System.Threading.Tasks.Task.CompletedTask;
        }


        public override Marten.Internal.Operations.OperationRole Role()
        {
            return Marten.Internal.Operations.OperationRole.Insert;
        }

    }

    // END: InsertDocHolderOperation140118734
    
    
    // START: UpdateDocHolderOperation140118734
    public class UpdateDocHolderOperation140118734 : Marten.Internal.Operations.StorageOperation<Marten.Testing.Bugs.DocHolder, System.Guid>
    {
        private readonly Marten.Testing.Bugs.DocHolder _document;
        private readonly System.Guid _id;
        private readonly System.Collections.Generic.Dictionary<System.Guid, System.Guid> _versions;
        private readonly Marten.Schema.DocumentMapping _mapping;

        public UpdateDocHolderOperation140118734(Marten.Testing.Bugs.DocHolder document, System.Guid id, System.Collections.Generic.Dictionary<System.Guid, System.Guid> versions, Marten.Schema.DocumentMapping mapping) : base(document, id, versions, mapping)
        {
            _document = document;
            _id = id;
            _versions = versions;
            _mapping = mapping;
        }


        public const string COMMAND_TEXT = "select public.mt_update_docholder(?, ?, ?, ?)";


        public override string CommandText()
        {
            return COMMAND_TEXT;
        }


        public override NpgsqlTypes.NpgsqlDbType DbType()
        {
            return NpgsqlTypes.NpgsqlDbType.Uuid;
        }


        public override void ConfigureParameters(Npgsql.NpgsqlParameter[] parameters, Marten.Testing.Bugs.DocHolder document, Marten.Internal.IMartenSession session)
        {
            parameters[0].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Jsonb;
            parameters[0].Value = session.Serializer.ToJson(_document);
            // .Net Class Type
            parameters[1].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar;
            parameters[1].Value = _document.GetType().FullName;
            parameters[2].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Uuid;
            parameters[2].Value = document.Id;
            setVersionParameter(parameters[3]);
        }


        public override void Postprocess(System.Data.Common.DbDataReader reader, System.Collections.Generic.IList<System.Exception> exceptions)
        {
            storeVersion();
            postprocessUpdate(reader, exceptions);
        }


        public override async System.Threading.Tasks.Task PostprocessAsync(System.Data.Common.DbDataReader reader, System.Collections.Generic.IList<System.Exception> exceptions, System.Threading.CancellationToken token)
        {
            storeVersion();
            await postprocessUpdateAsync(reader, exceptions, token);
        }


        public override Marten.Internal.Operations.OperationRole Role()
        {
            return Marten.Internal.Operations.OperationRole.Update;
        }

    }

    // END: UpdateDocHolderOperation140118734
    
    
    // START: QueryOnlyDocHolderSelector140118734
    public class QueryOnlyDocHolderSelector140118734 : Marten.Internal.CodeGeneration.DocumentSelectorWithOnlySerializer, Marten.Linq.Selectors.ISelector<Marten.Testing.Bugs.DocHolder>
    {
        private readonly Marten.Internal.IMartenSession _session;
        private readonly Marten.Schema.DocumentMapping _mapping;

        public QueryOnlyDocHolderSelector140118734(Marten.Internal.IMartenSession session, Marten.Schema.DocumentMapping mapping) : base(session, mapping)
        {
            _session = session;
            _mapping = mapping;
        }



        public Marten.Testing.Bugs.DocHolder Resolve(System.Data.Common.DbDataReader reader)
        {

            Marten.Testing.Bugs.DocHolder document;
            document = _serializer.FromJson<Marten.Testing.Bugs.DocHolder>(reader, 0);
            return document;
        }


        public async System.Threading.Tasks.Task<Marten.Testing.Bugs.DocHolder> ResolveAsync(System.Data.Common.DbDataReader reader, System.Threading.CancellationToken token)
        {

            Marten.Testing.Bugs.DocHolder document;
            document = await _serializer.FromJsonAsync<Marten.Testing.Bugs.DocHolder>(reader, 0, token).ConfigureAwait(false);
            return document;
        }

    }

    // END: QueryOnlyDocHolderSelector140118734
    
    
    // START: LightweightDocHolderSelector140118734
    public class LightweightDocHolderSelector140118734 : Marten.Internal.CodeGeneration.DocumentSelectorWithVersions<Marten.Testing.Bugs.DocHolder, System.Guid>, Marten.Linq.Selectors.ISelector<Marten.Testing.Bugs.DocHolder>
    {
        private readonly Marten.Internal.IMartenSession _session;
        private readonly Marten.Schema.DocumentMapping _mapping;

        public LightweightDocHolderSelector140118734(Marten.Internal.IMartenSession session, Marten.Schema.DocumentMapping mapping) : base(session, mapping)
        {
            _session = session;
            _mapping = mapping;
        }



        public Marten.Testing.Bugs.DocHolder Resolve(System.Data.Common.DbDataReader reader)
        {
            var id = reader.GetFieldValue<System.Guid>(0);

            Marten.Testing.Bugs.DocHolder document;
            document = _serializer.FromJson<Marten.Testing.Bugs.DocHolder>(reader, 1);
            _session.MarkAsDocumentLoaded(id, document);
            return document;
        }


        public async System.Threading.Tasks.Task<Marten.Testing.Bugs.DocHolder> ResolveAsync(System.Data.Common.DbDataReader reader, System.Threading.CancellationToken token)
        {
            var id = await reader.GetFieldValueAsync<System.Guid>(0, token);

            Marten.Testing.Bugs.DocHolder document;
            document = await _serializer.FromJsonAsync<Marten.Testing.Bugs.DocHolder>(reader, 1, token).ConfigureAwait(false);
            _session.MarkAsDocumentLoaded(id, document);
            return document;
        }

    }

    // END: LightweightDocHolderSelector140118734
    
    
    // START: IdentityMapDocHolderSelector140118734
    public class IdentityMapDocHolderSelector140118734 : Marten.Internal.CodeGeneration.DocumentSelectorWithIdentityMap<Marten.Testing.Bugs.DocHolder, System.Guid>, Marten.Linq.Selectors.ISelector<Marten.Testing.Bugs.DocHolder>
    {
        private readonly Marten.Internal.IMartenSession _session;
        private readonly Marten.Schema.DocumentMapping _mapping;

        public IdentityMapDocHolderSelector140118734(Marten.Internal.IMartenSession session, Marten.Schema.DocumentMapping mapping) : base(session, mapping)
        {
            _session = session;
            _mapping = mapping;
        }



        public Marten.Testing.Bugs.DocHolder Resolve(System.Data.Common.DbDataReader reader)
        {
            var id = reader.GetFieldValue<System.Guid>(0);
            if (_identityMap.TryGetValue(id, out var existing)) return existing;

            Marten.Testing.Bugs.DocHolder document;
            document = _serializer.FromJson<Marten.Testing.Bugs.DocHolder>(reader, 1);
            _session.MarkAsDocumentLoaded(id, document);
            _identityMap[id] = document;
            return document;
        }


        public async System.Threading.Tasks.Task<Marten.Testing.Bugs.DocHolder> ResolveAsync(System.Data.Common.DbDataReader reader, System.Threading.CancellationToken token)
        {
            var id = await reader.GetFieldValueAsync<System.Guid>(0, token);
            if (_identityMap.TryGetValue(id, out var existing)) return existing;

            Marten.Testing.Bugs.DocHolder document;
            document = await _serializer.FromJsonAsync<Marten.Testing.Bugs.DocHolder>(reader, 1, token).ConfigureAwait(false);
            _session.MarkAsDocumentLoaded(id, document);
            _identityMap[id] = document;
            return document;
        }

    }

    // END: IdentityMapDocHolderSelector140118734
    
    
    // START: DirtyTrackingDocHolderSelector140118734
    public class DirtyTrackingDocHolderSelector140118734 : Marten.Internal.CodeGeneration.DocumentSelectorWithDirtyChecking<Marten.Testing.Bugs.DocHolder, System.Guid>, Marten.Linq.Selectors.ISelector<Marten.Testing.Bugs.DocHolder>
    {
        private readonly Marten.Internal.IMartenSession _session;
        private readonly Marten.Schema.DocumentMapping _mapping;

        public DirtyTrackingDocHolderSelector140118734(Marten.Internal.IMartenSession session, Marten.Schema.DocumentMapping mapping) : base(session, mapping)
        {
            _session = session;
            _mapping = mapping;
        }



        public Marten.Testing.Bugs.DocHolder Resolve(System.Data.Common.DbDataReader reader)
        {
            var id = reader.GetFieldValue<System.Guid>(0);
            if (_identityMap.TryGetValue(id, out var existing)) return existing;

            Marten.Testing.Bugs.DocHolder document;
            document = _serializer.FromJson<Marten.Testing.Bugs.DocHolder>(reader, 1);
            _session.MarkAsDocumentLoaded(id, document);
            _identityMap[id] = document;
            StoreTracker(_session, document);
            return document;
        }


        public async System.Threading.Tasks.Task<Marten.Testing.Bugs.DocHolder> ResolveAsync(System.Data.Common.DbDataReader reader, System.Threading.CancellationToken token)
        {
            var id = await reader.GetFieldValueAsync<System.Guid>(0, token);
            if (_identityMap.TryGetValue(id, out var existing)) return existing;

            Marten.Testing.Bugs.DocHolder document;
            document = await _serializer.FromJsonAsync<Marten.Testing.Bugs.DocHolder>(reader, 1, token).ConfigureAwait(false);
            _session.MarkAsDocumentLoaded(id, document);
            _identityMap[id] = document;
            StoreTracker(_session, document);
            return document;
        }

    }

    // END: DirtyTrackingDocHolderSelector140118734
    
    
    // START: QueryOnlyDocHolderDocumentStorage140118734
    public class QueryOnlyDocHolderDocumentStorage140118734 : Marten.Internal.Storage.QueryOnlyDocumentStorage<Marten.Testing.Bugs.DocHolder, System.Guid>
    {
        private readonly Marten.Schema.DocumentMapping _document;

        public QueryOnlyDocHolderDocumentStorage140118734(Marten.Schema.DocumentMapping document) : base(document)
        {
            _document = document;
        }



        public override System.Guid AssignIdentity(Marten.Testing.Bugs.DocHolder document, string tenantId, Marten.Storage.IMartenDatabase database)
        {
            if (document.Id == Guid.Empty) _setter(document, Marten.Schema.Identity.CombGuidIdGeneration.NewGuid());
            return document.Id;
        }


        public override Marten.Internal.Operations.IStorageOperation Update(Marten.Testing.Bugs.DocHolder document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpdateDocHolderOperation140118734
            (
                document, Identity(document),
                session.Versions.ForType<Marten.Testing.Bugs.DocHolder, System.Guid>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Insert(Marten.Testing.Bugs.DocHolder document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.InsertDocHolderOperation140118734
            (
                document, Identity(document),
                session.Versions.ForType<Marten.Testing.Bugs.DocHolder, System.Guid>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Upsert(Marten.Testing.Bugs.DocHolder document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpsertDocHolderOperation140118734
            (
                document, Identity(document),
                session.Versions.ForType<Marten.Testing.Bugs.DocHolder, System.Guid>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Overwrite(Marten.Testing.Bugs.DocHolder document, Marten.Internal.IMartenSession session, string tenant)
        {
            throw new System.NotSupportedException();
        }


        public override System.Guid Identity(Marten.Testing.Bugs.DocHolder document)
        {
            return document.Id;
        }


        public override Marten.Linq.Selectors.ISelector BuildSelector(Marten.Internal.IMartenSession session)
        {
            return new Marten.Generated.DocumentStorage.QueryOnlyDocHolderSelector140118734(session, _document);
        }


        public override Npgsql.NpgsqlCommand BuildLoadCommand(System.Guid id, string tenant)
        {
            return new NpgsqlCommand(_loaderSql).With("id", id);
        }


        public override Npgsql.NpgsqlCommand BuildLoadManyCommand(System.Guid[] ids, string tenant)
        {
            return new NpgsqlCommand(_loadArraySql).With("ids", ids);
        }

    }

    // END: QueryOnlyDocHolderDocumentStorage140118734
    
    
    // START: LightweightDocHolderDocumentStorage140118734
    public class LightweightDocHolderDocumentStorage140118734 : Marten.Internal.Storage.LightweightDocumentStorage<Marten.Testing.Bugs.DocHolder, System.Guid>
    {
        private readonly Marten.Schema.DocumentMapping _document;

        public LightweightDocHolderDocumentStorage140118734(Marten.Schema.DocumentMapping document) : base(document)
        {
            _document = document;
        }



        public override System.Guid AssignIdentity(Marten.Testing.Bugs.DocHolder document, string tenantId, Marten.Storage.IMartenDatabase database)
        {
            if (document.Id == Guid.Empty) _setter(document, Marten.Schema.Identity.CombGuidIdGeneration.NewGuid());
            return document.Id;
        }


        public override Marten.Internal.Operations.IStorageOperation Update(Marten.Testing.Bugs.DocHolder document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpdateDocHolderOperation140118734
            (
                document, Identity(document),
                session.Versions.ForType<Marten.Testing.Bugs.DocHolder, System.Guid>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Insert(Marten.Testing.Bugs.DocHolder document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.InsertDocHolderOperation140118734
            (
                document, Identity(document),
                session.Versions.ForType<Marten.Testing.Bugs.DocHolder, System.Guid>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Upsert(Marten.Testing.Bugs.DocHolder document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpsertDocHolderOperation140118734
            (
                document, Identity(document),
                session.Versions.ForType<Marten.Testing.Bugs.DocHolder, System.Guid>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Overwrite(Marten.Testing.Bugs.DocHolder document, Marten.Internal.IMartenSession session, string tenant)
        {
            throw new System.NotSupportedException();
        }


        public override System.Guid Identity(Marten.Testing.Bugs.DocHolder document)
        {
            return document.Id;
        }


        public override Marten.Linq.Selectors.ISelector BuildSelector(Marten.Internal.IMartenSession session)
        {
            return new Marten.Generated.DocumentStorage.LightweightDocHolderSelector140118734(session, _document);
        }


        public override Npgsql.NpgsqlCommand BuildLoadCommand(System.Guid id, string tenant)
        {
            return new NpgsqlCommand(_loaderSql).With("id", id);
        }


        public override Npgsql.NpgsqlCommand BuildLoadManyCommand(System.Guid[] ids, string tenant)
        {
            return new NpgsqlCommand(_loadArraySql).With("ids", ids);
        }

    }

    // END: LightweightDocHolderDocumentStorage140118734
    
    
    // START: IdentityMapDocHolderDocumentStorage140118734
    public class IdentityMapDocHolderDocumentStorage140118734 : Marten.Internal.Storage.IdentityMapDocumentStorage<Marten.Testing.Bugs.DocHolder, System.Guid>
    {
        private readonly Marten.Schema.DocumentMapping _document;

        public IdentityMapDocHolderDocumentStorage140118734(Marten.Schema.DocumentMapping document) : base(document)
        {
            _document = document;
        }



        public override System.Guid AssignIdentity(Marten.Testing.Bugs.DocHolder document, string tenantId, Marten.Storage.IMartenDatabase database)
        {
            if (document.Id == Guid.Empty) _setter(document, Marten.Schema.Identity.CombGuidIdGeneration.NewGuid());
            return document.Id;
        }


        public override Marten.Internal.Operations.IStorageOperation Update(Marten.Testing.Bugs.DocHolder document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpdateDocHolderOperation140118734
            (
                document, Identity(document),
                session.Versions.ForType<Marten.Testing.Bugs.DocHolder, System.Guid>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Insert(Marten.Testing.Bugs.DocHolder document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.InsertDocHolderOperation140118734
            (
                document, Identity(document),
                session.Versions.ForType<Marten.Testing.Bugs.DocHolder, System.Guid>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Upsert(Marten.Testing.Bugs.DocHolder document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpsertDocHolderOperation140118734
            (
                document, Identity(document),
                session.Versions.ForType<Marten.Testing.Bugs.DocHolder, System.Guid>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Overwrite(Marten.Testing.Bugs.DocHolder document, Marten.Internal.IMartenSession session, string tenant)
        {
            throw new System.NotSupportedException();
        }


        public override System.Guid Identity(Marten.Testing.Bugs.DocHolder document)
        {
            return document.Id;
        }


        public override Marten.Linq.Selectors.ISelector BuildSelector(Marten.Internal.IMartenSession session)
        {
            return new Marten.Generated.DocumentStorage.IdentityMapDocHolderSelector140118734(session, _document);
        }


        public override Npgsql.NpgsqlCommand BuildLoadCommand(System.Guid id, string tenant)
        {
            return new NpgsqlCommand(_loaderSql).With("id", id);
        }


        public override Npgsql.NpgsqlCommand BuildLoadManyCommand(System.Guid[] ids, string tenant)
        {
            return new NpgsqlCommand(_loadArraySql).With("ids", ids);
        }

    }

    // END: IdentityMapDocHolderDocumentStorage140118734
    
    
    // START: DirtyTrackingDocHolderDocumentStorage140118734
    public class DirtyTrackingDocHolderDocumentStorage140118734 : Marten.Internal.Storage.DirtyCheckedDocumentStorage<Marten.Testing.Bugs.DocHolder, System.Guid>
    {
        private readonly Marten.Schema.DocumentMapping _document;

        public DirtyTrackingDocHolderDocumentStorage140118734(Marten.Schema.DocumentMapping document) : base(document)
        {
            _document = document;
        }



        public override System.Guid AssignIdentity(Marten.Testing.Bugs.DocHolder document, string tenantId, Marten.Storage.IMartenDatabase database)
        {
            if (document.Id == Guid.Empty) _setter(document, Marten.Schema.Identity.CombGuidIdGeneration.NewGuid());
            return document.Id;
        }


        public override Marten.Internal.Operations.IStorageOperation Update(Marten.Testing.Bugs.DocHolder document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpdateDocHolderOperation140118734
            (
                document, Identity(document),
                session.Versions.ForType<Marten.Testing.Bugs.DocHolder, System.Guid>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Insert(Marten.Testing.Bugs.DocHolder document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.InsertDocHolderOperation140118734
            (
                document, Identity(document),
                session.Versions.ForType<Marten.Testing.Bugs.DocHolder, System.Guid>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Upsert(Marten.Testing.Bugs.DocHolder document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpsertDocHolderOperation140118734
            (
                document, Identity(document),
                session.Versions.ForType<Marten.Testing.Bugs.DocHolder, System.Guid>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Overwrite(Marten.Testing.Bugs.DocHolder document, Marten.Internal.IMartenSession session, string tenant)
        {
            throw new System.NotSupportedException();
        }


        public override System.Guid Identity(Marten.Testing.Bugs.DocHolder document)
        {
            return document.Id;
        }


        public override Marten.Linq.Selectors.ISelector BuildSelector(Marten.Internal.IMartenSession session)
        {
            return new Marten.Generated.DocumentStorage.DirtyTrackingDocHolderSelector140118734(session, _document);
        }


        public override Npgsql.NpgsqlCommand BuildLoadCommand(System.Guid id, string tenant)
        {
            return new NpgsqlCommand(_loaderSql).With("id", id);
        }


        public override Npgsql.NpgsqlCommand BuildLoadManyCommand(System.Guid[] ids, string tenant)
        {
            return new NpgsqlCommand(_loadArraySql).With("ids", ids);
        }

    }

    // END: DirtyTrackingDocHolderDocumentStorage140118734
    
    
    // START: DocHolderBulkLoader140118734
    public class DocHolderBulkLoader140118734 : Marten.Internal.CodeGeneration.BulkLoader<Marten.Testing.Bugs.DocHolder, System.Guid>
    {
        private readonly Marten.Internal.Storage.IDocumentStorage<Marten.Testing.Bugs.DocHolder, System.Guid> _storage;

        public DocHolderBulkLoader140118734(Marten.Internal.Storage.IDocumentStorage<Marten.Testing.Bugs.DocHolder, System.Guid> storage) : base(storage)
        {
            _storage = storage;
        }


        public const string MAIN_LOADER_SQL = "COPY public.mt_doc_docholder(\"mt_dotnet_type\", \"id\", \"mt_version\", \"data\") FROM STDIN BINARY";

        public const string TEMP_LOADER_SQL = "COPY mt_doc_docholder_temp(\"mt_dotnet_type\", \"id\", \"mt_version\", \"data\") FROM STDIN BINARY";

        public const string COPY_NEW_DOCUMENTS_SQL = "insert into public.mt_doc_docholder (\"id\", \"data\", \"mt_version\", \"mt_dotnet_type\", mt_last_modified) (select mt_doc_docholder_temp.\"id\", mt_doc_docholder_temp.\"data\", mt_doc_docholder_temp.\"mt_version\", mt_doc_docholder_temp.\"mt_dotnet_type\", transaction_timestamp() from mt_doc_docholder_temp left join public.mt_doc_docholder on mt_doc_docholder_temp.id = public.mt_doc_docholder.id where public.mt_doc_docholder.id is null)";

        public const string OVERWRITE_SQL = "update public.mt_doc_docholder target SET data = source.data, mt_version = source.mt_version, mt_dotnet_type = source.mt_dotnet_type, mt_last_modified = transaction_timestamp() FROM mt_doc_docholder_temp source WHERE source.id = target.id";

        public const string CREATE_TEMP_TABLE_FOR_COPYING_SQL = "create temporary table mt_doc_docholder_temp as select * from public.mt_doc_docholder limit 0";


        public override void LoadRow(Npgsql.NpgsqlBinaryImporter writer, Marten.Testing.Bugs.DocHolder document, Marten.Storage.Tenant tenant, Marten.ISerializer serializer)
        {
            writer.Write(document.GetType().FullName, NpgsqlTypes.NpgsqlDbType.Varchar);
            writer.Write(document.Id, NpgsqlTypes.NpgsqlDbType.Uuid);
            writer.Write(Marten.Schema.Identity.CombGuidIdGeneration.NewGuid(), NpgsqlTypes.NpgsqlDbType.Uuid);
            writer.Write(serializer.ToJson(document), NpgsqlTypes.NpgsqlDbType.Jsonb);
        }


        public override async System.Threading.Tasks.Task LoadRowAsync(Npgsql.NpgsqlBinaryImporter writer, Marten.Testing.Bugs.DocHolder document, Marten.Storage.Tenant tenant, Marten.ISerializer serializer, System.Threading.CancellationToken cancellation)
        {
            await writer.WriteAsync(document.GetType().FullName, NpgsqlTypes.NpgsqlDbType.Varchar, cancellation);
            await writer.WriteAsync(document.Id, NpgsqlTypes.NpgsqlDbType.Uuid, cancellation);
            await writer.WriteAsync(Marten.Schema.Identity.CombGuidIdGeneration.NewGuid(), NpgsqlTypes.NpgsqlDbType.Uuid, cancellation);
            await writer.WriteAsync(serializer.ToJson(document), NpgsqlTypes.NpgsqlDbType.Jsonb, cancellation);
        }


        public override string MainLoaderSql()
        {
            return MAIN_LOADER_SQL;
        }


        public override string TempLoaderSql()
        {
            return TEMP_LOADER_SQL;
        }


        public override string CreateTempTableForCopying()
        {
            return CREATE_TEMP_TABLE_FOR_COPYING_SQL;
        }


        public override string CopyNewDocumentsFromTempTable()
        {
            return COPY_NEW_DOCUMENTS_SQL;
        }


        public override string OverwriteDuplicatesFromTempTable()
        {
            return OVERWRITE_SQL;
        }

    }

    // END: DocHolderBulkLoader140118734
    
    
    // START: DocHolderProvider140118734
    public class DocHolderProvider140118734 : Marten.Internal.Storage.DocumentProvider<Marten.Testing.Bugs.DocHolder>
    {
        private readonly Marten.Schema.DocumentMapping _mapping;

        public DocHolderProvider140118734(Marten.Schema.DocumentMapping mapping) : base(new DocHolderBulkLoader140118734(new QueryOnlyDocHolderDocumentStorage140118734(mapping)), new QueryOnlyDocHolderDocumentStorage140118734(mapping), new LightweightDocHolderDocumentStorage140118734(mapping), new IdentityMapDocHolderDocumentStorage140118734(mapping), new DirtyTrackingDocHolderDocumentStorage140118734(mapping))
        {
            _mapping = mapping;
        }


    }

    // END: DocHolderProvider140118734
    
    
}
