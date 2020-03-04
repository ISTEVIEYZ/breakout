using Godot;
using System;

public class Fireball : Powerup
{
    public override void OnPowerUp()
    {
        var scene = ResourceLoader.Load("res://Source/Ball/BallFire.tscn") as PackedScene;

        var level = GetTree().CurrentScene.Name;
        var gameNode = GetNode<Node2D>("/root/" + level + "/Game") as Game;

        foreach (Node2D node in gameNode.GetChildren())
        {
            if (node is Ball && !(node is BallFire))
            {
                // TODO: Fix method name in future Godot versions
                // It should be CallDeferred("AddChild", new object[] {ball});
                gameNode.CallDeferred("add_child", new object[] { scene.Instance() });
                node.QueueFree();
            }
        }
    }
}
