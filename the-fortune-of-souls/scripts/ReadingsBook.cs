using Godot;
using System;

public partial class ReadingsBook : Control
{
	Sprite2D leftPage;
	Sprite2D rightPage;
	RichTextLabel leftText;
	RichTextLabel rightText;
	
	BaseButton nextButton;
	BaseButton prevButton;

	int pageNumber;


	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GD.Print("ReadingsBook started!");

		// Init book to the first page:
		pageNumber = 0;
		leftPage = GetNode<Sprite2D>("Panel/LeftPage");
		leftText = GetNode<RichTextLabel>("Panel/LeftText");
		nextButton = GetNode<BaseButton>("Panel/NextPageButton");

		if (leftText == null)
		{
			throw new NullReferenceException("Cannot access child node!");
		}
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (nextButton.ButtonPressed)
		{
			leftText.Text = "next press";
			leftPage.Texture = (Texture2D)GD.Load("res://art/programmer/crystalball/ballsymbol2.png");
		}
	}
}
