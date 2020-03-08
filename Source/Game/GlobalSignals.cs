using Godot;
using System;

public class GlobalSignals : Node
{
    [Signal] public delegate void AddPowerUp(Powerup powerup);

    [Signal] public delegate void GameLoaded();

    public override void _Ready()
    {
        if (!GetParent().HasNode("Game"))
        {
            PackedScene scene = ResourceLoader.Load("res://Source/Game/Game.tscn") as PackedScene;
            GetParent().CallDeferred("add_child", scene.Instance());
            CallDeferred("emit_signal", "GameLoaded");
        }
    }
}
