using Godot;
using System;

public class Startup : Node
{
    public override void _Ready()
    {
        if (!GetParent().HasNode("Game"))
        {
            PackedScene scene = ResourceLoader.Load("res://Source/Game/Game.tscn") as PackedScene;
            GetParent().CallDeferred("add_child", scene.Instance());
            GetParent().GetNode<Node>("Signals").CallDeferred("emit_signal", "GameLoaded");
        }
    }
}
