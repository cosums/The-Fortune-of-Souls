using Godot;
using System;
using DialogueManagerRuntime;

public partial class PlayerController : CharacterBody2D
{
    [Export] float moveSpeed = 100f;
    
    public override void _PhysicsProcess(double delta)
    {
        if (Game.Instance.State != Game.GameState.Play)
        {
            Velocity = Vector2.Zero;
            MoveAndSlide();
            return;
        }
        
        Vector2 direction = Input.GetVector("move_left", "move_right", "move_up", "move_down");
        Vector2 displacement = direction.Normalized() * moveSpeed;
        Velocity = displacement;
        MoveAndSlide();
    }

    public override void _Input(InputEvent @event)
    {
        if (Game.Instance.State != Game.GameState.Play) return;
        
        if (@event.IsActionPressed("interact"))
        {
            if (GetSlideCollisionCount() > 0)
            {
                KinematicCollision2D collision2D = GetLastSlideCollision();
                
                NPCDialogue nPCDialogue = (NPCDialogue)collision2D.GetCollider();

                nPCDialogue.ShowDialoge();
            }
        }
    }

}
