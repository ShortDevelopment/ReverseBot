using System;
using Windows.Services.Store;

Console.WriteLine(ReverseBot.WinRT.WinRT.FindImplementation<StoreContext>());
Console.WriteLine(ReverseBot.WinRT.WinRT.FindImplementation<Windows.UI.Xaml.Controls.WebView>());
Console.WriteLine(ReverseBot.WinRT.WinRT.FindImplementation<Windows.UI.Xaml.Controls.Page>());

Console.ReadLine();