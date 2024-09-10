using IoTCommandHub.Commands.Receiver;

namespace IoTCommandHub.Commands;

public class TurnOnTVCommand : ICommand
{
    private TV _tv;

    public TurnOnTVCommand(TV tv)
    {
        _tv = tv;
    }

    public void Execute()
    {
        _tv.TurnOn();
    }

    public void Undo()
    {
        _tv.TurnOff();
    }
}