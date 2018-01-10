using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    /// <summary>
    /// Provides extension methods for string types
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Checks if the specified object is set
        /// Returns true if it is set, false if otherwise.
        /// </summary>
        /// <param name="self">The object to check / test that it is set</param>
        /// <returns>bool</returns>
        public static bool IsStringSet(this object self)
        {
            return !string.IsNullOrEmpty(SafeToString(self)) && !string.IsNullOrWhiteSpace(SafeToString(self)) && SafeToString(self).Length != 0;
        }
        /// <summary>
        /// Checks if the object being parsed is set before applying the ToString() method
        /// </summary>
        /// <param name="self">The object to apply the ToString()</param>
        /// <returns>string</returns>
        public static string SafeToString(this object self)
        {
            return self.IsObjectSet() ? self.ToString() : string.Empty;
        }
        public static string SafeFormat(this string format, params object[] args)
        {
            if (!IsStringSet(format) || !args.IsHasItems()) return format;
            return string.Format(format, args);
        }
    }
}
