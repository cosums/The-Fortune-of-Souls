using Godot;
using System;
using System.Collections;
using System.Reflection;

public partial class ReadingsBook : Control
{
	BaseButton bookOpen;
	Panel bookPanel;

	Sprite2D leftPage;
	Sprite2D rightPage;
	RichTextLabel leftText;
	RichTextLabel rightText;
	
	BaseButton nextButton;
	BaseButton prevButton;

	int pageNumber;
	const int TOTAL_PAGES = 1;

	ArrayList leftPages = new ArrayList();
	ArrayList rightPages = new ArrayList();


	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GD.Print("ReadingsBook started!");

		bookOpen = GetNode<BaseButton>("BookButton");
		bookPanel = GetNode<Panel>("Panel");

		// Init book to the first page:
		pageNumber = 0;

		// Load all pages to list
			leftPages.Add((Texture2D)GD.Load("res://art/programmer/crystalball/ballsymbol1.png"));
			leftPages.Add((Texture2D)GD.Load("res://art/programmer/crystalball/ballsymbol2.png"));

			rightPages.Add((Texture2D)GD.Load("res://art/programmer/crystalball/ballsymbol2.png"));
			rightPages.Add((Texture2D)GD.Load("res://art/programmer/crystalball/ballsymbol1.png"));

		// init right page
		leftPage = GetNode<Sprite2D>("Panel/LeftPage");
		rightPage = GetNode<Sprite2D>("Panel/RightPage");

		// init right text
		leftText = GetNode<RichTextLabel>("Panel/LeftText");
		rightText = GetNode<RichTextLabel>("Panel/RightText");

		nextButton = GetNode<BaseButton>("Panel/NextPageButton");
		prevButton = GetNode<BaseButton>("Panel/PrevPageButton");

		if (leftPage == null || leftText == null || nextButton == null)
		{
			GD.Print("Error loading node!");
			throw new NullReferenceException("Cannot access child node!");
		}
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		// Reset buttons
		bookOpen.Disabled = false;
		nextButton.Disabled = false;
		prevButton.Disabled = false;

		if (bookOpen.ButtonPressed)
		{
			bookOpen.Disabled = true;

			// toggle visibility
			bookPanel.Visible = !bookPanel.Visible;
		}


		if (nextButton.ButtonPressed)
		{
			nextButton.Disabled = true;
			pageNumber++;

			if (pageNumber > TOTAL_PAGES)
			{
				pageNumber = 0; // loop back around
			}
		
			leftText.Text = "Page: " + (pageNumber + 1);
			rightText.Text = "Page: " + (pageNumber + 1);

			leftPage.Texture = (Texture2D)leftPages[pageNumber];
			rightPage.Texture = (Texture2D)rightPages[pageNumber];
		}

		if (prevButton.ButtonPressed)
		{
			prevButton.Disabled = true;
			pageNumber--;

			if (pageNumber < 0)
			{
				pageNumber = TOTAL_PAGES; // loop back around
			}

			leftText.Text = "Page: " + (pageNumber + 1);
			rightText.Text = "Page: " + (pageNumber + 1);

			leftPage.Texture = (Texture2D)leftPages[pageNumber];
			rightPage.Texture = (Texture2D)rightPages[pageNumber];
		}
	}
}
