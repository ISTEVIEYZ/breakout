using Godot;
using System;

public interface Ball
{
    void OnScreenExited();

    void OnBodyEntered(Node2D node);
}
