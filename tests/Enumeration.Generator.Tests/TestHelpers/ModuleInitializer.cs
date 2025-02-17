using System.Runtime.CompilerServices;

namespace Enumeration.Generator.Tests.TestHelpers;

internal static class ModuleInitializer
{
    [ModuleInitializer]
    public static void Init() => VerifySourceGenerators.Initialize();
}