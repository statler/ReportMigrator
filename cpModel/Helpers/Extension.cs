using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace cpModel.Helpers
{
    public static class Extension
    {
        public static bool IsHtmlTextEmpty(this string rtfHTMLText)
        {
            using (RichEditProcessor _richEditProcessor = new RichEditProcessor())
            {
                return string.IsNullOrWhiteSpace(_richEditProcessor.GetPlainTextFromHTML(rtfHTMLText));
            }
        }

        public static int EnumToInt<TValue>(this TValue value) where TValue : Enum
            => (int)(object)value;

        public static IMappingExpression<TSource, TDestination> Ignore<TSource, TDestination>(
    this IMappingExpression<TSource, TDestination> map,
    Expression<Func<TDestination, object>> selector)
        {
            map.ForMember(selector, config => config.Ignore());
            return map;
        }

        public static IEnumerable<Enum> GetFlags(this Enum e)
        {
            return Enum.GetValues(e.GetType()).Cast<Enum>().Where(e.HasFlag);
        }

        #region String helpers

        /// <summary>
        ///  Return string with spaces between capitalized words in runs of letter chars, keeping acronyms.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string SpaceCapitals(this string s) => new string(Enumerable.Zip(s, s.Skip(1).Append('*'), (cur, next) => (cur, next)).Aggregate(new List<Char>(),
                  // next elt is for a lowercase lookahead, so we append * char as non-LC to match sequence length
                  (accum, pair) =>
                  {
                      if (Char.IsUpper(pair.cur) &&
                          accum.Any() &&
                          accum.Last() != ' ' && // prevent double spacing
                                                 // prevent spacing acronyms (ASCII, SCSI) and only add space in runs of upper/lower letters
                          (Char.IsLetter(accum.Last()) && (!Char.IsUpper(accum.Last()) || Char.IsLower(pair.next))))
                      {
                          accum.Add(' ');
                      }
                      accum.Add(pair.cur);
                      return accum;
                  }).ToArray());


        internal static string ToCamelCase(this string value)
        {
            if (string.IsNullOrEmpty(value)) return value;
            return char.ToLowerInvariant(value[0]) + value.Substring(1);
        }
        #endregion
    }
}
