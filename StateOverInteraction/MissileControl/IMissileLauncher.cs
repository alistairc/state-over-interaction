namespace StateOverInteraction.MissileControl;

public interface IMissileLauncher
{
    void LaunchMissiles((int, int) threat);
}