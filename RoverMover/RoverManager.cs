using MarsRover.Models;

namespace RoverMover
{
    public class RoverManager
    {
        private readonly ICommandFactory commandFactory;

        public RoverManager(ICommandFactory commandFactory) {
            this.commandFactory = commandFactory;
        }

        public void ExecuteCommand(char commandCode, Plateau plateau) {
            var command = commandFactory.GetCommand(commandCode);
            command.Execute(plateau.ActiveRover);
        }
    }
}
