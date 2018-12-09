using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TeamworkProjects.Utilities.Linq;

namespace TeamworkProjects.Utilities
{
    public static class TeamworkExtensions
    {
        public static async Task<List<T>> ToListAsync<T>(this IQueryable<T> query)
        {
            var provider = query.Provider as TeamworkQueryProvider;

            IEnumerable<T> results = (IEnumerable<T>)await provider.ExecuteAsync<IEnumerable<T>>(query.Expression).ConfigureAwait(false);

            return results.ToList();
        }

        public static async Task<T> FirstOrDefaultAsync<T>(this IQueryable<T> query)
            where T : class
        {
            var provider = query.Provider as TeamworkQueryProvider;

            IEnumerable<T> results = (IEnumerable<T>)await provider.ExecuteAsync<T>(query.Expression).ConfigureAwait(false);

            return results.FirstOrDefault();
        }

        public static async Task<T> FirstAsync<T>(this IQueryable<T> query)
            where T : class
        {
            var provider = query.Provider as TeamworkQueryProvider;

            IEnumerable<T> results = (IEnumerable<T>)await provider.ExecuteAsync<T>(query.Expression).ConfigureAwait(false);

            return results.First();
        }

        public static async Task<T> SingleOrDefaultAsync<T>(this IQueryable<T> query)
            where T : class
        {
            var provider = query.Provider as TeamworkQueryProvider;

            IEnumerable<T> results = (IEnumerable<T>)await provider.ExecuteAsync<T>(query.Expression).ConfigureAwait(false);

            return results.SingleOrDefault();
        }

        public static async Task<T> SingleAsync<T>(this IQueryable<T> query)
            where T : class
        {
            var provider = query.Provider as TeamworkQueryProvider;

            IEnumerable<T> results = (IEnumerable<T>)await provider.ExecuteAsync<T>(query.Expression).ConfigureAwait(false);

            return results.Single();
        }

        /// <summary>
        /// Enables use of .NET Cancellation Framework for this query.
        /// </summary>
        /// <param name="streaming">Query being extended</param>
        /// <param name="callback">Your code for handling Twitter content</param>
        /// <returns>Streaming instance to support further LINQ opertations</returns>
        public static IQueryable<T> WithCancellation<T>(this IQueryable<T> query, CancellationToken cancelToken)
            where T : class
        {
            var provider = query.Provider as TeamworkQueryProvider;
            provider
                .Context
                .Handler
                .CancellationToken = cancelToken;

            return query;
        }
    }
}
