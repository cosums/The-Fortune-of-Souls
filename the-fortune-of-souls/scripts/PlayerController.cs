using Godot;
using System;

public partial class PlayerController : CharacterBody2D
{
    [Export] float moveSpeed = 100f;

    public override void _PhysicsProcess(double delta)
    {
        Vector2 direction = Input.GetVector("move_left", "move_right", "move_up", "move_down");
        Vector2 displacement = direction.Normalized() * moveSpeed;
        Velocity = displacement;
        MoveAndSlide();
    }

}
