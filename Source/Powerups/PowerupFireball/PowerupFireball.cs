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
                // Replace old ball with fireball
                var ballFire = scene.Instance();
                var oldBall = node as RigidBody2D;

                gameNode.CallDeferred("add_child", ballFire);
                ballFire.SetDeferred("Position", oldBall.Position);
                ballFire.SetDeferred("LinearVelocity", oldBall.LinearVelocity);

                // We need to increment count because calling QueueFree decrements it.
                gameNode.BallCount++;
                node.QueueFree();
            }
        }
    }
}
