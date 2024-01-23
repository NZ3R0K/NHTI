using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Drawing.Glint;

[System.Serializable]
public class Grid2D
{
	public Vector3 screenSize = Vector3.zero;

	/// <summary> How many pixels on the screen will be converted to one unit in gridspace. </summary>
	public int gridSize = 10;

	public Vector3 originOffset;

	/// <summary>
	/// Convert a point that is in screen space to a point in grid space.
	/// </summary>
	/// <param name="screenSpace">The point in screen space.</param>
	/// <returns>A point in grid space.</returns>
	public Vector3 ScreenToGrid(Vector3 screenSpace)
	{
		//Subtract center screen from the given point and divide the value by the grids size
		return new Vector3(ScaleScreenToGrid(screenSpace.x - (screenSize.x / 2)), ScaleScreenToGrid(screenSpace.y - (screenSize.y / 2)));
	}

	/// <summary>
	/// Convert a point that is in grid space to a point in screen space.
	/// </summary>
	/// <param name="gridSpace">The point in grid space.</param>
	/// <returns>A point in screen space.</returns>
	public Vector3 GridToScreen(Vector3 gridSpace)
	{
		//Add the gridSpace multiplied by its size to the center of the screen
		return new Vector3((screenSize.x / 2) + ScaleGridToScreen(gridSpace.x), (screenSize.y / 2) + ScaleGridToScreen(gridSpace.y));
	}

	/// <summary>
	/// Convert a float that is in grid space to a float that is in screen space.
	/// </summary>
	/// <param name="grid">The value in grid space.</param>
	/// <returns>A float in screen space.</returns>
	public float ScaleGridToScreen(float grid)
	{
		return (grid * gridSize);
	}

	/// <summary>
	/// Convert a float that is in screen space to a float that is in grid space.
	/// </summary>
	/// <param name="screen">The value in screen space.</param>
	/// <returns>A float in grid space.</returns>
	public float ScaleScreenToGrid(float screen)
	{
		return (screen / gridSize);
	}

	public void DrawLine(Line line, bool DrawOnGrid = true)
	{
		//line.Draw();
		//return;

		if (DrawOnGrid)
		{
			line.start = GridToScreen(line.start + originOffset);

			line.end = GridToScreen(line.end + originOffset);

			Glint.AddCommand(line);
		}
		else Glint.AddCommand(line);
	}
}
