using Godot;
using System;

public partial class cat : CharacterBody2D
{
	public const float Speed = 150.0f;
	public const float JumpVelocity = -310.0f;
	public const float Acceleration = 10;

	RichTextLabel richTextLabel;
	AnimatedSprite2D animatedSprite2D;

	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

	public override void _Ready()
	{
		richTextLabel = GetNode<RichTextLabel>("text");
		animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor())
			velocity.Y += gravity * (float)delta;

		// Handle Jump.
		if (Input.IsActionJustPressed("ui_accept") && IsOnFloor())
			velocity.Y = JumpVelocity;

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		if (direction != Vector2.Zero)
		{
			velocity.X =  Math.Clamp(velocity.X + direction.X * Acceleration, -Speed, Speed);

		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
		}

		Velocity = velocity;
		MoveAndSlide();
	}

	public override void _Process(double delta)
	{
		richTextLabel.Text = Velocity.X.ToString() + " " + Velocity.Y.ToString();
		if(Velocity.X == 0) {
			animatedSprite2D.Animation = "stay";
			animatedSprite2D.Play();
		}
		else if(Velocity.X > 0) {
			animatedSprite2D.FlipH = true;
			animatedSprite2D.Animation = "walk";
			animatedSprite2D.Play();
		}
		else if(Velocity.X < 0) {
			animatedSprite2D.FlipH = false;
			animatedSprite2D.Animation = "walk";
			animatedSprite2D.Play();
		}
		//if(animatedSprite2D.Animation=="walk") GD.Print("walk");
	}
}
