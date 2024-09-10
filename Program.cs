using System.Text.Json.Serialization;
using IoTCommandHub.Commands;
using IoTCommandHub.MQTT;
using Microsoft.Extensions.Options;
using MQTTnet;
using MQTTnet.Client;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllersWithViews();
builder.Services.AddControllers().AddJsonOptions(options =>
{
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});


builder.Services.AddSingleton<IMqttClient>(serviceProvider =>
{
    var mqttFactory = new MqttFactory();
    return mqttFactory.CreateMqttClient();
});
builder.Services.Configure<MqttOptions>(builder.Configuration.GetSection("Mqtt"));

builder.Services.AddSingleton<MqttClientOptions>(serviceProvider =>
{
    var mqttOptions = serviceProvider.GetRequiredService<IOptions<MqttOptions>>().Value;

    return new MqttClientOptionsBuilder()
        .WithClientId(mqttOptions.ClientId)
        .WithTcpServer(mqttOptions.BrokerAddress, mqttOptions.Port)
        .WithCleanSession()
        .Build();
});


builder.Services.AddSingleton<Invoker>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers(); 




app.Run();
