using System;
using MarsRover.Models;
using MarsRover.Models.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace RoverMover.Tests
{
    [TestClass]
    public class RoverManagerTests
    {
        [TestMethod]
        public void WillExecuteCommand()
        {
            var command = new Mock<ICommand>();

            var commandFactory = new Mock<ICommandFactory>();
            var manager = new RoverManager(commandFactory.Object);

            var plateau = new Plateau(5, 5);
            plateau.AddRover(0,0, 'N');
            var rover = plateau.ActiveRover;
            command.Setup(x => x.Execute(rover));

            commandFactory.Setup(x => x.GetCommand(It.IsAny<char>())).Returns(command.Object);
            manager.ExecuteCommand('M', plateau);
            commandFactory.Verify(x => x.GetCommand('M'));
            command.Verify(x => x.Execute(rover));
        }
    }
}
