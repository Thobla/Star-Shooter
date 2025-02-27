using Godot;
using System;

public partial class LaserHitBox : Area2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void OnBodyEntered(Node body)
	{
		GD.Print("Body entered");
		if (body is IShootable)
			((IShootable)body).getShot();
			GetParent().QueueFree();
	}
	
}
