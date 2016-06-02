using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Baseline;
using Baseline.Reflection;
using Marten.Linq;
using Marten.Schema;
using Marten.Services;

namespace Marten.Patching
{
    public class PatchExpression<T> : IPatchExpression<T>
    {
        private readonly IDocumentSchema _schema;
        public readonly IDictionary<string, object> Patch = new Dictionary<string, object>();

        public PatchExpression(IWhereFragment fragment, IDocumentSchema schema, IUnitOfWork unitOfWork)
        {
            _schema = schema;
        }

        private string toPath(Expression expression)
        {
            var visitor = new FindMembers();
            visitor.Visit(expression);

            return visitor.Members.Select(x => x.Name).Join(".");
        }

        public void Set<TValue>(Expression<Func<T, TValue>> expression, TValue value)
        {
            Patch.Add("type", "set");
            Patch.Add("value", value);
            Patch.Add("path", toPath(expression));
        }

        public void Increment(Expression<Func<T, int>> expression, int increment = 1)
        {
            Patch.Add("type", "increment");
            Patch.Add("increment", increment);
            Patch.Add("path", toPath(expression));
        }

        public void Increment(Expression<Func<T, long>> expression, long increment = 1)
        {
            Patch.Add("type", "increment");
            Patch.Add("increment", increment);
            Patch.Add("path", toPath(expression));
        }

        public void Increment(Expression<Func<T, double>> expression, double increment = 1)
        {
            Patch.Add("type", "increment_float");
            Patch.Add("increment", increment);
            Patch.Add("path", toPath(expression));
        }

        public void Increment(Expression<Func<T, float>> expression, float increment = 1)
        {
            Patch.Add("type", "increment_float");
            Patch.Add("increment", increment);
            Patch.Add("path", toPath(expression));
        }

        public void Append<TElement>(Expression<Func<T, IEnumerable<TElement>>> expression, TElement element)
        {
            Patch.Add("type", "append");
            Patch.Add("value", element);
            Patch.Add("path", toPath(expression));
        }

        public void Insert<TElement>(Expression<Func<T, IEnumerable<TElement>>> expression, TElement element,
            int index = 0)
        {
            Patch.Add("type", "insert");
            Patch.Add("value", element);
            Patch.Add("path", toPath(expression));
            Patch.Add("index", index);
        }

        public void Rename(string oldName, Expression<Func<T, object>> expression)
        {
            Patch.Add("type", "rename");

            var newPath = toPath(expression);
            var parts = newPath.Split('.');

            var to = parts.Last();
            parts[parts.Length - 1] = oldName;

            var path = parts.Join(".");

            Patch.Add("to", to);
            Patch.Add("path", path);
        }

        private void addPatch()
        {
            var transform = _schema.TransformFor(StoreOptions.PatchDoc);

        }
    }
}