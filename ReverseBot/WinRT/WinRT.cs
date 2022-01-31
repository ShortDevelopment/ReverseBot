using Microsoft.Win32;
using System;
using System.IO;
using System.Linq;

namespace ReverseBot.WinRT
{
    public class WinRT
    {
        public static string FindImplementation<T>() => FindImplementation(typeof(T));

        public static string FindImplementation(Type type)
        {
            using (RegistryKey root = Registry.LocalMachine)
            using (RegistryKey key = root.OpenSubKey($@"SOFTWARE\Microsoft\WindowsRuntime\ActivatableClassId\{type.FullName}"))
                if (key != null && key.GetValueNames().Contains("DllPath"))
                    return (string)key.GetValue("DllPath");

            Guid iid = type.GetInterface($"I{type.Name}").GUID;
            return FindIIDImplementation(iid).dllPath;
        }

        public static Implementation FindIIDImplementation(Guid iid)
        {
            using (RegistryKey root = Registry.ClassesRoot)
            {
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
                    dllPath = FindCLSIDImplementation(new Guid(clsid)).dllPath;
                }
                catch { }

                return new(name, dllPath);
            }
        }

        public static Implementation FindCLSIDImplementation(Guid clsid)
        {
            using (RegistryKey root = Registry.ClassesRoot)
            {
                string name = "";
                using (RegistryKey key = root.OpenSubKey($@"CLSID\{{{clsid}}}"))
                    name = (string)key.GetValue(null);

                string dllPath = null;
                try
                {
                    using (RegistryKey key = root.OpenSubKey($@"CLSID\{{{clsid}}}\InProcServer32"))
                        dllPath = (string)key.GetValue(null);
                }
                catch { }

                return new(name, dllPath);
            }
        }

        public record Implementation(string name, string dllPath);
    }
}
