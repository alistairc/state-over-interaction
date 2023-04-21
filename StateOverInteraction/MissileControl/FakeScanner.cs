using System.Collections.Concurrent;

namespace StateOverInteraction.MissileControl;

class FakeScanner : IScanner
{
    readonly ConcurrentQueue<(int, int)> _threats = new();

    public (int, int)? Scan()
    {
        var found = _threats.TryDequeue(out var result);
        return found ? result : null;
    }

    public FakeScanner AddThreat((int, int) threatLocation)
    {
        _threats.Enqueue(threatLocation);
        return this;
    }
}