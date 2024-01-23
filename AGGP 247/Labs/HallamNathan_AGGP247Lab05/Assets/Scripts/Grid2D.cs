using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Grid2D
{
	public Vector3 screenSize;
	public Vector3 origin;

	public float gridSize = 10;
	public float minGridSize = 2f;
	public float originSize = 20f;

	public int divisionCount = 5;
	public int minDivisionCount = 2;

	public Vector3 originOffset;
	public Vector3 gridEdge;

	public void DrawLine(Line line, bool DrawOnGrid = true)
	{
		//line.Draw();
		//return;

		if (DrawOnGrid)
		{
			line.start.x *= gridSize;
			line.start.y *= gridSize;
			line.start.z *= gridSize;

			line.start += screenSize / 2;

			line.start += originOffset;

			line.end.x *= gridSize;
			line.end.y *= gridSize;
			line.end.z *= gridSize;

			line.end += screenSize / 2;

			line.end += originOffset;


			Glint.AddCommand(line);
		}
		else
		{
			line.Draw();
		}
	}

	public void DrawObject(DrawingObject lineObj, bool DrawOnGrid = true)
	{
		if (DrawOnGrid)
		{
			lineObj.Draw(this);
		}
		else
		{
			lineObj.Draw();
		}
	}

	public float ScaleGrid2Screen(float value)
	{
		return (value * gridSize);
	}

	public float ScaleScreen2Grid(float value)
	{
		return (value / gridSize);
	}

	public Vector3 GridToScreen(Vector3 gridSpace)
	{
		//Add the gridSpace multiplied by its size to the center of the screen
		return new Vector3((Screen.width / 2) + (gridSpace.x * gridSize), (Screen.height / 2) + (gridSpace.y * gridSize));
	}

	//Takes in screen space and outputs it as grid space
	public Vector3 ScreenToGrid(Vector3 screenSpace)
	{
		//Subtract center screen from the given point and divide the value by the grids size
		return new Vector3((screenSpace.x - (Screen.width / 2)) / gridSize, (screenSpace.y - (Screen.height / 2)) / gridSize);
	}
}