using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    /// <summary>
    /// Provides extension methods for object
    /// </summary>
    public static class ObjectExtensions
    {
        /// <summary>
        /// Checks if the specified object is set
        /// Returns true if the object is set, false if otherwise.
        /// </summary>
        /// <param name="self">The object to check / test if is set</param>
        /// <returns>bool</returns>
        public static bool IsObjectSet(this object self)
        {
            return self != null;
        }
    }
}
