using Spectre.Console;
using System;
using System.Linq;
using System.ComponentModel;
using System.Diagnostics;

while (true)
{
    Console.Clear();
    var mode = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
        {
            HighlightStyle = Style.WithForeground(Color.LightGreen)
        }
        .Title("Select a module")
        .AddChoices(new[] {
            "GUID",
            "HRES",
            "DLL_SEARCH",
            "EXIT"
        })
    );

    try
    {
        switch (mode)
        {
            case "GUID":
                {
                    string input = AnsiConsole.Ask<string>("Your [lightgreen]Guid[/]:");
                    Guid guid = new Guid(input.Replace("GUID_", "").Replace("_", "-"));
                    Console.WriteLine(guid.ToString());
                    Console.WriteLine(guid.ToString("X")); // NDBPX

                    try
                    {
                        var impl = ReverseBot.WinRT.WinRT.FindIIDImplementation(guid);
                        Console.WriteLine($"Name: {impl.name}; IID_{impl.name}");
                        Console.WriteLine($"DLL: {impl.dllPath}");
                    }
                    catch { }

                    try
                    {
                        var impl = ReverseBot.WinRT.WinRT.FindCLSIDImplementation(guid);
                        Console.WriteLine($"Name: {impl.name}; CLSID_{impl.name}");
                        Console.WriteLine($"DLL: {impl.dllPath}");
                    }
                    catch { }
                    break;
                }
            case "HRES":
                {
                    string input = AnsiConsole.Ask<string>("Your [lightgreen]Hres[/]:");
                    if (!int.TryParse(input, out int hRes))
                        throw new ArgumentException("Not a valid integer");

                    Win32Exception exceptionData = new(hRes);
                    AnsiConsole.WriteLine(exceptionData.Message);
                    break;
                }
            case "DLL_SEARCH":
                {
                    string dllName = AnsiConsole.Ask<string>("Your [lightgreen]DllName[/]:");

                    Process[] processes = Process.GetProcesses();
                    foreach (Process process in processes)
                        try
                        {
                            foreach (ProcessModule module in process.Modules)
                                if (module.FileName.ToLower().Contains(dllName.ToLower()))
                                {
                                    AnsiConsole.WriteLine("---");
                                    AnsiConsole.WriteLine(
                                        $"NAME: {process.ProcessName}\r\n" +
                                        $"PID: {process.Id}\r\n" +
                                        $"PATH: {process.MainModule.FileName}"
                                    );
                                    AnsiConsole.WriteLine("---");
                                    break;
                                }
                        }
                        catch
                        {
                            AnsiConsole.WriteLine($"Can't enumerate modules of \"{process.ProcessName}\". You might want to run as admin...");
                        }
                    break;
                }
            case "EXIT":
                return;
            default:
                throw new ArgumentException("Wrong mode!");
        }
    }
    catch (Exception ex)
    {
        AnsiConsole.WriteException(ex);
    }
    AnsiConsole.WriteLine();
    AnsiConsole.MarkupLine("Press [red]ENTER[/] to proceed");
    Console.ReadLine();
}