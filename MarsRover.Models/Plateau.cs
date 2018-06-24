using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRover.Models
{
    /// <summary>
    /// Represent a Plateau which may contain several Rovers
    /// </summary>
    public sealed class Plateau
    {
        /// <summary>
        /// Upper right coordinates of the Plateau
        /// </summary>
        public int MaxX { get; private set; }
        public int MaxY { get; private set; }

        /// <summary>
        /// List of available Rovers on this plateau
        /// </summary>
        public IList<Rover> Rovers { get; private set; }

        /// <summary>
        /// Active Rover
        /// </summary>
        public Rover ActiveRover { get; private set; }

        public Plateau(int x, int y)
        {
            // we do not allow a plateau of size 0,0
            if (y < 1 || x < 1)
                throw new ArgumentOutOfRangeException(string.Format("Invalid plateau size {0} {1}", x, y));

            MaxX = x;
            MaxY = y;

            Rovers = new List<Rover>();
        }

        /// <summary>
        /// Add a new rover to this plateau
        /// </summary>
        /// <param name="positionX"></param>
        /// <param name="positionY"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        public Rover AddRover(int positionX, int positionY, char direction)
        {
            // Rover can only be added inside the coordinates
            if (positionX < 0 || positionX > MaxX || positionY < 0 || positionY > MaxY)
                throw new ArgumentException(string.Format("Invalid Rover location {0} {1}", positionX, positionY));

            // A rover might already be standing at the given coordinates, this must be an error
            if (Rovers.Any(r => r.PositionX == positionX && r.PositionY == positionY))
                throw new ArgumentException("A rover is already standing at this position!");

            // Valid directions are N,E,W,S
            if (!Enum.TryParse<DirectionE>(direction.ToString(), out DirectionE directionE))
                throw new ArgumentException(string.Format("Invalid direction {0}", direction));

            var rover = new Rover(this);
            rover.SetPosition(positionX, positionY, directionE);
            Rovers.Add(rover);

            ActiveRover = rover;

            return rover;
        }

        public void PrintRovers()
        {
            Array.ForEach(Rovers.ToArray(), Console.WriteLine);
        }
    }
}