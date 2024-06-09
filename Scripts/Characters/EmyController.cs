using Godot;
using Portal2_5D.Scripts.Helper;
using System;

namespace Portal2_5D.Scripts.Characters;
public partial class EmyController : CharacterBody3D
{
	[Signal]
	public delegate void OnJumpPressedEventHandler();

	[Signal]
	public delegate void OnChangeDirectionEventHandler();

	enum MovementDirection
	{
		None = 0,
		Right = 1,
		Left = -1
	}

	enum HeadingDirection
	{
		Right,
		Left
	}

	[ExportGroup("Required Nodes")]
	[Export]
	public Node3D Pivot { get; private set; }
	[ExportGroup("")]


	[ExportCategory("Character Properties")]
	[Export]
	private float _speed = 10.0f;

	[Export]
	private float _jumpForce = 500.0f;

	
	private const float GRAVITY = -15.0f;


	private MovementDirection _inputDirection;
	private HeadingDirection _currentHeadingDirection = HeadingDirection.Right;
	private HeadingDirection _lastHeadingDirection;
	private Vector3 _velocity;



    // Game Loop Methods---------------------------------------------------------------------------

    public override void _Ready()
    {
		OnJumpPressed += Jump;
		OnChangeDirection += RotateCharacter;
    }

    public override void _Input(InputEvent @event)
    {
		_inputDirection = MovementDirection.None;

        if (@Input.IsActionPressed(InputMapActionNames.MOVE_RIGHT))
		{
			_inputDirection = MovementDirection.Right;
			_currentHeadingDirection = HeadingDirection.Right;
		}

		if (@Input.IsActionPressed(InputMapActionNames.MOVE_LEFT))
		{
			_inputDirection = MovementDirection.Left;
			_currentHeadingDirection = HeadingDirection.Left;
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

		if (_lastHeadingDirection == _currentHeadingDirection)
		{
			return;
		}
		else
		{
			_lastHeadingDirection = _currentHeadingDirection;
			EmitSignal(SignalName.OnChangeDirection);
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
		// GD.Print(_velocity);
		
		
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
		// GD.Print(Velocity);
	}


	private async void RotateCharacter()
	{
		Vector3 currentRotationDegress = Pivot.RotationDegrees;
		float targetRotationAngle = _currentHeadingDirection == HeadingDirection.Right ? 0.0f : -180.0f;
		
		Vector3 targetRotation = new Vector3(Pivot.Rotation.X, targetRotationAngle, Pivot.Rotation.Z);
		float timer = 0.0f;
		float maxTime = 0.5f;

		while (timer < maxTime)
		{
			Pivot.RotationDegrees = currentRotationDegress.Lerp(targetRotation, timer / maxTime);
			timer += (float)GetProcessDeltaTime();
			
			await ToSignal(GetTree(), SceneTree.SignalName.ProcessFrame);
		}

		Pivot.RotationDegrees = targetRotation;
	}
}
