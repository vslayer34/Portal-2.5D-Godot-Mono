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



    // Game Loop Methods---------------------------------------------------------------------------

    public override void _EnterTree()
    {
        SharedResources.Camera = Camera;
        SharedResources.GameManager = this;
    }
}
