using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Utility.Extensions
{
    public static class EnumerableExtensions
    {
        public static IOrderedEnumerable<TSource> OrderBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, bool desc)
        {
            return desc ? source.OrderByDescending(keySelector) : source.OrderBy(keySelector);
        }

        public static string Get(this Dictionary<string, string> source, string key)
        {
            return source.ToList().Where(x => string.Compare(x.Key, key, true) == 0).Select(x => x.Value).FirstOrDefault();
        }
    }
}
