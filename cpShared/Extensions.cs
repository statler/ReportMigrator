using cpShared.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace cpShared.Extensions
{
    public static class Extensions
    {
        public static string RemoveHTMLFontInfo(this string s)
        {
            var regFont = new Regex(@"font-size\s*:\s*\d*[a-zA-Z]*");
            var famReplace = regFont.Replace(s, "");
            var regFamily = new Regex(@"font-family\s*:\s*\d*[a-zA-Z]*");
            return regFamily.Replace(famReplace, "");
        }

        public static string substringOrDefault(this string s, int start, int length)
        {
            int stringLength = s.Length;
            int fetchLength = Math.Min(length, stringLength - start);
            return s.Substring(start, fetchLength);
        }

        public static IEnumerable<T> GetValues<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }

        public static int ToInteger(this string s)
        {
            int integerValue = 0;
            int.TryParse(s, out integerValue);
            return integerValue;
        }

        public static bool IsInteger(this string s)
        {
            Regex regularExpression = new Regex("^-[0-9]+$|^[0-9]+$");
            return regularExpression.Match(s).Success;
        }

        public static DateTime GetFirstDayOfMonth(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, 1);
        }

        public static DateTime GetLastDayOfMonth(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, DateTime.DaysInMonth(dateTime.Year, dateTime.Month));
        }

        public static DateTime GetEndOfLastDayOfMonth(this DateTime dateTime)
        {
            var lastDay = new DateTime(dateTime.Year, dateTime.Month, DateTime.DaysInMonth(dateTime.Year, dateTime.Month));
            return lastDay.Date.AddDays(1).AddTicks(-1);
        }

        public static DateTime GetEndOfDay(this DateTime dateTime)
        {
            return dateTime.Date.AddDays(1).AddTicks(-1);
        }

        public static string GetSafeFilename(this string filename)
        {
            return string.Join("_", filename.Split(Path.GetInvalidFileNameChars()));
        }

        public static IEnumerable<T> Distinct<T, TKey>(this IEnumerable<T> list, Func<T, TKey> lookup) where TKey : struct
        {
            return list.Distinct(new StructEqualityComparer<T, TKey>(lookup));
        }

        class StructEqualityComparer<T, TKey> : IEqualityComparer<T> where TKey : struct
        {

            Func<T, TKey> lookup;

            public StructEqualityComparer(Func<T, TKey> lookup)
            {
                this.lookup = lookup;
            }

            public bool Equals(T x, T y)
            {
                return lookup(x).Equals(lookup(y));
            }

            public int GetHashCode(T obj)
            {
                return lookup(obj).GetHashCode();
            }
        }

        public static bool In<T>(this T t, params T[] values)
        {
            return values.Contains(t);
        }

        public static string WrapText(this string text, int lineLength)
        {
            var charCount = 0;
            var lines = text.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                            .GroupBy(w => (charCount += w.Length + 1) / lineLength)
                            .Select(g => string.Join(" ", g));

            return string.Join("\n", lines.ToArray());
        }


        public static int? ParseInt(this string str)
        {
            int k;
            if (string.IsNullOrWhiteSpace(str)) return null;
            if (int.TryParse(str, out k))
                return k;
            return null;
        }

        public static bool? ParseBool(this string str)
        {
            bool k;
            if (bool.TryParse(str, out k))
                return k;
            return null;
        }

        public static decimal? ParseDecimal(this string str)
        {
            decimal k;
            if (string.IsNullOrWhiteSpace(str)) return null;
            if (decimal.TryParse(str, out k))
                return k;
            return null;
        }

        public static int NullableLength(this string str)
        {
            if (string.IsNullOrEmpty(str)) return 0;
            else return str.Length;
        }


        public static List<decimal> GetPerfectRounding(this List<decimal> original,
            decimal forceSum, int decimals)
        {
            var rounded = original.Select(x => Math.Round(x, decimals)).ToList();
            var delta = forceSum - rounded.Sum();
            if (delta == 0m) return rounded;
            var deltaUnit = Convert.ToDecimal(Math.Pow(0.1, decimals)) * Math.Sign(delta);

            List<int> applyDeltaSequence;
            if (delta < 0)
            {
                applyDeltaSequence = original
                    .Zip(Enumerable.Range(0, int.MaxValue), (x, index) => new { x, index })
                    .OrderBy(a => original[a.index] - rounded[a.index])
                    .ThenByDescending(a => a.index)
                    .Select(a => a.index).ToList();
            }
            else
            {
                applyDeltaSequence = original
                    .Zip(Enumerable.Range(0, int.MaxValue), (x, index) => new { x, index })
                    .OrderByDescending(a => original[a.index] - rounded[a.index])
                    .Select(a => a.index).ToList();
            }

            Enumerable.Repeat(applyDeltaSequence, int.MaxValue)
                .SelectMany(x => x)
                .Take(Convert.ToInt32(delta / deltaUnit))
                .ToList()
                .ForEach(index => rounded[index] += deltaUnit);

            return rounded;
        }

        public static IEnumerable<TSource> DistinctByExt<TSource, TKey>
            (this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> seenKeys = new HashSet<TKey>();
            foreach (TSource element in source)
            {
                if (seenKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }

        public static List<TSource> WhereIn<TSource, TId>(this IQueryable<TSource> source,
            Expression<Func<TSource, TId>> memberSelector, IEnumerable<TId> IdList)
        {
            var IdListDistinct = IdList.Distinct().ToList();
            int batchSize = 2000;

            var result = new List<TSource>();

            for (int i = 0; i < IdListDistinct.Count; i += batchSize)
            {
                var IdListSubset = IdListDistinct.Skip(i).Take(batchSize);
                var predicate = Expression.Lambda<Func<TSource, bool>>(
                    Expression.Call(
                        typeof(Enumerable), "Contains", new Type[] { typeof(TId) },
                        Expression.Constant(IdListSubset), memberSelector.Body
                    ),
                    memberSelector.Parameters
                );
                var partialRes = source.Where(predicate);
                result.AddRange(partialRes);
            }

            return result;
        }
    }
}
