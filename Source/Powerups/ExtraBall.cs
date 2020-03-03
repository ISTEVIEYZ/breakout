using Godot;
using System;

public class ExtraBall : Powerup
{
    public override void OnPowerUp()
    {
        var scene = ResourceLoader.Load("res://Source/Ball/Ball.tscn") as PackedScene;
        var level = GetTree().CurrentScene.Name;

        GetNode<Node2D>("/root/" + level + "/Game").AddChild(scene.Instance());
        
        QueueFree();
    }
}
