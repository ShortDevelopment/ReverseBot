using System;
using System.Runtime.InteropServices;

namespace ReverseBot.AppxActivation
{
    [Guid("F27C3930-8029-4AD1-94E3-3DBA417810C1")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IPackageDebugSettings
    {

        [Obsolete]
        void ActivateBackgroundTask();

        [PreserveSig]
        int DisableDebugging([In, MarshalAs(UnmanagedType.LPWStr)] string packageFullName);

        [PreserveSig]
        int EnableDebugging([In, MarshalAs(UnmanagedType.LPWStr)] string packageFullName, [In, MarshalAs(UnmanagedType.LPWStr)] string debuggerCommandLine, [In, MarshalAs(UnmanagedType.LPWStr)] string environment);
    }
}
