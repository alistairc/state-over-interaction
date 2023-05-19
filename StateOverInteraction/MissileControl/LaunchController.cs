namespace StateOverInteraction.MissileControl;

class LaunchController
{
    readonly IScanner _scanner;
    readonly IMissileLauncher _missileLauncher;

    public LaunchController(IScanner scanner, IMissileLauncher missileLauncher)
    {
        _scanner = scanner;
        _missileLauncher = missileLauncher;
    }

    public void SearchForThreats()
    {
        while (_scanner.Scan() is { } threat)
        {
            _missileLauncher.LaunchMissiles(threat.Location);
        }
    }
}