using Godot;
using System;

public partial class Main : Node2D, IMain
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	public void OnShoot(Node2D bullet, float rotation, Vector2 position, Vector2 velocity)
	{
		AddChild(bullet);
		((IBullet)bullet).Initialize(rotation, position, velocity);
	}

}
