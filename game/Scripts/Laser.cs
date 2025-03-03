using Godot;
using System;

public partial class Laser : Node2D, IBullet
{
	private float laser_speed = 1000f;
	private Vector2 rotationVector;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		rotationVector = Vector2.Right.Rotated(Rotation);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Position +=  rotationVector * laser_speed * (float) delta;
	}


	public void Initialize(float rotation, Vector2 position){
		rotationVector = Vector2.Right.Rotated(rotation);
		GlobalPosition = position;
	}
}
