using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using FubuCore;
using FubuCore.Reflection;
using Marten.Generation;
using Marten.Util;

namespace Marten.Schema
{
    public class DuplicatedField
    {
        public static DuplicatedField For<T>(Expression<Func<T, object>> expression)
        {
            var accessor = ReflectionHelper.GetAccessor(expression);

            // Hokey, but it's just for testing for now.
            if (accessor is PropertyChain)
            {
                throw new NotSupportedException("Not yet supporting deep properties yet. Soon.");
            }


            return new DuplicatedField(new MemberInfo[] {accessor.InnerProperty});

            
        }

        public DuplicatedField(MemberInfo[] memberPath)
        {
            MemberPath = memberPath;
            ColumnName = MemberPath.Select(x => x.Name).Join("").SplitPascalCase().ToLower().Replace(" ", "_");
        }

        /// <summary>
        ///     Because this could be a deeply nested property and maybe even an
        ///     indexer? Or change to MemberInfo[] instead.
        /// </summary>
        public MemberInfo[] MemberPath { get; private set; }

        public string ColumnName { get; set; }

        public DuplicatedFieldRole Role { get; set; } = DuplicatedFieldRole.Search;

        public UpsertArgument UpsertArgument
        {
            get
            {
                return new UpsertArgument
                {
                    Arg = "arg_" + ColumnName.ToLower(),
                    Column = ColumnName.ToLower(),
                    PostgresType = TypeMappings.PgTypes[MemberPath.Last().GetMemberType()]
                };
            }
        }

        // I say you don't need a ForeignKey 
        public virtual TableColumn ToColumn(IDocumentSchema schema)
        {
            return new TableColumn(ColumnName, TypeMappings.PgTypes[MemberPath.Last().GetMemberType()]);
        }
    }
}