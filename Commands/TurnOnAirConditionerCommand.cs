using IoTCommandHub.Commands.Receiver;

namespace IoTCommandHub.Commands;

public class TurnOnAirConditionerCommand : ICommand
{
    private AirConditioner _airConditioner;

    public TurnOnAirConditionerCommand(AirConditioner airConditioner)
    {
        _airConditioner = airConditioner;
    }

    public void Execute()
    {
        _airConditioner.TurnOn();
    }

    public void Undo()
    {
        _airConditioner.TurnOff();
    }
}