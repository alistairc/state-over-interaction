﻿namespace StateOverInteraction.MissileControl;

public interface IScanner
{
    Threat? Scan();
}