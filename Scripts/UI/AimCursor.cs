using Godot;
using Portal2_5D.Scripts.Helper;
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
	private Vector3 _mouseGlobalPosition;

	// The offset so the cursor doesn't go through teh character model
	private float _cursorOffset;



    // Game Loop Methods---------------------------------------------------------------------------\

    public override void _EnterTree()
    {
		// Hide the mouse cursor and get reference to the camera
		Input.MouseMode = Input.MouseModeEnum.Hidden;
        Camera = SharedResources.Camera;
    }

    public override void _Input(InputEvent @event)
    {
		// Get the mouse position and converted it to global position in the world
		if (@event is InputEventMouse eventMouse)
		{
			_mouseScreenPosition = eventMouse.GlobalPosition;
		}

		_mouseGlobalPosition = Camera.ProjectPosition(_mouseScreenPosition, Camera.Position.Z - _cursorOffset);

		Position = _mouseGlobalPosition;
    }

	// Getters and Setters-------------------------------------------------------------------------

	/// <summary>
	/// Return the cursor position after removing the offset
	/// </summary>
	public Vector3 MouseGlobalPosition
	{
		get
		{
			_mouseGlobalPosition.Z += _cursorOffset;
			return _mouseGlobalPosition;
		}
	}
}
