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
            this.CreateNewBall();
        }
    }

    public void Start()
    {
        // Get player group and check if it exists before spawning
        var playerGroup = GetTree().GetNodesInGroup("Player");

        if (playerGroup.Count == 0)
        {
            PackedScene scene = ResourceLoader.Load("res://Source/Player/Player.tscn") as PackedScene;
            var player = scene.Instance() as Player;
            CallDeferred("add_child", scene.Instance());
        }
    }

    private void CreateNewBall()
    {
        BallCount = 1;
        var scene = ResourceLoader.Load("res://Source/Ball/BallNormal/BallNormal.tscn") as PackedScene;
        this.CallDeferred("add_child", scene.Instance());
    }
}
