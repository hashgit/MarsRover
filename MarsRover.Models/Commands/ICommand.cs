namespace MarsRover.Models.Commands
{
    /// <summary>
    /// This reprents an abstract command structure
    /// </summary>
    public interface ICommand
    {
        void Execute(Rover rover);
    }
}
