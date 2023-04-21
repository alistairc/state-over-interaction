using System.Collections.Concurrent;

namespace StateOverInteraction.MissileControl;

class FakeMissileLauncher : IMissileLauncher
{
    readonly ConcurrentQueue<(int, int)> _targets = new();

    public IEnumerable<(int, int)> TargetedThreats => _targets.AsEnumerable();

    public void LaunchMissiles((int, int) threat)
    {
        _targets.Enqueue(threat);
    }
}