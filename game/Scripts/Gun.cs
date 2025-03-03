using Godot;
using System;

public partial class Gun : Node2D
{
	private PackedScene bullet = GD.Load<PackedScene>("res://scenes/laser.tscn");
	private Timer cooldownTimer;
	[Export] private double cooldown = 1;
	private IMain mainScene;
	
	
	[Signal]
	public delegate void ShootEventHandler(Node2D bullet, float rotation, Vector2 position, Vector2 velocity);


	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		innitiallizeCooldown();
		mainScene = (IMain) GetTree().GetCurrentScene();
		// We add the main scenes OnShoot method to our shoot delegate
		Shoot += mainScene.OnShoot;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		shoot();
	}

	private void shoot()
	{
		GD.Print(cooldownTimer.GetTimeLeft(), cooldownTimer.IsStopped());
		if (Input.IsActionPressed("Shoot") && cooldownTimer.IsStopped())
		{
			cooldownTimer.Start();
			var newBullet = bullet.Instantiate();
			EmitSignal(SignalName.Shoot, newBullet, GlobalRotation, GlobalPosition, ((CharacterBody2D) GetParent()).Velocity);
		}
	}

	private void innitiallizeCooldown()
	{
		cooldownTimer = new Timer();
		cooldownTimer.WaitTime = cooldown;
		cooldownTimer.Timeout += OnCooldownReady;
		AddChild(cooldownTimer);
	}

	public void OnCooldownReady()
	{
		GD.Print("Hello");	
		cooldownTimer.Stop();
	}

}
