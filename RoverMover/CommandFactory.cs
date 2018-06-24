using MarsRover.Models.Commands;
using System;
using System.Collections.Generic;

namespace RoverMover
{
    public interface ICommandFactory
    {
        ICommand GetCommand(char command);
    }

    /// <summary>
    /// This factory is used to build commands executed on a rover
    /// </summary>
    public class CommandFactory : ICommandFactory
    {
        // Available types of command
        private IDictionary<char, ICommand> CommandBag;

        public CommandFactory()
        {
            CommandBag = new Dictionary<char, ICommand>
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
        public ICommand GetCommand(char command)
        {
            ICommand result;

            if (CommandBag.TryGetValue(command, out result))
            {
                return result;
            }

            // This type of command does not exist
            throw new InvalidOperationException("Unrecognized command " + command);
        }
    }
}
