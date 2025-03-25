using Godot;
using System;
using System.Threading.Tasks;

public partial class Enemy : CharacterBody2D, IShootable
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	public async void getShot()
	{
		await kill();
	}
	
	private async Task kill()
	{
		await ToSignal(GetTree(), SceneTree.SignalName.ProcessFrame);
		QueueFree();
	}
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		var collision = MoveAndCollide(Velocity * (float)delta);
		if (collision != null)
		{
			Velocity = Velocity.Bounce(collision.GetNormal());
		}
	}
}
