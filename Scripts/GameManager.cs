using Godot;
using Portal2_5D.Scripts.Helper;
using System;

public enum PortalType
{
    Orange,
    Blue
}
public partial class GameManager : Node3D
{
	[ExportGroup("Required Nodes")]
	[Export]
	public Camera3D Camera { get; private set; }

	[Export]
	public GameSharedResources SharedResources { get; private set; }

    [Export]
	public GameSharedEvents SharedEvents { get; private set; }

    [Export]
    public SharedPool SharedPool { get; private set; }



    // Game Loop Methods---------------------------------------------------------------------------

    public override void _EnterTree()
    {
        SharedResources.Camera = Camera;
        SharedResources.GameManager = this;
    }

    public override void _Ready()
    {
        SharedEvents.OnClearAction += SharedEvents_OnClearAction;
    }

    public override void _ExitTree()
    {
        SharedEvents.OnClearAction -= SharedEvents_OnClearAction;
    }

    // Signal Methods------------------------------------------------------------------------------

    private void SharedEvents_OnClearAction()
    {
        SharedPool.DisablePortals();
    }
}
