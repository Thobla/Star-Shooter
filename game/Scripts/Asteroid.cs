using Godot;
using System;
using System.Threading.Tasks;

public partial class Asteroid : CharacterBody2D, IShootable
{
	private const float MAX_SPEED = 350f;
	private const float MIN_SPEED = 50f;
	private float speed = GD.RandRange(250, 750);

	private Vector2 directionVector;

	private CharacterBody2D player;


	public void getShot()
	{
		GD.Print("Got shot");
		kill();
	}
	private async Task kill()
	{
		await ToSignal(GetTree(), SceneTree.SignalName.ProcessFrame);
		QueueFree();
	}
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		directionVector = Vector2.Right.Rotated((float)GD.RandRange(0, 2 * Math.PI)).Normalized();
		Velocity = directionVector * MAX_SPEED;
		player = (CharacterBody2D) GetTree().GetNodesInGroup("Player")[0];
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		var collisionInfo = MoveAndCollide(Velocity * (float)delta);
		if (collisionInfo == null) return;
		if (GetTree().GetNodesInGroup("Player").Contains((Node)collisionInfo.GetCollider()))
		{
			player.QueueFree();
		}
		QueueFree();
	}
}
