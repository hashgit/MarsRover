using System;
using System.Linq;
using MarsRover.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RoverMover.Tests
{
    [TestClass]
    public class RoverTests
    {
        [TestMethod]
        public void CanAddRovers()
        {
            var plateau = new Plateau(5, 5);

            try
            {
                plateau.AddRover(1, 2, 'N');
            }
            catch (InvalidOperationException e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CanNotAddRovers()
        {
            var plateau = new Plateau(5, 5);

            try
            {
                // Invalid direction
                plateau.AddRover(1, 2, 'A');

                Assert.Fail("Should fail on invalid direction");
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual("Invalid direction A", e.Message);
                throw;
            }
        }

        [TestMethod]
        public void CanChangeDirection()
        {
            var plateau = new Plateau(5, 5);
            var manager = new RoverManager(new CommandFactory());

            try
            {
                plateau.AddRover(1, 2, 'N');
                manager.ExecuteCommand('R', plateau);

                Assert.AreEqual(DirectionE.E, plateau.Rovers.Last().Direction);
            }
            catch (Exception)
            {
                Assert.Fail("Should not be here");
            }
        }

        [TestMethod]
        public void CanMoveForward()
        {
            var plateau = new Plateau(5, 5);
            var manager = new RoverManager(new CommandFactory());

            try
            {
                plateau.AddRover(1, 2, 'N');
                manager.ExecuteCommand('M', plateau);

                Assert.AreEqual(3, plateau.Rovers.Last().PositionY);
            }
            catch (Exception)
            {
                Assert.Fail("Should not be here");
            }
        }

        [TestMethod]
        public void WillNotMoveForwardIfStandingOnEdge()
        {
            var plateau = new Plateau(5, 5);
            var manager = new RoverManager(new CommandFactory());

            try
            {
                plateau.AddRover(1, 5, 'N');
                manager.ExecuteCommand('M', plateau);

                Assert.AreEqual(5, plateau.Rovers.Last().PositionY);
            }
            catch (Exception)
            {
                Assert.Fail("Should not be here");
            }
        }

        [TestMethod]
        public void ScenarioOne()
        {
            var plateau = new Plateau(5, 5);
            var manager = new RoverManager(new CommandFactory());

            try
            {
                plateau.AddRover(1, 2, 'N');
                manager.ExecuteCommand('L', plateau);
                manager.ExecuteCommand('M', plateau);
                manager.ExecuteCommand('L', plateau);
                manager.ExecuteCommand('M', plateau);
                manager.ExecuteCommand('L', plateau);
                manager.ExecuteCommand('M', plateau);
                manager.ExecuteCommand('L', plateau);
                manager.ExecuteCommand('M', plateau);
                manager.ExecuteCommand('M', plateau);

                Assert.AreEqual("1 3 N", plateau.Rovers.Last().ToString());
            }
            catch (Exception)
            {
                Assert.Fail("Should not be here");
            }
        }

        [TestMethod]
        public void ScenarioTwo()
        {
            var plateau = new Plateau(5, 5);
            var manager = new RoverManager(new CommandFactory());

            try
            {
                plateau.AddRover(3, 3, 'E');
                manager.ExecuteCommand('M', plateau);
                manager.ExecuteCommand('M', plateau);
                manager.ExecuteCommand('R', plateau);
                manager.ExecuteCommand('M', plateau);
                manager.ExecuteCommand('M', plateau);
                manager.ExecuteCommand('R', plateau);
                manager.ExecuteCommand('M', plateau);
                manager.ExecuteCommand('R', plateau);
                manager.ExecuteCommand('R', plateau);
                manager.ExecuteCommand('M', plateau);
                
                Assert.AreEqual("5 1 E", plateau.Rovers.Last().ToString());
            }
            catch (Exception)
            {
                Assert.Fail("Should not be here");
            }
        }
    }
}
