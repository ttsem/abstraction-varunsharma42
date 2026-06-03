using System;

public interface IDevice
{
    void Execute();
}

public class Printer : IDevice
{
    public void Execute()
    {
        Console.WriteLine("Printing document...");
    }
}

public class Scanner : IDevice
{
    public void Execute()
    {
        Console.WriteLine("Scanning document...");
    }
}

public class Task
{
    public int TaskId { get; }
    public IDevice Device { get; }

    public Task(int taskId, IDevice device)
    {
        TaskId = taskId;
        Device = device ?? throw new ArgumentNullException(nameof(device));
    }

    public void Run()
    {
        Console.WriteLine($"Executing Task: {TaskId}");
        Device.Execute();
    }
}

public class TaskManager
{
    public void RunTask(Task task)
    {
        if (task == null) throw new ArgumentNullException(nameof(task));
        task.Run();
    }
}

public class Program
{
    public static void Main()
    {
        var printer = new Printer();
        var scanner = new Scanner();

        var manager = new TaskManager();

        manager.RunTask(new Task(101, printer));
        manager.RunTask(new Task(102, scanner));
    }
}
