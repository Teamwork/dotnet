using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace TeamworkProjects.Utilities.Linq
{
    /// <summary>
    /// IQueryable of T
    /// </summary>
    /// <typeparam name="T">Type to operate on</typeparam>
    public class TeamworkQueryable<T> : IOrderedQueryable<T>
    {
        /// <summary>
        ///  Gets initiated with Teamwork Context
        /// </summary>
        /// <param name="context"></param>
        public TeamworkQueryable(TeamworkProjectsContext context)
        {
            Provider = new TeamworkQueryProvider();
            Expression = Expression.Constant(this);
            ((TeamworkQueryProvider) Provider).Context = context;
        }

        /// <param name="provider">IQueryProvider</param>
        /// <param name="expression">Expression Tree</param>
        internal TeamworkQueryable(
            TeamworkQueryProvider provider,
            Expression expression)
        {
            if (expression == null) throw new ArgumentNullException(nameof(expression));

            if (!typeof(IQueryable<T>).GetTypeInfo().IsAssignableFrom(expression.Type.GetTypeInfo()))
                throw new ArgumentOutOfRangeException(nameof(expression));

            Provider = provider ?? throw new ArgumentNullException(nameof(provider));
            Expression = expression;
        }

        public IQueryProvider Provider { get; }

        public Expression Expression { get; }

        public Type ElementType => typeof(T);

        public IEnumerator<T> GetEnumerator()
        {
            var tsk = Task.Run(() => ((TeamworkQueryProvider) Provider).ExecuteAsync<IEnumerable<T>>(Expression));
            return ((IEnumerable<T>) tsk.Result).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Provider.Execute<IEnumerable>(Expression).GetEnumerator();
        }
    }
}