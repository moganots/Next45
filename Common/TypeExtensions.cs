using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    /// <summary>
    /// Provides extension methods for Type
    /// </summary>
    public static class TypeExtensions
    {
        /// <summary>
        /// Converts the specified object value to TOut
        /// </summary>
        /// <typeparam name="TOut">The type to be returned</typeparam>
        /// <param name="value">The value to be converted</param>
        /// <returns>TOut</returns>
        public static TOut ReturnAs<TOut>(this object value)
        {
            if (!value.IsObjectSet() || value == "\0")
                return default(TOut);
            if (typeof(TOut).IsEnum)
                return (TOut)Enum.Parse(typeof(TOut), value.SafeToString());
            return (TOut)Convert.ChangeType(value, typeof(TOut));
        }
    }
}