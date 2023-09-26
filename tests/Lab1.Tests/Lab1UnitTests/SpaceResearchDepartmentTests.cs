using Itmo.ObjectOrientedProgramming.Lab1.Entities.Routes;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Routes.Environment;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Routes.Environment.EnvironmentTypes;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Routes.PathSection;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaceships;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaceships.ShipModels;
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
        BaseSpaceship pleasureShuttle = new PleasureShuttleSpaceship();

        const int antimatterFlaresCount = 0;
        BaseEnvironment baseEnvironment = new NebulaOfSpaceIncreasedDensityEnvironment(antimatterFlaresCount);
        PathSection[] pathSections = { new(baseEnvironment, PathSectionDistance.Medium) };
        var route = new Route(pathSections);

        RouteResult expected = RouteResult.ShipLoss;
        RouteResult actual = SpaceResearchDepartment.GetTravelStatus(route, pleasureShuttle, exchangeRate);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void AugurOnMediumDistanceInNebulaOfSpaceIncreasedDensity_ShouldGetLost()
    {
        var augur = new AugurSpaceship();

        const int antimatterFlaresCount = 0;
        BaseEnvironment baseEnvironment = new NebulaOfSpaceIncreasedDensityEnvironment(antimatterFlaresCount);
        PathSection[] pathSections = { new(baseEnvironment, PathSectionDistance.Medium) };
        var route = new Route(pathSections);

        RouteResult expected = RouteResult.ShipLoss;
        RouteResult actual = SpaceResearchDepartment.GetTravelStatus(route, augur, exchangeRate);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void VaklasInSubspaceChannelWithAntimatterFlare_CrewShouldDie()
    {
        BaseSpaceship vaklas = new VaklasSpaceship();

        const int antimatterFlaresCount = 1;
        BaseEnvironment baseEnvironment = new NebulaOfSpaceIncreasedDensityEnvironment(antimatterFlaresCount);
        PathSection[] pathSections = { new(baseEnvironment, PathSectionDistance.Small) };
        var route = new Route(pathSections);

        RouteResult expected = RouteResult.CrewDeath;
        RouteResult actual = SpaceResearchDepartment.GetTravelStatus(route, vaklas, exchangeRate);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void VaklasWithPhotonDeflectorInSubspaceChannelWithAntimatterFlare_ShouldSuccess()
    {
        BaseSpaceship vaklas = new VaklasSpaceship();
        vaklas.SetPhotonDeflector();

        const int antimatterFlaresCount = 1;
        BaseEnvironment baseEnvironment = new NebulaOfSpaceIncreasedDensityEnvironment(antimatterFlaresCount);
        PathSection[] pathSections = { new(baseEnvironment, PathSectionDistance.Small) };
        var route = new Route(pathSections);

        RouteResult expected = RouteResult.Success;
        RouteResult actual = SpaceResearchDepartment.GetTravelStatus(route, vaklas, exchangeRate);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void VaklasInNitrineParticleNebulaWithSpaceWhale_ShouldGetDestroyed()
    {
        BaseSpaceship vaklas = new VaklasSpaceship();

        const int spaceWhalesCount = 1;
        BaseEnvironment baseEnvironment = new NitrineParticleNebulaEnvironment(spaceWhalesCount);
        PathSection[] pathSections = { new(baseEnvironment, PathSectionDistance.Small) };
        var route = new Route(pathSections);

        RouteResult expected = RouteResult.ShipDestroyed;
        RouteResult actual = SpaceResearchDepartment.GetTravelStatus(route, vaklas, exchangeRate);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void AugurInNitrineParticleNebulaWithSpaceWhale_ShouldSuccessAndDeflectorGetDestroyed()
    {
        BaseSpaceship augur = new AugurSpaceship();

        const int spaceWhalesCount = 1;
        BaseEnvironment baseEnvironment = new NitrineParticleNebulaEnvironment(spaceWhalesCount);
        PathSection[] pathSections = { new(baseEnvironment, PathSectionDistance.Small) };
        var route = new Route(pathSections);

        RouteResult expected = RouteResult.Success;
        RouteResult actual = SpaceResearchDepartment.GetTravelStatus(route, augur, exchangeRate);

        Assert.Equal(expected, actual);
        Assert.Null(augur.Deflector);
    }

    [Fact]
    public void MeridianInNitrineParticleNebulaWithSpaceWhale_ShouldSuccessAndDeflectorShouldBeIntact()
    {
        BaseSpaceship meridian = new MeridianSpaceship();

        const int spaceWhalesCount = 1;
        BaseEnvironment baseEnvironment = new NitrineParticleNebulaEnvironment(spaceWhalesCount);
        PathSection[] pathSections = { new(baseEnvironment, PathSectionDistance.Small) };
        var route = new Route(pathSections);

        RouteResult expected = RouteResult.Success;
        RouteResult actual = SpaceResearchDepartment.GetTravelStatus(route, meridian, exchangeRate);

        Assert.Equal(expected, actual);
        Assert.NotNull(meridian.Deflector);
    }

    [Fact]
    public void PleasureShuttleAndVaklasOnShortDistanceInNormalSpace_PleasureShuttleShouldBeSelected()
    {
        BaseSpaceship pleasureShuttle = new PleasureShuttleSpaceship();
        BaseSpaceship vaklas = new VaklasSpaceship();
        BaseSpaceship[] spaceships = { pleasureShuttle, vaklas };

        const int asteroidsCount = 0;
        const int meteoritesCount = 0;
        BaseEnvironment baseEnvironment = new NormalSpaceEnvironment(asteroidsCount, meteoritesCount);
        PathSection[] pathSections = { new(baseEnvironment, PathSectionDistance.Small) };
        var route = new Route(pathSections);

        BaseSpaceship expected = pleasureShuttle;
        BaseSpaceship? actual = SpaceResearchDepartment.FindBestSpaceshipForRoute(route, spaceships, exchangeRate);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void AugurAndStellaOnMediumDistanceInNebulaOfSpaceIncreasedDensity_StellaShouldBeSelected()
    {
        BaseSpaceship augur = new AugurSpaceship();
        BaseSpaceship stella = new StellaSpaceship();
        BaseSpaceship[] spaceships = { augur, stella };

        const int antimatterFlaresCount = 0;
        BaseEnvironment baseEnvironment = new NebulaOfSpaceIncreasedDensityEnvironment(antimatterFlaresCount);
        PathSection[] pathSections = { new(baseEnvironment, PathSectionDistance.Medium) };
        var route = new Route(pathSections);

        BaseSpaceship expected = stella;
        BaseSpaceship? actual = SpaceResearchDepartment.FindBestSpaceshipForRoute(route, spaceships, exchangeRate);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void PleasureShuttleAndVaklasInNitrineParticleNebula_VaklasShouldBeSelected()
    {
        BaseSpaceship pleasureShuttle = new PleasureShuttleSpaceship();
        BaseSpaceship vaklas = new VaklasSpaceship();
        BaseSpaceship[] spaceships = { pleasureShuttle, vaklas };

        const int spaceWhalesCount = 0;
        BaseEnvironment baseEnvironment = new NitrineParticleNebulaEnvironment(spaceWhalesCount);
        PathSection[] pathSections = { new(baseEnvironment, PathSectionDistance.Small) };
        var route = new Route(pathSections);

        BaseSpaceship expected = vaklas;
        BaseSpaceship? actual = SpaceResearchDepartment.FindBestSpaceshipForRoute(route, spaceships, exchangeRate);

        Assert.Equal(expected, actual);
    }

    // Npn - Nitrine Particle Nebula, Ns - Normal Space
    [Fact]
    public void MeridianInNsThenNpnThenNsWith3MeteoritesAnd10AsteroidsAnd2SpaceWhales_VShouldSuccess()
    {
        BaseSpaceship meridian = new MeridianSpaceship();

        const int asteroidsCountSection1 = 5;
        const int meteoritesCountSection1 = 2;
        BaseEnvironment baseEnvironmentSection1 = new NormalSpaceEnvironment(asteroidsCountSection1, meteoritesCountSection1);
        var section1 = new PathSection(baseEnvironmentSection1, PathSectionDistance.Small);

        const int spaceWhalesCountSection2 = 2;
        BaseEnvironment baseEnvironmentSection2 = new NitrineParticleNebulaEnvironment(spaceWhalesCountSection2);
        var section2 = new PathSection(baseEnvironmentSection2, PathSectionDistance.Small);

        const int asteroidsCountSection3 = 5;
        const int meteoritesCountSection3 = 1;
        BaseEnvironment baseEnvironmentSection3 = new NormalSpaceEnvironment(asteroidsCountSection3, meteoritesCountSection3);
        var section3 = new PathSection(baseEnvironmentSection3, PathSectionDistance.Small);

        PathSection[] pathSections = { section1, section2, section3 };
        var route = new Route(pathSections);

        RouteResult expected = RouteResult.Success;
        RouteResult actual = SpaceResearchDepartment.GetTravelStatus(route, meridian, exchangeRate);

        Assert.Equal(expected, actual);
    }
}
#pragma warning restore CA1707