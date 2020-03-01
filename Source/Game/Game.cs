using Godot;
using System;

public class Game : Node2D
{
    public override void _Process(float delta)
    {
        // Quit game when "ESC" is pressed
        if (Input.IsActionPressed("ui_esc"))
        {
            GetTree().Quit();
        }
    }
}
