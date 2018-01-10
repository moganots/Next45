using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    /// <summary>
    /// Provides extension methods for Enumerables
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Checks if the specified Enumerable has any items
        /// </summary>
        /// <typeparam name="T">The generic type contained in the Enumerable</typeparam>
        /// <param name="self">The Enumerable to check</param>
        /// <returns>bool</returns>
        public static bool IsHasItems<T>(this IEnumerable<T> self)
        {
            return self.IsObjectSet() && self.Any();
        }
        public static T GetElementAt<T>(this IEnumerable<T> self, int index)
        {
            return self.Where((e, i) => IsWithinRange(self, index) && i == index).FirstOrDefault();
        }
        public static bool IsWithinRange<T>(this IEnumerable<T> self, int index)
        {
            return IsHasItems(self) && (index >= 0 && index <= self.Count());
        }
    }
}
