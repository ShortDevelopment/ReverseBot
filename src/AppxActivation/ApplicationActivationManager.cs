#nullable enable

using System;
using System.Runtime.InteropServices;

namespace ReverseBot.AppxActivation
{
    public static class ApplicationActivationManager
    {
        static IApplicationActivationManager? activationManager;
        static IPackageDebugSettings? debugSettings;

        static ApplicationActivationManager()
        {
            object? instance = Activator.CreateInstance(Type.GetTypeFromCLSID(new Guid("45BA127D-10A8-46EA-8AB7-56EA9078943C"))!);
            if (instance != null)
                activationManager = instance as IApplicationActivationManager;

            instance = Activator.CreateInstance(Type.GetTypeFromCLSID(new Guid("B1AEC16F-2383-4852-B0E9-8F0B1DC66B4D"))!);
            if (instance != null)
                debugSettings = instance as IPackageDebugSettings;
        }

        public static void ActivateApplication(string appUserModelId)
        {
            if (activationManager == null)
                throw new PlatformNotSupportedException();

            Marshal.ThrowExceptionForHR(activationManager.ActivateApplication(appUserModelId, null, ActivateOptions.None, out _));
        }

        public static void EnableDebugging(string packageFullName, string? debuggerPath = null)
        {
            if (debugSettings == null)
                throw new PlatformNotSupportedException();

            Marshal.ThrowExceptionForHR(debugSettings.EnableDebugging(packageFullName, debuggerPath, null));
        }

        public static void DisableDebugging(string packageFullName)
        {
            if (debugSettings == null)
                throw new PlatformNotSupportedException();

            Marshal.ThrowExceptionForHR(debugSettings.DisableDebugging(packageFullName));
        }
    }
}
