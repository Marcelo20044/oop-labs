using Itmo.ObjectOrientedProgramming.Lab1.RouteEntity;
using Itmo.ObjectOrientedProgramming.Lab1.RouteEntity.EnvironmentEntity;
using Itmo.ObjectOrientedProgramming.Lab1.RouteEntity.EnvironmentEntity.EnvironmentTypes;
using Itmo.ObjectOrientedProgramming.Lab1.RouteEntity.PathSectionEntity;
using Itmo.ObjectOrientedProgramming.Lab1.RouteEntity.RouteReporting;
using Itmo.ObjectOrientedProgramming.Lab1.Service.Organizations;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceshipEntity;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceshipEntity.ShipModels;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests.Lab1UnitTests;
#pragma warning disable CA1707

public class SpaceResearchDepartmentTests
{
    private ExchangeRate exchangeRate = FuelExchange.GetExchangeRate();

    [Fact]
    public void PleasureShuttleOnMediumDistanceInNebulaOfSpaceIncreasedDensity_ShouldGetLost()
    {
        Spaceship pleasureShuttle = new PleasureShuttle();

        const int antimatterFlaresCount = 0;
        Environment environment = new NebulaOfSpaceIncreasedDensity(antimatterFlaresCount);
        PathSection[] pathSections = { new(environment, PathSectionDistance.Medium) };
        var route = new Route(pathSections);

        RouteResult expected = RouteResult.ShipLoss;
        RouteResult actual = SpaceResearchDepartment.GetTravelStatus(route, pleasureShuttle, exchangeRate);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void AugurOnMediumDistanceInNebulaOfSpaceIncreasedDensity_ShouldGetLost()
    {
        Spaceship augur = new Augur();

        const int antimatterFlaresCount = 0;
        Environment environment = new NebulaOfSpaceIncreasedDensity(antimatterFlaresCount);
        PathSection[] pathSections = { new(environment, PathSectionDistance.Medium) };
        var route = new Route(pathSections);

        RouteResult expected = RouteResult.ShipLoss;
        RouteResult actual = SpaceResearchDepartment.GetTravelStatus(route, augur, exchangeRate);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void VaklasInSubspaceChannelWithAntimatterFlare_CrewShouldDie()
    {
        Spaceship vaklas = new Vaklas();

        const int antimatterFlaresCount = 1;
        Environment environment = new NebulaOfSpaceIncreasedDensity(antimatterFlaresCount);
        PathSection[] pathSections = { new(environment, PathSectionDistance.Small) };
        var route = new Route(pathSections);

        RouteResult expected = RouteResult.CrewDeath;
        RouteResult actual = SpaceResearchDepartment.GetTravelStatus(route, vaklas, exchangeRate);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void VaklasWithPhotonDeflectorInSubspaceChannelWithAntimatterFlare_ShouldSuccess()
    {
        Spaceship vaklas = new Vaklas();
        vaklas.SetPhotonDeflector();

        const int antimatterFlaresCount = 1;
        Environment environment = new NebulaOfSpaceIncreasedDensity(antimatterFlaresCount);
        PathSection[] pathSections = { new(environment, PathSectionDistance.Small) };
        var route = new Route(pathSections);

        RouteResult expected = RouteResult.Success;
        RouteResult actual = SpaceResearchDepartment.GetTravelStatus(route, vaklas, exchangeRate);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void VaklasInNitrineParticleNebulaWithSpaceWhale_ShouldGetDestroyed()
    {
        Spaceship vaklas = new Vaklas();

        const int spaceWhalesCount = 1;
        Environment environment = new NitrineParticleNebula(spaceWhalesCount);
        PathSection[] pathSections = { new(environment, PathSectionDistance.Small) };
        var route = new Route(pathSections);

        RouteResult expected = RouteResult.ShipDestroyed;
        RouteResult actual = SpaceResearchDepartment.GetTravelStatus(route, vaklas, exchangeRate);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void AugurInNitrineParticleNebulaWithSpaceWhale_ShouldSuccessAndDeflectorGetDestroyed()
    {
        Spaceship augur = new Augur();

        const int spaceWhalesCount = 1;
        Environment environment = new NitrineParticleNebula(spaceWhalesCount);
        PathSection[] pathSections = { new(environment, PathSectionDistance.Small) };
        var route = new Route(pathSections);

        RouteResult expected = RouteResult.Success;
        RouteResult actual = SpaceResearchDepartment.GetTravelStatus(route, augur, exchangeRate);

        Assert.Equal(expected, actual);
        Assert.Null(augur.Deflector);
    }

    [Fact]
    public void MeridianInNitrineParticleNebulaWithSpaceWhale_ShouldSuccessAndDeflectorShouldBeIntact()
    {
        Spaceship meridian = new Meridian();

        const int spaceWhalesCount = 1;
        Environment environment = new NitrineParticleNebula(spaceWhalesCount);
        PathSection[] pathSections = { new(environment, PathSectionDistance.Small) };
        var route = new Route(pathSections);

        RouteResult expected = RouteResult.Success;
        RouteResult actual = SpaceResearchDepartment.GetTravelStatus(route, meridian, exchangeRate);

        Assert.Equal(expected, actual);
        Assert.NotNull(meridian.Deflector);
    }

    [Fact]
    public void PleasureShuttleAndVaklasOnShortDistanceInNormalSpace_PleasureShuttleShouldBeSelected()
    {
        Spaceship pleasureShuttle = new PleasureShuttle();
        Spaceship vaklas = new Vaklas();
        Spaceship[] spaceships = { pleasureShuttle, vaklas };

        const int asteroidsCount = 0;
        const int meteoritesCount = 0;
        Environment environment = new NormalSpace(asteroidsCount, meteoritesCount);
        PathSection[] pathSections = { new(environment, PathSectionDistance.Small) };
        var route = new Route(pathSections);

        Spaceship expected = pleasureShuttle;
        Spaceship? actual = SpaceResearchDepartment.FindBestSpaceshipForRoute(route, spaceships, exchangeRate);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void AugurAndStellaOnMediumDistanceInNebulaOfSpaceIncreasedDensity_StellaShouldBeSelected()
    {
        Spaceship augur = new Augur();
        Spaceship stella = new Stella();
        Spaceship[] spaceships = { augur, stella };

        const int antimatterFlaresCount = 0;
        Environment environment = new NebulaOfSpaceIncreasedDensity(antimatterFlaresCount);
        PathSection[] pathSections = { new(environment, PathSectionDistance.Medium) };
        var route = new Route(pathSections);

        Spaceship expected = stella;
        Spaceship? actual = SpaceResearchDepartment.FindBestSpaceshipForRoute(route, spaceships, exchangeRate);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void PleasureShuttleAndVaklasInNitrineParticleNebula_VaklasShouldBeSelected()
    {
        Spaceship pleasureShuttle = new PleasureShuttle();
        Spaceship vaklas = new Vaklas();
        Spaceship[] spaceships = { pleasureShuttle, vaklas };

        const int spaceWhalesCount = 0;
        Environment environment = new NitrineParticleNebula(spaceWhalesCount);
        PathSection[] pathSections = { new(environment, PathSectionDistance.Small) };
        var route = new Route(pathSections);

        Spaceship expected = vaklas;
        Spaceship? actual = SpaceResearchDepartment.FindBestSpaceshipForRoute(route, spaceships, exchangeRate);

        Assert.Equal(expected, actual);
    }

    // Npn - Nitrine Particle Nebula, Ns - Normal Space
    [Fact]
    public void MeridianInNsThenNpnThenNsWith3MeteoritesAnd10AsteroidsAnd2SpaceWhales_VShouldSuccess()
    {
        Spaceship meridian = new Meridian();

        const int asteroidsCountSection1 = 5;
        const int meteoritesCountSection1 = 2;
        Environment environmentSection1 = new NormalSpace(asteroidsCountSection1, meteoritesCountSection1);
        var section1 = new PathSection(environmentSection1, PathSectionDistance.Small);

        const int spaceWhalesCountSection2 = 2;
        Environment environmentSection2 = new NitrineParticleNebula(spaceWhalesCountSection2);
        var section2 = new PathSection(environmentSection2, PathSectionDistance.Small);

        const int asteroidsCountSection3 = 5;
        const int meteoritesCountSection3 = 1;
        Environment environmentSection3 = new NormalSpace(asteroidsCountSection3, meteoritesCountSection3);
        var section3 = new PathSection(environmentSection3, PathSectionDistance.Small);

        PathSection[] pathSections = { section1, section2, section3 };
        var route = new Route(pathSections);

        RouteResult expected = RouteResult.Success;
        RouteResult actual = SpaceResearchDepartment.GetTravelStatus(route, meridian, exchangeRate);

        Assert.Equal(expected, actual);
    }
}



#pragma warning restore CA1707