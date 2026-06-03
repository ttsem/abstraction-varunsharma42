using System;

public interface IPrinter
{
    void Print();
}

public interface IScanner
{
    void Scan();
}

public class Printer : IPrinter
{
    public void Print()
    {
        Console.WriteLine("Printing document...");
    }
}

public class Scanner : IScanner
{
    public void Scan()
    {
        Console.WriteLine("Scanning document...");
    }
}

public class PrintScanner : IPrinter, IScanner
{
    private readonly IPrinter _printer;
    private readonly IScanner _scanner;

    public PrintScanner(IPrinter printer, IScanner scanner)
    {
        _printer = printer ?? throw new ArgumentNullException(nameof(printer));
        _scanner = scanner ?? throw new ArgumentNullException(nameof(scanner));
    }

    public void Print()
    {
        _printer.Print();
    }

    public void Scan()
    {
        _scanner.Scan();
    }
}

public class TaskManager
{
    public void PrintTask(int taskId, IPrinter printer)
    {
        Console.WriteLine($"Executing Print Task: {taskId}");
        printer.Print();
    }

    public void ScanTask(int taskId, IScanner scanner)
    {
        Console.WriteLine($"Executing Scan Task: {taskId}");
        scanner.Scan();
    }
}

public class Program
{
    public static void Main()
    {
        var printer = new Printer();
        var scanner = new Scanner();
        var printScanner = new PrintScanner(printer, scanner);

        var scheduler = new TaskManager();

        scheduler.PrintTask(101, printScanner);
        scheduler.ScanTask(102, printScanner);
    }
}
