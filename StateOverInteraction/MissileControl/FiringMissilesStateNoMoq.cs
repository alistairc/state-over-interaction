namespace StateOverInteraction.MissileControl;

public class FiringMissilesStateNoMoq
{
    LaunchController _controller = null!;
    FakeMissileLauncher _launcher = null!;
    FakeScanner _scanner = null!;

    [SetUp]
    public void Setup()
    {
        _scanner = new FakeScanner();
        _launcher = new FakeMissileLauncher();

        _controller = new LaunchController(_scanner, _launcher);
    }

    [Test]
    public void WhenNoThreatsAreDetected_ShouldNotFireTheMissiles()
    {
        _controller.SearchForThreats();

        _launcher.TargetedThreats.ShouldBeEmpty();
    }

    [Test]
    public void WhenAThreatIsDetected_ShouldFireAMissileAtIt()
    {
        var threatLocation = (1, 11);
        _scanner.AddThreat(threatLocation);

        _controller.SearchForThreats();

        _launcher.TargetedThreats.ShouldBe(new[] { threatLocation });
    }

    [Test]
    public void WhenAMultipleThreatsAreDetected_ShouldShootThemAll()
    {
        var threat1Location = (1, 11);
        var threat2Location = (2, 22);
        var threat3Location = (3, 33);

        _scanner
            .AddThreat(threat1Location)
            .AddThreat(threat2Location)
            .AddThreat(threat3Location);

        _controller.SearchForThreats();

        _launcher.TargetedThreats.ShouldBe(new[]
        {
            threat1Location,
            threat2Location,
            threat3Location
        });
    }
}