using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace CESUT_NEWMODE.Toolkit.ConcurrentDic
{
    internal static class ConcurrentDic
    {
        public static ConcurrentDictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector)
        {
            var dictionary = new ConcurrentDictionary<TKey, TElement>();
            foreach (TSource local in source)
            {
                dictionary.TryAdd(keySelector(local), elementSelector(local));
            }
            return dictionary;
        }
    }
}
