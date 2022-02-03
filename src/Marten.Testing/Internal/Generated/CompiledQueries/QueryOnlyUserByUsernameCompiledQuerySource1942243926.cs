// <auto-generated/>
#pragma warning disable
using Marten.Internal.CompiledQueries;
using Marten.Linq;
using Marten.Linq.QueryHandlers;
using Marten.Testing.Linq.Compiled;
using System;

namespace Marten.Generated.CompiledQueries
{
    // START: QueryOnlyUserByUsernameCompiledQuery1942243926
    public class QueryOnlyUserByUsernameCompiledQuery1942243926 : Marten.Internal.CompiledQueries.ClonedCompiledQuery<Marten.Testing.Documents.User, Marten.Testing.Linq.Compiled.UserByUsername>
    {
        private readonly Marten.Linq.QueryHandlers.IMaybeStatefulHandler _inner;
        private readonly Marten.Testing.Linq.Compiled.UserByUsername _query;
        private readonly Marten.Linq.QueryStatistics _statistics;
        private readonly Marten.Internal.CompiledQueries.HardCodedParameters _hardcoded;

        public QueryOnlyUserByUsernameCompiledQuery1942243926(Marten.Linq.QueryHandlers.IMaybeStatefulHandler inner, Marten.Testing.Linq.Compiled.UserByUsername query, Marten.Linq.QueryStatistics statistics, Marten.Internal.CompiledQueries.HardCodedParameters hardcoded) : base(inner, query, statistics, hardcoded)
        {
            _inner = inner;
            _query = query;
            _statistics = statistics;
            _hardcoded = hardcoded;
        }



        public override void ConfigureCommand(Weasel.Postgresql.CommandBuilder builder, Marten.Internal.IMartenSession session)
        {
            var parameters = builder.AppendWithParameters(@"select d.data from public.mt_doc_user as d where d.data ->> 'UserName' = ? LIMIT ?");

            parameters[0].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Text;
            parameters[0].Value = _query.UserName;
            _hardcoded.Apply(parameters);
        }

    }

    // END: QueryOnlyUserByUsernameCompiledQuery1942243926
    
    
    // START: QueryOnlyUserByUsernameCompiledQuerySource1942243926
    public class QueryOnlyUserByUsernameCompiledQuerySource1942243926 : Marten.Internal.CompiledQueries.CompiledQuerySource<Marten.Testing.Documents.User, Marten.Testing.Linq.Compiled.UserByUsername>
    {
        private readonly Marten.Internal.CompiledQueries.HardCodedParameters _hardcoded;
        private readonly Marten.Linq.QueryHandlers.IMaybeStatefulHandler _maybeStatefulHandler;

        public QueryOnlyUserByUsernameCompiledQuerySource1942243926(Marten.Internal.CompiledQueries.HardCodedParameters hardcoded, Marten.Linq.QueryHandlers.IMaybeStatefulHandler maybeStatefulHandler)
        {
            _hardcoded = hardcoded;
            _maybeStatefulHandler = maybeStatefulHandler;
        }



        public override Marten.Linq.QueryHandlers.IQueryHandler<Marten.Testing.Documents.User> BuildHandler(Marten.Testing.Linq.Compiled.UserByUsername query, Marten.Internal.IMartenSession session)
        {
            return new Marten.Generated.CompiledQueries.QueryOnlyUserByUsernameCompiledQuery1942243926(_maybeStatefulHandler, query, null, _hardcoded);
        }

    }

    // END: QueryOnlyUserByUsernameCompiledQuerySource1942243926
    
    
}
