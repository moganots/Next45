using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Root
{
    /// <summary>
    /// The terrain a Rover will be exploring
    /// </summary>
    public class RoverTerrain
    {
        public int North { get; private set; }
        public int East { get; private set; }
        public int South { get; private set; }
        public int West { get; private set; }
        /// <summary>
        /// Creates an instance of this class
        /// </summary>
        /// <param name="cardinalLimits">The Terrain cardinal limits (N,E,S,W). For example, 8823</param>
        public RoverTerrain(string cardinalLimits)
        {
            if (!cardinalLimits.IsStringSet()) throw new ArgumentNullException("CardinalLimits", Constants.NullArgumentFormat.SafeFormat("CardinalLimits"));
            SetLimits(cardinalLimits);
        }

        private void SetLimits(string cardinalLimits)
        {
            string[] elements = cardinalLimits.ToCharArray().Select(e => e.SafeToString()).ToArray();
            this.North = elements.GetElementAt(0).ReturnAs<int>();
            this.East = elements.GetElementAt(1).ReturnAs<int>();
            this.South = elements.GetElementAt(2).ReturnAs<int>();
            this.West = elements.GetElementAt(3).ReturnAs<int>();
        }

        public override string ToString()
        {
            return "North (Y) : {0}, East (X) : {1}".SafeFormat(North, East);
        }
        /// <summary>
        /// Class destructor
        /// </summary>
        ~RoverTerrain() { }
    }
}