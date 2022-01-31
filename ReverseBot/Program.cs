using Spectre.Console;
using System;
using System.ComponentModel;

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
            "EXIT"
        })
    );

    try
    {
        switch (mode)
        {
            case "GUID":
                {
                    string input = AnsiConsole.Ask<string>("Your [green]Guid[/]:");
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
                    string input = AnsiConsole.Ask<string>("Your [green]Hres[/]:");
                    if (!int.TryParse(input, out int hRes))
                        throw new ArgumentException("Not a valid integer");
                    Win32Exception exceptionData = new(hRes);
                    AnsiConsole.WriteLine(exceptionData.Message);
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
    AnsiConsole.WriteLine("Press ENTER to proceed");
    Console.ReadLine();
}