using Godot;
using System;

public class BallNormalAnimation : AnimatedSprite
{
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        this.Play();
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        Rotation += 0.01f;
    }
}
