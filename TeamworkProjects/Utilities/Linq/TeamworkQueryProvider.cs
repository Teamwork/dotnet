using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace TeamworkProjects.Utilities.Linq
{
    class TeamworkQueryProvider : IQueryProvider
    {
        /// <summary>
        /// refers to Teamwork Context
        /// </summary>
        public TeamworkProjectsContext Context { get; set; }

        /// <summary>
        /// Non-generic version, returns current query to 
        /// calling code as its constructing the query
        /// </summary>
        /// <param name="expression">Expression tree</param>
        /// <returns>IQueryable that can be executed</returns>
        public IQueryable CreateQuery(Expression expression)
        {
            Type elementType = TypeSystem.GetElementType(expression.Type);
            try
            {
                return (IQueryable)Activator.CreateInstance(
                    typeof(TeamworkQueryable<>)
                        .MakeGenericType(elementType),
                    new object[] { this, expression });
            }
            catch (TargetInvocationException tie)
            {
                throw tie.InnerException;
            }
        }

        /// <summary>
        /// generic version, returns current query to 
        /// calling code as its constructing the query
        /// </summary>
        /// <typeparam name="TResult">current object type being worked with</typeparam>
        /// <param name="expression">expression tree for query</param>
        /// <returns>IQueryable that can be executed</returns>
        public IQueryable<TResult> CreateQuery<TResult>(Expression expression)
        {
            return new TeamworkQueryable<TResult>(this, expression);
        }

        /// <summary>
        /// non-generic execute, delegates execution to TwitterContext
        /// </summary>
        /// <param name="expression">Expression Tree</param>
        /// <returns>list of results from query</returns>
        public object Execute(Expression expression)
        {
            Type elementType = TypeSystem.GetElementType(expression.Type);

            return GetType().GetTypeInfo()
                .DeclaredMethods.First(meth => meth.IsGenericMethod && meth.Name == "Execute")
                .Invoke(this, new object[] { expression });
        }

        /// <summary>
        /// generic execute, delegates execution to TwitterContext
        /// </summary>
        /// <typeparam name="TResult">type of query</typeparam>
        /// <param name="expression">Expression tree</param>
        /// <returns>list of results from query</returns>
        public TResult Execute<TResult>(Expression expression)
        {
            bool isEnumerable =
                typeof(TResult).Name == "IEnumerable`1" ||
                typeof(TResult).Name == "IEnumerable";

            Type resultType = new MethodCallExpressionTypeFinder().GetGenericType(expression);
            var genericArguments = new[] { resultType };

            var methodInfo = Context.GetType().GetTypeInfo().GetDeclaredMethod("ExecuteAsync");
            MethodInfo genericMethodInfo = methodInfo.MakeGenericMethod(genericArguments);

            try
            {
                var exeTask = Task.Run(() => (Task<object>)genericMethodInfo.Invoke(Context, new object[] { expression, isEnumerable }));
                return (TResult)exeTask.Result;
            }
            catch (TargetInvocationException tex)
            {
                // gotta unwrap the Invoke exception, as the the inner exception is the interesting bit...
                if (tex.InnerException != null)
                    throw tex.InnerException;
                throw;
            }
        }

        public async Task<object> ExecuteAsync<TResult>(Expression expression)
            where TResult : class
        {
            bool isEnumerable =
                typeof(TResult).Name == "IEnumerable`1" ||
                typeof(TResult).Name == "IEnumerable";

            Type resultType = new MethodCallExpressionTypeFinder().GetGenericType(expression);
            var genericArguments = new[] { resultType };

            var methodInfo = Context.GetType().GetTypeInfo().GetDeclaredMethod("ExecuteAsync");
            MethodInfo genericMethodInfo = methodInfo.MakeGenericMethod(genericArguments);

            try
            {
                var result = await ((Task<object>)genericMethodInfo.Invoke(Context, new object[] { expression, isEnumerable })).ConfigureAwait(false);
                return result;
            }
            catch (TargetInvocationException tex)
            {
                // gotta unwrap the Invoke exception, as the the inner exception is the interesting bit...
                if (tex.InnerException != null)
                    throw tex.InnerException;
                throw;
            }
        }
    }
}
