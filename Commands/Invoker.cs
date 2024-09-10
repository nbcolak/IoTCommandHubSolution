namespace IoTCommandHub.Commands;
public class Invoker
{
    private List<ICommand> _commands = new List<ICommand>();
    private ICommand _currentCommand; 

    public void SetCommand(ICommand command)
    {
        _commands.Clear(); 
        _commands.Add(command);
        _currentCommand = command; 
        Console.WriteLine("Command set: " + command.GetType().Name);
    }

    public void SetCommands(List<ICommand> commands)
    {
        _commands.Clear();
        _commands.AddRange(commands);
        Console.WriteLine("All commands set.");
    }

    public void ExecuteCommand()
    {
        if (!_commands.Any())
        {
            Console.WriteLine("No commands have been set.");
            throw new NullReferenceException("Commands are not set.");
        }

        foreach (var command in _commands)
        {
            command.Execute();
        }
    }

    public void UndoCommand()
    {
        if (!_commands.Any())
        {
            Console.WriteLine("No commands have been set.");
            throw new NullReferenceException("Commands are not set.");
        }

        foreach (var command in _commands)
        {
            command.Undo();
        }
    }

    public ICommand GetCurrentCommand()
    {
        return _currentCommand; 
    }
}