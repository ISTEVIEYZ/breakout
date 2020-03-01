using Godot;
using System;

public class Brick : StaticBody2D
{
    [Signal] public delegate void Hit();

    public bool HasPowerUp()
    {
        var powerups = GetChildren();
        var powerupFound = false;

        foreach (Node2D node in powerups)
        {
            if (node is Powerup)
            {
                powerupFound = true;
                GetNode<Sprite>("Sprite").Visible = false;
                GetNode<CollisionShape2D>("CollisionShape2D").Disabled = true;
                ((Powerup)node).DropPowerup(this);
                break;
            }
        }

        return powerupFound;
    } 

    public virtual void OnBrickHit()
    {
        if (!this.HasPowerUp())
        {
            QueueFree();
        }
    }
}
