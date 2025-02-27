using Godot;
using System;

public partial class Asteroid : CharacterBody2D
{
	private const float MAX_SPEED = 350f;
	private const float MIN_SPEED = 50f;
	private float speed = GD.RandRange(250, 750);

	private Vector2 directionVector;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		directionVector = Vector2.Right.Rotated((float)GD.RandRange(0, 2 * Math.PI)).Normalized();
		Velocity = directionVector * MAX_SPEED;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		GD.Print("Velocity: ", Velocity);
		MoveAndCollide(Velocity * (float) delta);
	}
}
