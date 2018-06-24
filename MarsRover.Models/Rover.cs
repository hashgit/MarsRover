using System;
using System.Collections.Generic;

namespace MarsRover.Models
{
    /// <summary>
    /// This class represents a rover, all rivers belongs to some plateau
    /// </summary>
    public class Rover
    {
        // The coordinates of this rover
        public int PositionX { get; set; }
        public int PositionY { get; set; }

        // The direction of this rover, could be facing North, West, East or South
        public DirectionE Direction { get; set; }

        // The Plateau this rover is standing on
        public Plateau Plateau { get; private set; }

        private IDictionary<DirectionE, Func<bool>> EdgeFunctions;

        public Rover(Plateau plateau)
        {
            Plateau = plateau;

            // Being on the edge may have different meanings depending on the direction
            EdgeFunctions = new Dictionary<DirectionE, Func<bool>>
            {
                {DirectionE.N, () => PositionY == Plateau.MaxY},
                {DirectionE.W, () => PositionX == 0},
                {DirectionE.S, () => PositionY == 0},
                {DirectionE.E, () => PositionX == Plateau.MaxX}
            };
        }

        public void SetPosition(int positionX, int positionY, DirectionE direction)
        {
            PositionX = positionX;
            Direction = direction;
            PositionY = positionY;
        }

        public override String ToString()
        {
            return string.Format("{0} {1} {2}", PositionX, PositionY, Direction);
        }

        /// <summary>
        /// Check of this Rover is facing the edge
        /// </summary>
        /// <returns></returns>
        public bool IsEdging()
        {
            return EdgeFunctions[Direction]();
        }
    }
}
