using Godot;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public partial class PlayerMovement : CharacterBody2D, IShootable
{
	static float MAX_SPEED = 3000f;

	private float acceleration = 1000f;
	
	private float breakMultiplyer = 2f;


	private Node2D focusPoint;

	private Vector2 facingVector;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		focusPoint = GetNode<Node2D>("FocusPoint");
	}

	public void getShot()
	{
		QueueFree();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		facingVector = GetGlobalPosition().DirectionTo(focusPoint.GlobalPosition).Normalized();
		Move(delta);
		Rotate(delta);	
	}
	
	private async Task kill()
    	{
    		await ToSignal(GetTree(), SceneTree.SignalName.ProcessFrame);
    		QueueFree();
    	}

	private async void Move(double delta)
	{
		if (Input.IsActionPressed("Thrust"))
		{
			Velocity = Velocity.MoveToward(facingVector*MAX_SPEED, (float) delta * acceleration);
		}
	
		var collisionInfo = MoveAndCollide(Velocity * (float) delta);
		if (collisionInfo != null)
		{
			await kill();
		}
	}

	private void Rotate(double delta)
	{
		LookAt(GetGlobalMousePosition());
	}
}
