using MarsRover.Models;
using System;
using System.IO;

namespace RoverMover
{
    class Program
    {
        static void Main()
        {
            var input = File.OpenText("input.txt");
            var plateauSize = input.ReadLine().Split();
            var maxX = Convert.ToInt32(plateauSize[0]);
            var maxY = Convert.ToInt32(plateauSize[1]);
            Plateau plateau = null;

            try
            {
                plateau = new Plateau(maxX, maxY);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Environment.Exit(1);
            }

            var manager = new RoverManager(new CommandFactory());

            do
            {
                var line = input.ReadLine();
                if (line == null)
                    break;

                var position = line.Split();
                int positionX = Convert.ToInt32(position[0]);
                int positionY = Convert.ToInt32(position[1]);
                char direction = Convert.ToChar(position[2]);

                Rover rover = null;

                try
                {
                    rover = plateau.AddRover(positionX, positionY, direction);
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    Environment.Exit(1);
                }

                var commandStream = input.ReadLine();

                Array.ForEach(commandStream.ToCharArray(), command => manager.ExecuteCommand(command, plateau));

            } while (true);

            input.Close();

            plateau.PrintRovers();

            Console.ReadKey();
        }
    }
}
