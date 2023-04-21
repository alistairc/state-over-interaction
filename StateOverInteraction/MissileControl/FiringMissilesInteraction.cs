using Moq;

namespace StateOverInteraction.MissileControl;

class FiringMissilesInteraction
{
    Mock<IScanner> _scanner = null!;
    Mock<IMissileLauncher> _launcher = null!;
    LaunchController _controller = null!;

    [SetUp]
    public void Setup()
    {
        _scanner = new Mock<IScanner>();
        _launcher = new Mock<IMissileLauncher>();

        _controller = new LaunchController(_scanner.Object, _launcher.Object);
    }

    [Test]
    public void WhenNoThreatsAreDetected_ShouldNotFireTheMissiles()
    {
        _controller.SearchForThreats();

        _launcher.Verify(l => l.LaunchMissiles(It.IsAny<(int, int)>()), Times.Never);
    }

    [Test]
    public void WhenAThreatIsDetected_ShouldFireAMissileAtIt()
    {
        var threatLocation = (1, 11);
        _scanner.SetupSequence(s => s.Scan())
            .Returns(threatLocation);

        _controller.SearchForThreats();

        _launcher.Verify(l => l.LaunchMissiles(threatLocation));
    }

    [Test]
    public void WhenAMultipleThreatsAreDetected_ShouldShootThemAll()
    {
        var threat1Location = (1, 11);
        var threat2Location = (2, 22);
        var threat3Location = (3, 33);
        
        _scanner.SetupSequence(s => s.Scan())
            .Returns(threat1Location)
            .Returns(threat2Location)
            .Returns(threat3Location);

        _controller.SearchForThreats();

        _launcher.Verify(l => l.LaunchMissiles(threat1Location));
        _launcher.Verify(l => l.LaunchMissiles(threat2Location));
        _launcher.Verify(l => l.LaunchMissiles(threat3Location));
    }
}