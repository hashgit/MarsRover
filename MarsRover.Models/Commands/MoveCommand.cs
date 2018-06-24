using System;
using System.Collections.Generic;

namespace MarsRover.Models.Commands
{
    /// <summary>
    /// This command moves a rover one step ahead
    /// </summary>
    public class MoveCommand : Command
    {
        private readonly IDictionary<DirectionE, Action<Rover>> MovementActions;

        public MoveCommand()
        {
            // we move the rover by changing the coordinates by a factor of 1
            MovementActions = new Dictionary<DirectionE, Action<Rover>>
            {
                {DirectionE.N, (rover) => rover.PositionY++},
                {DirectionE.W, (rover) => rover.PositionX--},
                {DirectionE.S, (rover) => rover.PositionY--},
                {DirectionE.E, (rover) => rover.PositionX++}
            };
        }

        /// <summary>
        /// Move the rover if it is not facing the edge
        /// </summary>
        public override void Execute(Rover rover)
        {
            if (!rover.IsEdging())
                MovementActions[rover.Direction](rover);
        }
    }
}
