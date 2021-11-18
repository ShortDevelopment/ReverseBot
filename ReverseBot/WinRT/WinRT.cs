using Microsoft.Win32;
using System;

namespace ReverseBot.WinRT
{
    public class WinRT
    {
        public static string FindImplementation<T>() => FindImplementation(typeof(T));

        public static string FindImplementation(Type type)
        {
            Guid iid = type.GetInterface($"I{type.Name}").GUID;
            using (RegistryKey root = Registry.ClassesRoot)
            {
                string clsid = null;
                using (RegistryKey key = root.OpenSubKey($@"Interface\{{{iid}}}\ProxyStubClsid32"))
                {
                    clsid = (string)key.GetValue(null);
                }
                using (RegistryKey key = root.OpenSubKey($@"CLSID\{clsid}\InProcServer32"))
                {
                    return (string)key.GetValue(null);
                }
            }
        }
    }
}
