using IoTCommandHub.Commands.Receiver;

namespace IoTCommandHub.Commands;

public class TurnOnLightCommand : ICommand
{
    private Light _light;

    public TurnOnLightCommand(Light light)
    {
        _light = light;
    }

    public void Execute()
    {
        _light.TurnOn();
    }

    public void Undo()
    {
        _light.TurnOff();
    }
}