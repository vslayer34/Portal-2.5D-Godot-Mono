using Godot;
using Portal2_5D.Scripts.Helper;
using System;

namespace Portal2_5D.Scripts.Characters;
public partial class EmyController : CharacterBody3D
{
	private Vector3 _inputVector;

    public override void _Input(InputEvent @event)
    {
		_inputVector = Vector3.Zero;

        if (@Input.IsActionPressed(InputMapActionNames.MOVE_RIGHT))
		{
			_inputVector.Z = 1;
		}

		if (@Input.IsActionPressed(InputMapActionNames.MOVE_LEFT))
		{
			_inputVector.Z = -1;
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


    public override void _Process(double delta)
    {
        
    }
}
