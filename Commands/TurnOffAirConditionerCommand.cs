using IoTCommandHub.Commands.Receiver;

namespace IoTCommandHub.Commands;

public class TurnOffAirConditionerCommand : ICommand
{
    private AirConditioner _airConditioner;

    public TurnOffAirConditionerCommand(AirConditioner airConditioner)
    {
        _airConditioner = airConditioner;
    }

    public void Execute()
    {
        _airConditioner.TurnOff();
    }

    public void Undo()
    {
        _airConditioner.TurnOn();
    }
}
