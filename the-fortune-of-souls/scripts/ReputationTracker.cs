using Godot;
using System;

public partial class ReputationTracker : Node
{
    public static ReputationTracker Instance;

    [Signal]
    public delegate void ReputationUpdateEventHandler(int amount);

    public int reputation { get; private set; }

    public override void _Ready()
    {
        if (Instance == null)
        {
            Instance = this;
        } else
        {
            this.QueueFree();
        }
    }

    /// <summary>
    /// Adds reputation equal to amount and invokes reptuation update.
    /// </summary>
    /// <param name="amount">positive or negative integer.</param>
    public void UpdateReputation(int amount)
    {
        reputation += amount;
        EmitSignal(SignalName.ReputationUpdate, amount);
    }

}
