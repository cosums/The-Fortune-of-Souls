using Godot;
using System;

public partial class Game : Node
{
    public static Game Instance { get; private set;}

    public enum GameState {Play, Dialogue, Paused};
    public GameState State = GameState.Play;

    public override void _Ready()
    {
        if (Instance != null)
        {
            GD.PushWarning("More than one Game Singleton in scene.");
            QueueFree();
            return;
        }
        
        Instance = this;
        GD.Print("Loaded global scene.");
    }

}
