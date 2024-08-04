using Godot;
using Portal2_5D.Scripts.Helper;
using Portal2_5D.Scripts.Objects;
using Portal2_5D.Scripts.UI;


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

	[Export]
	public Node3D WeaponHoldPoint { get; private set; }

	[Export]
	public PortalGun PortalGun { get; private set; }

	[Export]
	public AimCursor AimCursor { get; private set; }
	[ExportGroup("")]


	[ExportCategory("Character Properties")]
	[Export]
	private float _speed = 10.0f;

	[Export]
	private float _jumpForce = 500.0f;

	
	private const float GRAVITY = -15.0f;

	private Vector2 _mousePosition;


	private MovementDirection _inputDirection;
	private HeadingDirection _currentHeadingDirection = HeadingDirection.Right;
	private HeadingDirection _lastHeadingDirection;
	private Vector3 _velocity;
	private bool _isTurning;



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
			// _currentHeadingDirection = HeadingDirection.Right;
		}

		if (@Input.IsActionPressed(InputMapActionNames.MOVE_LEFT))
		{
			_inputDirection = MovementDirection.Left;
			// _currentHeadingDirection = HeadingDirection.Left;
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

		Input.SetCustomMouseCursor(null, Input.CursorShape.PointingHand);


		// Check if the heading of the character change and fire the signal to rotate its model when the heading change
		// if (_lastHeadingDirection == _currentHeadingDirection)
		// {
		// 	return;
		// }
		// else
		// {
		// 	_lastHeadingDirection = _currentHeadingDirection;
		// 	EmitSignal(SignalName.OnChangeDirection);
		// }
    }


    public override void _PhysicsProcess(double delta)
    {
		// make th gun follow the curser point Follow the cursor
		if (!_isTurning)
		{
			WeaponHoldPoint.LookAt(AimCursor.MouseGlobalPosition, useModelFront: true);
		}
		
		// GD.Print(WeaponHoldPoint.Basis.Z.Z);
		// GD.Print(AimCursor.Basis.Z.Z);

		// Apply gravity to the player
		if (!IsOnFloor())
		{
			_velocity.Y += GRAVITY * (float)delta;
		}
		_velocity.X = (int)_inputDirection * _speed * (float)delta;
		
		Velocity = _velocity;
		

        MoveAndSlide();

		if (WeaponHoldPoint.Basis.Z.Z >= 0)
		{
			// _isTurning = false;
			// _currentHeadingDirection = HeadingDirection.Right;
			return;
		}
		else
		{
			// _isTurning = true;
			_currentHeadingDirection = (_currentHeadingDirection == HeadingDirection.Right) ? HeadingDirection.Left : HeadingDirection.Right;
			EmitSignal(SignalName.OnChangeDirection);

		}
    }


	/// <summary>
	/// Apply jump vector to the velocity vector
	/// </summary>
	private void Jump()
	{
		if (!IsOnFloor())
		{
			return;
		}
		_velocity.Y = _jumpForce * 1;
	}


	/// <summary>
	/// Rotate the character when changing direction
	/// </summary>
	/// <returns></returns>
	private async void RotateCharacter()
	{
		if (_isTurning)
		{
			return;
		}

		_isTurning = true;

		Vector3 currentRotationDegress = Pivot.RotationDegrees;
		float targetRotationAngle = _currentHeadingDirection == HeadingDirection.Right ? 90.0f : -90.0f;
		
		Vector3 targetRotation = new Vector3(Pivot.Rotation.X, targetRotationAngle, Pivot.Rotation.Z);
		float timer = 0.0f;
		float maxTime = 0.2f;

		while (timer < maxTime)
		{
			Pivot.RotationDegrees = currentRotationDegress.Lerp(targetRotation, timer / maxTime);
			WeaponHoldPoint.LookAt(AimCursor.MouseGlobalPosition, useModelFront: true);
			timer += (float)GetProcessDeltaTime();
			
			await ToSignal(GetTree(), SceneTree.SignalName.ProcessFrame);
		}

		Pivot.RotationDegrees = targetRotation;
		_isTurning = false;
	}
}
