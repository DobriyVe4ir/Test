using Godot;
using System;

public partial class killzone : Area2D
{
	
	
	
	private void _on_body_entered(Node2D body)
	{
		Timer timer = GetNode<Timer>("Timer");
		timer.Start();
	}
	
		private void _on_timer_timeout()
	{
		GetTree().ReloadCurrentScene();
	}
	
}





