using Godot;
using System;

namespace Portal2_5D.Scripts.UI;
public partial class AimCursor : Node3D
{
	[ExportGroup("Required Nodes")]
	[Export]
	public Sprite3D CursorSprite { get; private set; }

	private Vector2 _mouseGlobalPosition;



    // Game Loop Methods---------------------------------------------------------------------------

    public override void _Input(InputEvent @event)
    {
        var _eventMouse = @event as InputEventMouse;
		_mouseGlobalPosition = _eventMouse.GlobalPosition;
		
		GD.Print(_mouseGlobalPosition);
    }
}
