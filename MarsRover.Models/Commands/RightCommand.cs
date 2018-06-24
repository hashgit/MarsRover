namespace MarsRover.Models.Commands
{
    /// <summary>
    /// The command turns the rover direction 90 degrees right wards
    /// </summary>
    public class RightCommand : Command
    {
        public override void Execute(Rover rover)
        {
            rover.Direction = (rover.Direction + 1) > DirectionE.W ? DirectionE.N : rover.Direction + 1;
        }
    }
}
