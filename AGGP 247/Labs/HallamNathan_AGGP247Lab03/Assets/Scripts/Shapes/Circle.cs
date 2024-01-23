using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : Ellipse
{
	public Circle() : base()
	{

	}

	public override void Draw(Grid2D grid = null)
	{
		Axis.x = Width / 2;
		Axis.y = Width / 2;

		base.Draw(grid);
	}
}
