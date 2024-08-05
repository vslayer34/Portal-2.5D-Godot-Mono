using Godot;
using System;

public partial class GameSharedEvents : Resource
{
	[Signal]
	/// <summary>
	/// Called when the player press the primary action
	/// </summary>
	public delegate void OnPrimaryActionEventHandler();

	[Signal]
	/// <summary>
	/// Called when the player press the secondary action
	/// </summary>
	public delegate void OnSeconderyActionEventHandler();


	[Signal]
	/// <summary>
	/// Called when the player press the secondary action
	/// </summary>
	public delegate void OnClearActionEventHandler();
}
