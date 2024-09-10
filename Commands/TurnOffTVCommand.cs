using IoTCommandHub.Commands.Receiver;

namespace IoTCommandHub.Commands;

public class TurnOffTVCommand : ICommand
{
    private TV _tv;

    public TurnOffTVCommand(TV tv)
    {
        _tv = tv;
    }

    public void Execute()
    {
        _tv.TurnOff();
    }

    public void Undo()
    {
        _tv.TurnOn();
    }
}