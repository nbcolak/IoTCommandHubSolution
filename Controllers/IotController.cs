using System.Text;
using IoTCommandHub.Commands;
using IoTCommandHub.Commands.Receiver;
using Microsoft.AspNetCore.Mvc;
using MQTTnet;
using MQTTnet.Client;

namespace IoTCommandHub.Controllers;
[ApiController]
[Route("api/[controller]")]
public class IotController : ControllerBase
{
    private readonly Invoker _invoker;
    private readonly IMqttClient _mqttClient;
    private readonly MqttClientOptions _mqttOptions;


    public IotController(Invoker invoker, IMqttClient mqttClient, MqttClientOptions mqttOptions)
    {
        _invoker = invoker;
        _mqttClient = mqttClient;
        _mqttOptions = mqttOptions;
    }
    [HttpPost("connect")]
    public async Task<IActionResult> Connect()
    {
        if (!_mqttClient.IsConnected)
        {
            await _mqttClient.ConnectAsync(_mqttOptions, CancellationToken.None);
            return Ok("Connected to MQTT broker.");
        }

        return Ok("Already connected.");
    }

    [HttpPost("publish")]
    public async Task<IActionResult> Publish(string topic, string payload)
    {
        if (!_mqttClient.IsConnected)
        {
            return BadRequest("Not connected to the MQTT broker.");
        }

        var message = new MqttApplicationMessageBuilder()
            .WithTopic(topic)
            .WithPayload(payload)
            .Build();

        await _mqttClient.PublishAsync(message);
        return Ok("Message published.");
    }

    [HttpPost("setCommand")]
    public IActionResult SetCommand([FromQuery] CommandType commandType)
    {
        switch (commandType)
        {
            case CommandType.TurnOnLight:
                _invoker.SetCommand(new TurnOnLightCommand(new Light()));
                break;
            case CommandType.TurnOffLight:
                _invoker.SetCommand(new TurnOffLightCommand(new Light()));
                break;
            case CommandType.TurnOnTV:
                _invoker.SetCommand(new TurnOnTVCommand(new TV()));
                break;
            case CommandType.TurnOffTV:
                _invoker.SetCommand(new TurnOffTVCommand(new TV()));
                break;
            case CommandType.TurnOnAirConditioner:
                _invoker.SetCommand(new TurnOnAirConditionerCommand(new AirConditioner()));
                break;
            case CommandType.TurnOffAirConditioner:
                _invoker.SetCommand(new TurnOffAirConditionerCommand(new AirConditioner()));
                break;
            case CommandType.All:
                var allCommands = new List<ICommand>
                {
                    new TurnOnLightCommand(new Light()),
                    new TurnOffLightCommand(new Light()),
                    new TurnOnTVCommand(new TV()),
                    new TurnOffTVCommand(new TV()),
                    new TurnOnAirConditionerCommand(new AirConditioner()),
                    new TurnOffAirConditionerCommand(new AirConditioner())
                };
                _invoker.SetCommands(allCommands);
                break;
            default:
                return BadRequest("Unknown command");
        }

        return Ok("Command set successfully.");
    }

    [HttpPost("execute")]
    public async Task<IActionResult> ExecuteCommand()
    {
        try
        {
            _invoker.ExecuteCommand();

            var currentCommand = _invoker.GetCurrentCommand();
            await PublishCommandToMQTT(currentCommand.GetType().Name, "Executed");

            return Ok("Command executed and published to MQTT.");
        }
        catch (NullReferenceException ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPost("undo")]
    public async Task<IActionResult> UndoCommand()
    {
        try
        {
            _invoker.UndoCommand();

            var currentCommand = _invoker.GetCurrentCommand();
            await PublishCommandToMQTT(currentCommand.GetType().Name, "Undo");

            return Ok("Undo command executed and published to MQTT.");
        }
        catch (NullReferenceException ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    private async Task PublishCommandToMQTT(string commandName, string action)
    {
        if (!_mqttClient.IsConnected)
        {
            await _mqttClient.ConnectAsync(_mqttOptions, CancellationToken.None);
        }

        var messagePayload = $"Command {action}: {commandName}";
        var message = new MqttApplicationMessageBuilder()
            .WithTopic("iot/commands")
            .WithPayload(Encoding.UTF8.GetBytes(messagePayload))
            .WithQualityOfServiceLevel(MQTTnet.Protocol.MqttQualityOfServiceLevel.AtLeastOnce)
            .WithRetainFlag(false)
            .Build();

        await _mqttClient.PublishAsync(message, CancellationToken.None);
    }
}