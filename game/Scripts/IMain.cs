using Godot;
using System;

public interface IMain
{
    public void OnShoot(Node2D bullet, float rotation, Vector2 direction);
}
