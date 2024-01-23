using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Circle : Ellipse
{
	protected override void UpdateShape()
	{
		Scale.y = Scale.x;

		base.UpdateShape();
	}

	public override void Draw(Grid2D grid = null)
	{
		if (_updateShape) UpdateShape();

		base.Draw(grid);
	}
}
