using System;

// Console.WriteLine(ReverseBot.WinRT.WinRT.FindImplementation(typeof(AppServiceConnection)));
// Console.WriteLine(ReverseBot.WinRT.WinRT.FindImplementation<Windows.UI.Xaml.Hosting.DesktopWindowXamlSource>());
// Console.WriteLine(ReverseBot.WinRT.WinRT.FindImplementation<StoreContext>());
// Console.WriteLine(ReverseBot.WinRT.WinRT.FindImplementation<Windows.UI.Xaml.Controls.WebView>());
// Console.WriteLine(ReverseBot.WinRT.WinRT.FindImplementation<CoreWindow>());
// Console.WriteLine(ReverseBot.WinRT.WinRT.FindImplementation(typeof(CoreApplication)));

while (true)
{
    Console.Clear();
    Console.Write("GUID: ");
    string input = Console.ReadLine();
    Guid guid = new Guid(input.Replace("GUID_", "").Replace("_", "-"));
    Console.WriteLine(guid.ToString());

    var impl = ReverseBot.WinRT.WinRT.FindIIDImplementation(guid);
    Console.WriteLine($"Name: {impl.name}");
    Console.WriteLine($"DLL: {impl.dllPath}");

    Console.ReadKey();
}

Console.ReadLine();