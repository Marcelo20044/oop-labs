using Itmo.ObjectOrientedProgramming.Lab1.Entities.Routes;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Routes.Environment.EnvironmentTypes;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Routes.PathSection;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaceships;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaceships.ShipModels;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaceships.ShipParts.Engine.ImpulseEngine.ImpulseEngineModels;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaceships.ShipParts.Engine.JumpEngine.JumpEngineModels;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaceships.ShipParts.Protection;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Distance;
using Itmo.ObjectOrientedProgramming.Lab1.Models.RouteReporting;
using Itmo.ObjectOrientedProgramming.Lab1.Services.Organizations;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests.Lab1UnitTests;
#pragma warning disable CA1707

public class SpaceResearchDepartmentTests
{
    private ExchangeRate exchangeRate = FuelExchange.GetExchangeRate();

    [Fact]
    public void PleasureShuttleOnMediumDistanceInNebulaOfSpaceIncreasedDensity_ShouldGetLost()
    {
        ISpaceship pleasureShuttle = new PleasureShuttleSpaceship(new ImpulseEngineC(), new Hull(StrengthClasses.Class1));

        const int antimatterFlaresCount = 0;
        var environment = new NebulaOfSpaceIncreasedDensityEnvironment(Distance.Medium, antimatterFlaresCount);
        PathSection[] pathSections = { new(environment) };
        var route = new Route(pathSections);

        RouteResult expected = RouteResult.ShipLoss;
        RouteResult actual = SpaceResearchDepartment.GetTravelStatus(route, pleasureShuttle, exchangeRate);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void AugurOnMediumDistanceInNebulaOfSpaceIncreasedDensity_ShouldGetLost()
    {
        ISpaceship augur = new AugurSpaceship(new ImpulseEngineE(), new AlphaJumpEngine(), new Deflector(StrengthClasses.Class3), new Hull(StrengthClasses.Class3));

        const int antimatterFlaresCount = 0;
        var environment = new NebulaOfSpaceIncreasedDensityEnvironment(Distance.Medium, antimatterFlaresCount);
        PathSection[] pathSections = { new(environment) };
        var route = new Route(pathSections);

        RouteResult expected = RouteResult.ShipLoss;
        RouteResult actual = SpaceResearchDepartment.GetTravelStatus(route, augur, exchangeRate);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void VaklasInSubspaceChannelWithAntimatterFlare_CrewShouldDie()
    {
        ISpaceship vaklas = new VaklasSpaceship(new ImpulseEngineE(), new GammaJumpEngine(), new Deflector(StrengthClasses.Class1), new Hull(StrengthClasses.Class2));

        const int antimatterFlaresCount = 1;
        var environment = new NebulaOfSpaceIncreasedDensityEnvironment(Distance.Small, antimatterFlaresCount);
        PathSection[] pathSections = { new(environment) };
        var route = new Route(pathSections);

        RouteResult expected = RouteResult.CrewDeath;
        RouteResult actual = SpaceResearchDepartment.GetTravelStatus(route, vaklas, exchangeRate);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void VaklasWithPhotonDeflectorInSubspaceChannelWithAntimatterFlare_ShouldSuccess()
    {
        var vaklas = new VaklasSpaceship(new ImpulseEngineE(), new GammaJumpEngine(), new Deflector(StrengthClasses.Class1), new Hull(StrengthClasses.Class2));
        vaklas.SetPhotonDeflector();

        const int antimatterFlaresCount = 1;
        var environment = new NebulaOfSpaceIncreasedDensityEnvironment(Distance.Small, antimatterFlaresCount);
        PathSection[] pathSections = { new(environment) };
        var route = new Route(pathSections);

        RouteResult expected = RouteResult.Success;
        RouteResult actual = SpaceResearchDepartment.GetTravelStatus(route, vaklas, exchangeRate);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void VaklasInNitrineParticleNebulaWithSpaceWhale_ShouldGetDestroyed()
    {
        ISpaceship vaklas = new VaklasSpaceship(new ImpulseEngineE(), new GammaJumpEngine(), new Deflector(StrengthClasses.Class1), new Hull(StrengthClasses.Class2));

        const int spaceWhalesCount = 1;
        var environment = new NitrineParticleNebulaEnvironment(Distance.Small, spaceWhalesCount);
        PathSection[] pathSections = { new(environment) };
        var route = new Route(pathSections);

        RouteResult expected = RouteResult.ShipDestroyed;
        RouteResult actual = SpaceResearchDepartment.GetTravelStatus(route, vaklas, exchangeRate);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void AugurInNitrineParticleNebulaWithSpaceWhale_ShouldSuccessAndDeflectorGetDestroyed()
    {
        ISpaceshipWithDeflector augur = new AugurSpaceship(new ImpulseEngineE(), new AlphaJumpEngine(), new Deflector(StrengthClasses.Class3), new Hull(StrengthClasses.Class3));

        const int spaceWhalesCount = 1;
        var environment = new NitrineParticleNebulaEnvironment(Distance.Small, spaceWhalesCount);
        PathSection[] pathSections = { new(environment) };
        var route = new Route(pathSections);

        RouteResult expected = RouteResult.Success;
        RouteResult actual = SpaceResearchDepartment.GetTravelStatus(route, augur, exchangeRate);

        Assert.Equal(expected, actual);
        Assert.True(augur.Deflector.IsDestroyed);
    }

    [Fact]
    public void MeridianInNitrineParticleNebulaWithSpaceWhale_ShouldSuccessAndDeflectorShouldBeIntact()
    {
        ISpaceshipWithDeflector meridian = new MeridianSpaceship(new ImpulseEngineE(), new Deflector(StrengthClasses.Class2), new Hull(StrengthClasses.Class2), true);

        const int spaceWhalesCount = 1;
        var environment = new NitrineParticleNebulaEnvironment(Distance.Small, spaceWhalesCount);
        PathSection[] pathSections = { new(environment) };
        var route = new Route(pathSections);

        RouteResult expected = RouteResult.Success;
        RouteResult actual = SpaceResearchDepartment.GetTravelStatus(route, meridian, exchangeRate);

        Assert.Equal(expected, actual);
        Assert.False(meridian.Deflector.IsDestroyed);
    }

    [Fact]
    public void PleasureShuttleAndVaklasOnShortDistanceInNormalSpace_PleasureShuttleShouldBeSelected()
    {
        ISpaceship pleasureShuttle = new PleasureShuttleSpaceship(new ImpulseEngineC(), new Hull(StrengthClasses.Class1));
        ISpaceship vaklas = new VaklasSpaceship(new ImpulseEngineE(), new GammaJumpEngine(), new Deflector(StrengthClasses.Class1), new Hull(StrengthClasses.Class2));
        ISpaceship[] spaceships = { pleasureShuttle, vaklas };

        const int asteroidsCount = 0;
        const int meteoritesCount = 0;
        var environment = new NormalSpaceEnvironment(Distance.Small, asteroidsCount, meteoritesCount);
        PathSection[] pathSections = { new(environment) };
        var route = new Route(pathSections);

        ISpaceship expected = pleasureShuttle;
        ISpaceship? actual = SpaceResearchDepartment.FindBestSpaceshipForRoute(route, spaceships, exchangeRate);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void AugurAndStellaOnMediumDistanceInNebulaOfSpaceIncreasedDensity_StellaShouldBeSelected()
    {
        ISpaceship augur = new AugurSpaceship(new ImpulseEngineE(), new AlphaJumpEngine(), new Deflector(StrengthClasses.Class3), new Hull(StrengthClasses.Class3));
        ISpaceship stella = new StellaSpaceship(new ImpulseEngineC(), new OmegaJumpEngine(), new Deflector(StrengthClasses.Class1), new Hull(StrengthClasses.Class1));
        ISpaceship[] spaceships = { augur, stella };

        const int antimatterFlaresCount = 0;
        var environment = new NebulaOfSpaceIncreasedDensityEnvironment(Distance.Medium, antimatterFlaresCount);
        PathSection[] pathSections = { new(environment) };
        var route = new Route(pathSections);

        ISpaceship expected = stella;
        ISpaceship? actual = SpaceResearchDepartment.FindBestSpaceshipForRoute(route, spaceships, exchangeRate);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void PleasureShuttleAndVaklasInNitrineParticleNebula_VaklasShouldBeSelected()
    {
        ISpaceship pleasureShuttle = new PleasureShuttleSpaceship(new ImpulseEngineC(), new Hull(StrengthClasses.Class1));
        ISpaceship vaklas = new VaklasSpaceship(new ImpulseEngineE(), new GammaJumpEngine(), new Deflector(StrengthClasses.Class1), new Hull(StrengthClasses.Class2));
        ISpaceship[] spaceships = { pleasureShuttle, vaklas };

        const int spaceWhalesCount = 0;
        var environment = new NitrineParticleNebulaEnvironment(Distance.Small, spaceWhalesCount);
        PathSection[] pathSections = { new(environment) };
        var route = new Route(pathSections);

        ISpaceship expected = pleasureShuttle;
        ISpaceship? actual = SpaceResearchDepartment.FindBestSpaceshipForRoute(route, spaceships, exchangeRate);

        Assert.Equal(expected, actual);
    }

    // Npn - Nitrine Particle Nebula, Ns - Normal Space
    [Fact]
    public void MeridianInNsThenNpnThenNsWith4MeteoritesAnd10AsteroidsAnd2SpaceWhales_VShouldSuccess()
    {
        ISpaceship meridian = new MeridianSpaceship(new ImpulseEngineE(), new Deflector(StrengthClasses.Class2), new Hull(StrengthClasses.Class2), true);

        const int asteroidsCountSection1 = 5;
        const int meteoritesCountSection1 = 3;
        var environmentSection1 = new NormalSpaceEnvironment(Distance.Small, asteroidsCountSection1, meteoritesCountSection1);
        var section1 = new PathSection(environmentSection1);

        const int spaceWhalesCountSection2 = 2;
        var environmentSection2 = new NitrineParticleNebulaEnvironment(Distance.Small, spaceWhalesCountSection2);
        var section2 = new PathSection(environmentSection2);

        const int asteroidsCountSection3 = 5;
        const int meteoritesCountSection3 = 1;
        var environmentSection3 = new NormalSpaceEnvironment(Distance.Small, asteroidsCountSection3, meteoritesCountSection3);
        var section3 = new PathSection(environmentSection3);

        PathSection[] pathSections = { section1, section2, section3 };
        var route = new Route(pathSections);

        RouteResult expected = RouteResult.Success;
        RouteResult actual = SpaceResearchDepartment.GetTravelStatus(route, meridian, exchangeRate);

        Assert.Equal(expected, actual);
    }
}
#pragma warning restore CA1707