using Godot;
using System;

public class PowerupExtraBall : Powerup
{
    public override void OnPowerUp()
    {
        var scene = ResourceLoader.Load("res://Source/Ball/BallNormal/BallNormal.tscn") as PackedScene;
        var gameNode = GetNode<Node2D>("/root/Game") as Game;

        // Increment ball count
        gameNode.BallCount++;

        // TODO: Fix method name in future Godot versions
        // It should be CallDeferred("AddChild", new object[] {ball});
        gameNode.CallDeferred("add_child", scene.Instance());
    }
}
