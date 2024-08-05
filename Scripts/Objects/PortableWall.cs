using Godot;
using System;

namespace Portal2_5D.Scripts.Objects;
public partial class PortableWall : StaticBody3D, IPortableWall
{
	[ExportGroup("Required")]
	[Export]
	public Node3D PortalParent { get; private set; }



	// Game Loop Methods---------------------------------------------------------------------------
}
