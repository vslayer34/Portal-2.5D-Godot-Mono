using Godot;
using System;
using System.Collections.Generic;

namespace Portal2_5D.Scripts.Helper;
public partial class SharedPool : Resource
{
	// [Export]
	public List<PortalProjectile> PortalsPool = new List<PortalProjectile>();



	// Member Methods------------------------------------------------------------------------------

	public PortalProjectile GetPortalFromPool()
	{
		GD.Print($"Number of items in the pool: {PortalsPool.Count}");
		return null;
	}
}
