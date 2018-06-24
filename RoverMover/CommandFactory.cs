using MarsRover.Models.Commands;
using System;
using System.Collections.Generic;

namespace RoverMover
{
    /// <summary>
    /// This factory is used to build commands executed on a rover
    /// </summary>
    public class CommandFactory
    {
        // Available types of command
        private IDictionary<char, Command> CommandBag;

        public CommandFactory()
        {
            CommandBag = new Dictionary<char, Command>
            {
                {'L', new LeftCommand()},
                {'M', new MoveCommand()},
                {'R', new RightCommand()},
            };
        }

        /// <summary>
        /// We build a command based on character
        /// </summary>
        /// <param name="command">Valid values are L, M, R</param>
        /// <returns></returns>
        public Command GetCommand(char command)
        {
            Command result;

            if (CommandBag.TryGetValue(command, out result))
            {
                return result;
            }

            // This type of command does not exist
            throw new InvalidOperationException("Unrecognized command " + command);
        }
    }
}
