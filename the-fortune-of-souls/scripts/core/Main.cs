using Godot;
using System;

public partial class Main : Node
{
    [Export(PropertyHint.File, "*.tscn,*.scn")] string testScenePath;
    
    public override void _EnterTree()
    {
        GD.Print("Launching game...");
    }
    
    public override void _Ready()
    {
        // setup
        GetTree().ChangeSceneToFile(testScenePath);

    }
}
