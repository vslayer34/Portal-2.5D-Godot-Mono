using Godot;
using Portal2_5D.Scripts.Helper;
using System;
using System.Reflection;

namespace Portal2_5D.Scripts.Characters;
public partial class EmyController : CharacterBody3D
{
	[Signal]
	public delegate void OnJumpPressedEventHandler();

	enum MovementDirection
	{
		None = 0,
		Right = 1,
		Left = -1
	}


	[ExportCategory("Character Properties")]
	[Export]
	private float _speed = 10.0f;

	[Export]
	private float _jumpForce = 500.0f;

	private const float GRAVITY = -9.8f;


	private MovementDirection _inputDirection;
	private Vector3 _velocity;



    // Game Loop Methods---------------------------------------------------------------------------

    public override void _Ready()
    {
		OnJumpPressed += Jump;
    }

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
			EmitSignal(SignalName.OnJumpPressed);
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
		if (!IsOnFloor())
		{
			_velocity.Y += GRAVITY * (float)delta;
		}
		// _velocity = new Vector3(0.0f, 0.0f, (int)_inputDirection * _speed * (float)delta);
		_velocity.Z = (int)_inputDirection * _speed * (float)delta;
		GD.Print(_velocity);
		
		
		Velocity = _velocity;
		

        MoveAndSlide();
    }


	private void Jump()
	{
		if (!IsOnFloor())
		{
			return;
		}
		_velocity.Y = _jumpForce * 1;
		// GD.Print(_movementDirection);
		GD.Print(Velocity);

	}
}
