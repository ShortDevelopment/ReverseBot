using ReverseBot;
using ReverseBot.AppxActivation;
using Spectre.Console;
using System;
using System.CommandLine;
using System.ComponentModel;
using System.Diagnostics;

RootCommand rootCommand = [];

rootCommand.AddCommand(GuidCommand());
rootCommand.AddCommand(HresCommand());
rootCommand.AddCommand(DllSearch());
rootCommand.AddCommand(AppxActivationCommand());
rootCommand.AddCommand(WinRTImplCommand());

return await rootCommand.InvokeAsync(args);

static Command GuidCommand()
{
    Command guidCommand = new("guid");

    Argument<string> valueArg = new("value");
    guidCommand.AddArgument(valueArg);

    guidCommand.SetHandler(static input =>
    {
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
    }, valueArg);
    return guidCommand;
}

static Command HresCommand()
{
    Command guidCommand = new("hres");

    Argument<int> valueArg = new("value");
    guidCommand.AddArgument(valueArg);

    guidCommand.SetHandler(static hres =>
    {
        Win32Exception exceptionData = new(hres);
        AnsiConsole.WriteLine(exceptionData.Message);
    }, valueArg);
    return guidCommand;
}

static Command DllSearch()
{
    Command guidCommand = new("dll-search");

    Argument<string> nameArg = new("name");
    guidCommand.AddArgument(nameArg);

    guidCommand.SetHandler(static dllName =>
    {
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
    }, nameArg);
    return guidCommand;
}

static Command AppxActivationCommand()
{
    Command guidCommand = new("appx-activate");

    Option<string> aumid = new("appUserModelId");
    guidCommand.AddOption(aumid);

    guidCommand.SetHandler(static appUserModelId =>
    {
        ApplicationActivationManager.ActivateApplication(appUserModelId);
    }, aumid);
    return guidCommand;
}

static Command WinRTImplCommand()
{
    Command guidCommand = new("winrt-impl");

    Argument<string> typeNameArg = new("typeName");
    guidCommand.AddArgument(typeNameArg);

    guidCommand.SetHandler(static typeName =>
    {
        Console.WriteLine(WinRTUtils.QueryClassRegistration(typeName));
    }, typeNameArg);
    return guidCommand;
}
