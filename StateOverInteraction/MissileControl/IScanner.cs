namespace StateOverInteraction.MissileControl;

public interface IScanner
{
    (int, int)? Scan();
}