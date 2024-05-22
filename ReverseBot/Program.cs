using ReverseBot;
using ReverseBot.AppxActivation;
using Spectre.Console;
using System;
using System.ComponentModel;
using System.Diagnostics;
using Style = Spectre.Console.Style;

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
            "Activate_Appx",
            "WinRT_Impl",
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
                    Guid guid = new(input.Replace("GUID_", "").Replace("_", "-"));
                    Console.WriteLine(guid.ToString());
                    Console.WriteLine(guid.ToString("X")); // NDBPX

                    try
                    {
                        var impl = WinRTUtils.FindIIDImplementation(guid);
                        Console.WriteLine($"Name: {impl.Name}; IID_{impl.Name}");
                        Console.WriteLine($"DLL: {impl.DllPath}");
                    }
                    catch { }

                    try
                    {
                        var impl = WinRTUtils.FindCLSIDImplementation(guid);
                        Console.WriteLine($"Name: {impl.Name}; CLSID_{impl.Name}");
                        Console.WriteLine($"DLL: {impl.DllPath}");
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
            case "Activate_Appx":
                {
                    string appUserModelId = AnsiConsole.Ask<string>("[lightgreen]appUserModelId[/]:");
                    string packageFullName = AnsiConsole.Ask<string>("[lightgreen]packageFullName[/]:");
                    string debuggerPath = AnsiConsole.Ask<string>("[lightgreen]debuggerPath[/]:");

                    ApplicationActivationManager.DisableDebugging(packageFullName);
                    ApplicationActivationManager.EnableDebugging(packageFullName, debuggerPath);
                    ApplicationActivationManager.ActivateApplication(appUserModelId);

                    AnsiConsole.MarkupLine("Press [red]ENTER[/] to resume");
                    Console.ReadLine();

                    ApplicationActivationManager.DisableDebugging(packageFullName);
                    break;
                }
            case "WinRT_Impl":
                {
                    string typeName = AnsiConsole.Ask<string>("[lightgreen]typeName[/]:");
                    Console.WriteLine(WinRTUtils.QueryClassRegistration(typeName));
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