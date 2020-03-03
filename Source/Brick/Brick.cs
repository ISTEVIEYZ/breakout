using Godot;
using System;

public class Brick : KinematicBody2D
{
    [Signal] public delegate void Hit();

    public bool HasPowerUp()
    {
        var powerups = GetParent().GetChildren();
        var powerupFound = false;

        foreach (Node2D node in powerups)
        {
            if (node is Powerup)
            {
                powerupFound = true;
                ((Powerup)node).DropPowerup();
                QueueFree();
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
