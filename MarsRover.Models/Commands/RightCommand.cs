namespace MarsRover.Models.Commands
{
    /// <summary>
    /// The command turns the rover direction 90 degrees right wards
    /// </summary>
    public class RightCommand : ICommand
    {
        public void Execute(Rover rover)
        {
            rover.Direction = (rover.Direction + 1) > DirectionE.W ? DirectionE.N : rover.Direction + 1;
        }
    }
}
