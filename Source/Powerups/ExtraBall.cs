using Godot;
using System;

public class ExtraBall : Powerup
{
    public override void OnPowerUp()
    {
        var scene = ResourceLoader.Load("res://Source/Ball/Ball.tscn") as PackedScene;
        var level = GetTree().CurrentScene.Name;
        var gameNode = GetNode<Node2D>("/root/" + level + "/Game") as Game;

        // Increment ball count
        gameNode.BallCount++;

        // TODO: Fix method name in future Godot versions
        // It should be CallDeferred("AddChild", new object[] {ball});
        gameNode.CallDeferred("add_child", new object[] { scene.Instance() });
    }
}
