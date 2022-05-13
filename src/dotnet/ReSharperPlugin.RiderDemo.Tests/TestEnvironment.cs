using System.Threading;
using JetBrains.Application.BuildScript.Application.Zones;
using JetBrains.ReSharper.Feature.Services;
using JetBrains.ReSharper.Psi.CSharp;
using JetBrains.ReSharper.TestFramework;
using JetBrains.TestFramework;
using JetBrains.TestFramework.Application.Zones;
using NUnit.Framework;

[assembly: Apartment(ApartmentState.STA)]

namespace ReSharperPlugin.RiderDemo.Tests
{
    [ZoneDefinition]
    public class RiderDemoTestEnvironmentZone : ITestsEnvZone, IRequire<PsiFeatureTestZone>, IRequire<IRiderDemoZone> { }

    [ZoneMarker]
    public class ZoneMarker : IRequire<ICodeEditingZone>, IRequire<ILanguageCSharpZone>, IRequire<RiderDemoTestEnvironmentZone> { }

    [SetUpFixture]
    public class RiderDemoTestsAssembly : ExtensionTestEnvironmentAssembly<RiderDemoTestEnvironmentZone> { }
}
