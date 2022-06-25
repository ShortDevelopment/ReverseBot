using System;
using System.Runtime.InteropServices;

namespace ReverseBot.AppxActivation
{
    [Guid("2e941141-7f97-4756-ba1d-9decde894a3d")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IApplicationActivationManager
    {
        [PreserveSig]
        int ActivateApplication([In] string appUserModelId, [In] string arguments, [In] ActivateOptions options, out int processId);
    }
}
