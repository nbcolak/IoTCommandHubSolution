namespace IoTCommandHub.Commands;

public interface ICommand
{
    void Execute();
    void Undo(); 
}
