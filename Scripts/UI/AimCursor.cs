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
		Input.MouseMode = Input.MouseModeEnum.Hidden;
        Camera = SharedResources.Camera;
    }

    public override void _Input(InputEvent @event)
    {
		if (@event is InputEventMouse eventMouse)
		{
			_mouseScreenPosition = eventMouse.GlobalPosition;
		}
		
		// CursorGroup.Position = MouseGlobalPosition;

		Position = Camera.ProjectPosition(_mouseScreenPosition, Camera.Position.Z - 1);

		// GD.Print(_mouseScreenPosition);
		GD.Print(CursorGroup.Position);
    }

	// Getters and Setters-------------------------------------------------------------------------

	public Vector3 MouseGlobalPosition { get => Position; }
}
