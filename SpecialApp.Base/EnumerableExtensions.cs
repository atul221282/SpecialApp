using SpecialApp.Entity.CommonContract;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;

namespace SpecialApp.Base
{
    public static class EnumerableExtensions
    {
        public static T WithMinimum<T, TKey>(this IEnumerable<T> sequence, Func<T, TKey> criterion)
            where T : class where TKey : IComparable<TKey> => sequence
            .Select(obj => Tuple.Create(obj, criterion(obj)))
            .Aggregate((Tuple<T, TKey>)null,
                (best, cur) => best == null || cur.Item2.CompareTo(best.Item2) < 0 ? cur : best)
            .Item1;

        public static TOut Do<TOut, T>(this IEnumerable<T> sequence, Func<T, TOut> action) where TOut : new()
        {
            foreach (T seq in sequence)
            {
                var ts = action(seq);
                return ts;
            }
            return new TOut();
        }

        public static IQueryable<T> GetActive<T>(this IQueryable<T> sequence) where T : IActiveOnlyEntity
        {
            return sequence.Where(x => x.IsDeleted == false);
        }
        //sequence.Aggregate((T)null, (best, current) =>
        //best == null || criterion(current).CompareTo(criterion(best)) < 0 ? current : best);

        public static IEnumerable<U> FindDuplicates<T, U>(this IEnumerable<T> list, Func<T, U> keySelector)
        {
            return list.GroupBy(keySelector)
                .Where(group => group.Count() > 1)
                .Select(group => group.Key).ToList();
        }
    }
}
