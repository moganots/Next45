using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Root
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.IsHasItems())
            {
                try
                {
                    RoverTerrain terrain = new RoverTerrain(args[0]);
                    Rover rover = new Rover(terrain, args[1]);
                    rover.Explore(args[2]);
                    Console.WriteLine("Rover position : {0}".SafeFormat(rover.Position.ToString()));
                    Console.WriteLine("Press any key to exit the application.");
                    string line = Console.ReadLine();
                }
                catch (Exception exception)
                {
                    throw exception;
                }
                finally { }
            }
        }
    }
}
