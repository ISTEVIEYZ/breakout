using Godot;
using System;

public class Game : Node2D
{
    public int BallCount { get; set; }

    public override void _Ready()
    {
        this.BallCount = 1;
    }

    public override void _Process(float delta)
    {
        // Quit game when "ESC" is pressed
        if (Input.IsActionPressed("ui_esc"))
        {
            GetTree().Quit();
        }

        if (BallCount <= 0)
        {
            // TODO: Add lose life logic when ball count is 0.
            this.CreateNewBall();
        }
    }

    private void CreateNewBall()
    {
        BallCount = 1;
        var scene = ResourceLoader.Load("res://Source/Ball/Ball.tscn") as PackedScene;
        this.CallDeferred("add_child", new object[] { scene.Instance() });
    }
}
