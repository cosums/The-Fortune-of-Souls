using Godot;
using System;
using DialogueManagerRuntime;

public partial class NPCDialogue : StaticBody2D
{
    [Export] Resource dialogue;

    public void ShowDialoge()
    {
        DialogueManager.ShowExampleDialogueBalloon(dialogue, "start");
        Game.Instance.State = Game.GameState.Dialogue; 
    }
}
