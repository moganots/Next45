using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Root
{
    /// <summary>
    /// This class provides the location (coordinates - X-Y, direction) of a Rover
    /// </summary>
    public class RoverPosition
    {
        public RoverTerrain Terrain { get; private set; }
        /// <summary>
        /// The X cardinal position
        /// </summary>
        public int X { get; set; }
        /// <summary>
        /// The Y cardinal position
        /// </summary>
        public int Y { get; set; }
        /// <summary>
        /// The Rover cardinal point (N,E,S,W)
        /// </summary>
        public RoverDirection Direction { get; set; }
        public bool IsOnNorthLimit { get { return Y == Terrain.North; } }
        public bool IsOnEastLimit { get { return X == Terrain.East; } }
        public bool IsOnSoutLimit { get { return Y == Terrain.South; } }
        public bool IsOnWestLimit { get { return X == Terrain.West; } }
        public bool IsRoverWithinTerrainLimits
        {
            get { return X <= Terrain.East || Y <= Terrain.North; }
        }
        public override string ToString()
        {
            return "{0}{1} {2}".SafeFormat(X, Y, Direction.SafeToString());
        }
        public RoverPosition() { }
        /// <summary>
        /// Creates an instance of this class
        /// </summary>
        /// <param name="terrain">The Rover terrain to be explored</param>
        public RoverPosition(RoverTerrain terrain) : this()
        {
            this.Terrain = terrain;
        }
        /// <summary>
        /// Creates an instance of this class
        /// </summary>
        /// <param name="position">The current position / location of the Rover on the Terrain being explored.</param>
        public RoverPosition(RoverTerrain terrain, string position):this(terrain)
        {
            if (!position.IsStringSet()) throw new ArgumentNullException("position", Constants.NullArgumentFormat.SafeFormat("Position"));
            if (position.ToCharArray().Length <= 1) throw new InvalidOperationException("Invalid format specified for Position : {0}".SafeFormat(position));
            SetValues(position);
        }

        private void SetValues(string position)
        {
            string[] elements = position.ToCharArray().Select(e => e.SafeToString()).ToArray();
            this.X = elements.GetElementAt(0).ReturnAs<int>();
            this.Y = elements.GetElementAt(1).ReturnAs<int>();
            this.Direction = elements.GetElementAt(2).ReturnAs<RoverDirection>();
        }
    }
}