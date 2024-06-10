using Godot;
using PortalD2.D.Scripts.Helper;
using System;

namespace Portal2_5D.Scripts.UI;
public partial class AimCursor : Node3D
{
	[ExportGroup("Required Nodes")]
	[Export]
	public Sprite3D CursorSprite { get; private set; }

	[Export]
	public Node3D CursorGroup { get; private set; }

	[Export]
	public Camera3D Camera { get; private set; }

	[Export]
	public GameSharedResources SharedResources { get; private set; }

	private Vector2 _mouseScreenPosition;



    // Game Loop Methods---------------------------------------------------------------------------\

    public override void _EnterTree()
    {
        Camera = SharedResources.Camera;
    }

    public override void _Input(InputEvent @event)
    {
		if (@event is InputEventMouse eventMouse)
		{
			_mouseScreenPosition = eventMouse.GlobalPosition;
		}
		
		// CursorGroup.Position = MouseGlobalPosition;

		CursorGroup.Position = Camera.ProjectPosition(_mouseScreenPosition, Camera.Position.X);

		// GD.Print(_mouseScreenPosition);
		GD.Print(CursorGroup.Position);
    }

	// Getters and Setters-------------------------------------------------------------------------

	public Vector3 MouseGlobalPosition
	{
		get
		{
			return new Vector3(_mouseScreenPosition.X, _mouseScreenPosition.Y, 0.0f);
		}
	}
}
