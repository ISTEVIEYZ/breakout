using Godot;
using System;

public class GlobalSignals : Node
{
    [Signal] public delegate void AddPowerUp(Powerup powerup);
}
