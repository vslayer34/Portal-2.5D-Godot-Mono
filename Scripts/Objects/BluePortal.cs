using Godot;
using Portal2_5D.Scripts.Characters;
using PortalD2.D.Scripts.Objects;
using System;

namespace Portal2_5D.Scripts.Objects;
public partial class BluePortal : Portal
{
    // Member Methods------------------------------------------------------------------------------
    // Signal Methods------------------------------------------------------------------------------
    protected override void SwapArea_BodyEntered(Node3D body)
    {
        base.SwapArea_BodyEntered(body);
		if (body is EmyController emy)
		{
			GD.Print("Detected player at the orange portal\n");
			if (SharedPool.OrangePortal == null)
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
