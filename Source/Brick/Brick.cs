using Godot;
using System;

public class Brick : StaticBody2D
{
    [Signal] public delegate void Hit();

    public void OnBrickHit()
    {
        QueueFree();
    }
}
