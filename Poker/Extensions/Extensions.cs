using Poker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Extensions
{
    public static class Extensions
    {
        public static IEnumerable<TSource> MaxsBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            return source.GroupBy(keySelector).MaxBy(g => g.Key);
        }

        public static string ToFormattedString(this IEnumerable<Card> cards) 
        {
            string result = string.Empty;

            foreach (Card c in cards)
            {
                result += c + " ";
            }

            return result;
        }
    }
}
