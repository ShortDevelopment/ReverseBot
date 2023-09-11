using System;
using System.Reflection;

namespace ReverseBot
{
    internal static class DependencyLoader
    {
        public static void LoadAll()
            => LoadAll(Assembly.GetCallingAssembly());

        public static void LoadAll(Assembly assembly)
        {
            var appDomain = AppDomain.CurrentDomain;
            foreach (var reference in assembly.GetReferencedAssemblies())
                appDomain.Load(reference);
        }
    }
}
