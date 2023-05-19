using Moq;

namespace StateOverInteraction.MissileControl;

public class FiringMissilesStateWithMoq
{
    LaunchController _controller = null!;
    FakeMissileLauncher _launcher = null!;

    Mock<IScanner> _scanner = null!;

    [SetUp]
    public void Setup()
    {
        _scanner = new Mock<IScanner>();
        _launcher = new FakeMissileLauncher();

        _controller = new LaunchController(_scanner.Object, _launcher);
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
        _scanner.SetupSequence(s => s.Scan())
            .Returns(new Threat(threatLocation));

        _controller.SearchForThreats();

        _launcher.TargetedThreats.ShouldBe(new[] { threatLocation });
    }

    [Test]
    public void WhenAMultipleThreatsAreDetected_ShouldShootThemAll()
    {
        var threat1Location = (1, 11);
        var threat2Location = (2, 22);
        var threat3Location = (3, 33);

        _scanner.SetupSequence(s => s.Scan())
            .Returns(new Threat(threat1Location))
            .Returns(new Threat(threat2Location))
            .Returns(new Threat(threat3Location));

        _controller.SearchForThreats();

        _launcher.TargetedThreats.ShouldBe(new[]
        {
            threat1Location,
            threat2Location,
            threat3Location
        });
    }
}