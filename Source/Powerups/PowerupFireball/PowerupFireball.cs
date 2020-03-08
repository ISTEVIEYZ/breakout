using Godot;
using System;

public class PowerupFireball : Powerup
{
    public override void OnPowerUp()
    {
        var scene = ResourceLoader.Load("res://Source/Ball/BallFire/BallFire.tscn") as PackedScene;
        var gameNode = GetNode<Node2D>("/root/Game") as Game;

        foreach (Node2D node in gameNode.GetChildren())
        {
            if (node is Ball && !(node is BallFire))
            {
                // Increment ball count
                gameNode.BallCount++;

                // Replace old ball with fireball
                var ballFire = scene.Instance();
                var oldPosition = node.Position;
                gameNode.CallDeferred("add_child", ballFire);
                ballFire.SetDeferred("Position", oldPosition);
                node.QueueFree();
            }
        }
    }
}
