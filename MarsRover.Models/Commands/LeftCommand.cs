namespace MarsRover.Models.Commands
{
    /// <summary>
    /// This command turn the direction of a rover 90 degrees left wards
    /// </summary>
    public class LeftCommand : ICommand
    {
        public void Execute(Rover rover)
        {
            rover.Direction = (rover.Direction - 1) < DirectionE.N ? DirectionE.W : rover.Direction - 1;
        }
    }
}
