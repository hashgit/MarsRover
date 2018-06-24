namespace MarsRover.Models.Commands
{
    /// <summary>
    /// This reprents an abstract command structure
    /// </summary>
    public abstract class Command
    {
        public abstract void Execute(Rover rover);
    }
}
