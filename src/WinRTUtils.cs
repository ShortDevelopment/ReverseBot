using ActivationRegistration;
using Microsoft.Win32;
using System;
using System.IO;
using System.Runtime.InteropServices;
using Windows.Win32.Foundation;
using Windows.Win32.System.WinRT;
using WinRT;

namespace ReverseBot;
public static class WinRTUtils
{
    [DllImport("combase.dll")]
    static extern HRESULT RoGetActivatableClassRegistration(HSTRING activatableClassId, out nint activatableClassRegistration);

    public static Implementation QueryClassRegistration(string activatableClassId)
    {
        var marshalledString = MarshalString.CreateMarshaler(activatableClassId);
        RoGetActivatableClassRegistration((HSTRING)marshalledString.GetAbi(), out var pRegistration).ThrowOnFailure();

        var registration = MarshalInterface<IActivatableClassRegistration>.FromAbi(pRegistration);

        var dllReg = registration.As<IDllServerActivatableClassRegistration>();
        return new(registration.ActivatableClassId, dllReg.DllPath);
    }

    public static Implementation FindIIDImplementation(Guid iid)
    {
        using RegistryKey root = Registry.ClassesRoot;
        string name;
        using (RegistryKey key = root.OpenSubKey($@"Interface\{{{iid}}}"))
            name = (string)key.GetValue(null);

        string clsid = null;
        using (RegistryKey key = root.OpenSubKey($@"Interface\{{{iid}}}\ProxyStubClsid32"))
            clsid = (string)key.GetValue(null);

        if (clsid == null)
            throw new FileNotFoundException();

        string dllPath = null;
        try
        {
            dllPath = FindCLSIDImplementation(new Guid(clsid)).DllPath;
        }
        catch { }

        return new(name, dllPath);
    }

    public static Implementation FindCLSIDImplementation(Guid clsid)
    {
        using RegistryKey root = Registry.ClassesRoot;
        string name = "";
        using (RegistryKey key = root.OpenSubKey($@"CLSID\{{{clsid}}}"))
            name = (string)key.GetValue(null);

        string dllPath = null;
        try
        {
            using RegistryKey key = root.OpenSubKey($@"CLSID\{{{clsid}}}\InProcServer32");
            dllPath = (string)key.GetValue(null);
        }
        catch { }

        return new(name, dllPath);
    }

    public record Implementation(string Name, string DllPath);
}
