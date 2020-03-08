using Godot;
using System;

public class Signals : Node
{
    [Signal] public delegate void AddPowerUp(Powerup powerup);

    [Signal] public delegate void GameLoaded();
}
