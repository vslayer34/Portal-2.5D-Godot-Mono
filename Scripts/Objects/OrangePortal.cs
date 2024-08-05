using Godot;
using Portal2_5D.Scripts.Characters;
using PortalD2.D.Scripts.Objects;
using System;

namespace Portal2_5D.Scripts.Objects;
public partial class OrangePortal : Portal
{
	// Member Methods------------------------------------------------------------------------------
    // Signal Methods------------------------------------------------------------------------------
	protected override void SwapArea_BodyEntered(Node3D body)
    {
        base.SwapArea_BodyEntered(body);
		if (body is EmyController emy)
		{
			GD.Print("Detected player at the blue portal\n");
			if (SharedPool.BluePortal == null)
			{
				GD.PushWarning("Can't teleport into nothing");
			}
			else
			{
				GD.Print("Can teleport safely");
			}
		}
    }
}
