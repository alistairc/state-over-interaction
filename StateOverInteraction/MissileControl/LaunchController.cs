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
        (int, int)? threat;
        while ((threat = _scanner.Scan()) != null)
        {
            _missileLauncher.LaunchMissiles(threat.Value);
        }
    }
}