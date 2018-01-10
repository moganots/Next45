using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Root
{
    public class Rover
    {
        public RoverTerrain Terrain { get; set; }
        public RoverPosition Position { get; set; }
        /// <summary>
        /// Creates an instance of this class
        /// </summary>
        public Rover() { }
        /// <summary>
        /// Creates an instance of this class and sets the Terrain and Position
        /// </summary>
        /// <param name="terrain">The Terrain to be explored by the Rover</param>
        /// <param name="position">The current Position of the Rover on the Terrain</param>
        public Rover(RoverTerrain terrain, string position) : this()
        {
            if (!terrain.IsObjectSet()) throw new ArgumentNullException("terrain", Constants.NullArgumentFormat.SafeFormat("RoverTerrain"));
            this.Terrain = terrain;
            this.Position = new RoverPosition(terrain, position);
        }
        /// <summary>
        /// Executes the specified list of commands
        /// </summary>
        /// <param name="commands">The list of commands to be executed</param>
        /// <returns>bool</returns>
        public bool Explore(string commands)
        {
            if (!commands.IsStringSet()) throw new InvalidOperationException("Command(s) to be executed was not provided.");
            bool explore = true;
            try
            {
                foreach (string command in commands.ToCharArray().Select(e => e.SafeToString()))
                {
                    switch (command)
                    {
                        case "L": explore = TurnLeft();break;
                        case "R": explore = TurnRight(); break;
                        case "M": explore = Move(); break;
                        default:throw new InvalidOperationException("Invalid command specified : {0}".SafeFormat(command));
                    }
                }
            }
            catch (Exception exception)
            {
                explore = false;
                throw exception;
            }
            finally { }
            return explore;
        }
        /// <summary>
        /// Turns the Rover Left
        /// </summary>
        /// <returns>bool</returns>
        public bool TurnLeft()
        {
            bool turned = true;
            try
            {
                Position.Direction = ((Position.Direction - 1) < RoverDirection.N) ? RoverDirection.W : Position.Direction - 1;
                Console.WriteLine("Rover Turned Left : {0}".SafeFormat(Position.Direction.SafeToString()));
            }
            catch (Exception exception)
            {
                turned = false;
                throw exception;
            }
            finally { }
            return turned;
        }
        /// <summary>
        /// Turns the Rover Right
        /// </summary>
        /// <returns>bool</returns>
        public bool TurnRight()
        {
            bool turned = true;
            try
            {
                Position.Direction = ((Position.Direction + 1) > RoverDirection.W) ? RoverDirection.N : Position.Direction + 1;
                Console.WriteLine("Rover Turned Right : {0}".SafeFormat(Position.Direction.SafeToString()));
            }
            catch (Exception exception)
            {
                turned = false;
                throw exception;
            }
            finally { }
            return turned;
        }
        /// <summary>
        /// Moves the Rover 1 cardinal point along the terrain plain.
        /// </summary>
        /// <returns>bool</returns>
        public bool Move()
        {
            bool moved = true;
            try
            {
                if (Position.IsRoverWithinTerrainLimits)
                {
                    switch (Position.Direction)
                    {
                        case RoverDirection.N: Position.Y++; break;
                        case RoverDirection.E: Position.X++; break;
                        case RoverDirection.S: Position.Y--; break;
                        case RoverDirection.W: Position.X--; break;
                    }
                    Console.WriteLine("Rover Moved : x : {0}, y : {1}".SafeFormat(Position.X, Position.Y));
                }
                else
                {
                    throw new InvalidOperationException("Rover is outside the bounds of the Terrain. Rover position :{0}, Terrain position :{1}".SafeFormat(Position.ToString(), Terrain.ToString()));
                }
            }
            catch (Exception exception)
            {
                moved = false;
                throw exception;
            }
            finally { }
            return moved;
        }
        /// <summary>
        /// Class destructor
        /// </summary>
        ~Rover()
        {
            Terrain = null;
            Position = null;
        }
    }
}
