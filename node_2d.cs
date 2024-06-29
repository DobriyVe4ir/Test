using Godot;
using System;

public partial class node_2d : Node2D
{
	// Called when the node enters the scene tree for the first time.
	
	PackedScene cat;
	//dwaw
	
	public override void _Ready()
	{
		cat = (PackedScene)GD.Load("res://cat.tscn");
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

	}

	public override void _UnhandledInput(InputEvent @event)
	{
		if (@event is InputEventMouseButton mouseButton)
		{
			AnimatedSprite2D Sprite2D = (AnimatedSprite2D)cat.Instantiate();
			

			Sprite2D.Position = mouseButton.Position;
			Sprite2D.Set("set_animation", "walk");
			Sprite2D.Play();
			GD.Print("Animation " + Sprite2D.Animation);
			GD.Print("Frame " + Sprite2D.Frame);
			AddChild(Sprite2D);
		}
	}
}
