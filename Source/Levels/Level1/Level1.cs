using Godot;
using System;

public class Level1 : LevelBase
{
    public override void _Ready()
    {
        base._Ready();
        GetNode<AnimatedSprite>("AnimatedSprite").Play();
    }
}
