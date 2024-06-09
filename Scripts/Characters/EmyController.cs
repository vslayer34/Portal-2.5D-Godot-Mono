using Godot;
using Portal2_5D.Scripts.Helper;
using System;

namespace Portal2_5D.Scripts.Characters;
public partial class EmyController : CharacterBody3D
{
	enum MovementDirection
	{
		None = 0,
		Right = 1,
		Left = -1
	}
	

	[ExportCategory("Character Properties")]
	[Export]
	private float _speed = 10.0f;


	private MovementDirection _inputDirection;
	private Vector3 _movementDirection;

    public override void _Input(InputEvent @event)
    {
		_inputDirection = MovementDirection.None;

        if (@Input.IsActionPressed(InputMapActionNames.MOVE_RIGHT))
		{
			_inputDirection = MovementDirection.Right;
		}

		if (@Input.IsActionPressed(InputMapActionNames.MOVE_LEFT))
		{
			_inputDirection = MovementDirection.Left;
		}

		if (Input.IsActionJustPressed(InputMapActionNames.JUMP))
		{
			GD.Print("jump is pressed");
		}

		if (Input.IsActionJustPressed(InputMapActionNames.PRIMARY_FIRE))
		{
			GD.Print("primary attack is pressed");
		}

		if (Input.IsActionJustPressed(InputMapActionNames.SECONDARY_FIRE))
		{
			GD.Print("secondary attack is pressed");
		}
    }


    public override void _PhysicsProcess(double delta)
    {
		_movementDirection = new Vector3(0.0f, Velocity.Y, (int)_inputDirection * _speed * (float)delta);
		Velocity = _movementDirection;

        MoveAndSlide();
    }
}
