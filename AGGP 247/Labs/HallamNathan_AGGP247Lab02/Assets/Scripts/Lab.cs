using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Lab : MonoBehaviour
{
	public class Grid2D
	{
		public Vector3 screenSize;
		public Vector3 origin;

		public float gridSize = 10; //Was private
		public float minGridSize = 2f;  //Was private
		public float originSize = 20f;

		public int divisionCount = 5;      //Was private
		public int minDivisionCount = 2;   //Was private

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
				//lineObj.Draw(this);
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

	}

	public Color axisColor = Color.white;
	public Color lineColor = Color.gray;
	public Color divisionColor = Color.yellow;
	public Color originColor = Color.green;

	public bool isDrawingOrigin = false;
	public bool isDrawingAxis = true;
	public bool isDrawingDivisions = true;
	public bool isDrawingShapes = true;
	public bool isDrawingParabolas = true;

	Grid2D grid = new Grid2D();

	public Grid2D getGrid
	{
		get { return grid; }
	}

	LineDraw.Arrow test = new LineDraw.Arrow();
	private void Start()
	{
		grid.origin = new Vector3(Screen.width / 2, Screen.height / 2);

		test.Initalize();
	}

	void Update()
	{
		if (isDrawingShapes)
		{
			DrawSpinningDiamond();

			DrawHexagon(6);

			grid.DrawObject(test);
		}

		#region Draw Origin
		grid.screenSize = new Vector3(Screen.width, Screen.height);
		grid.originOffset = new Vector3(grid.origin.x - (grid.screenSize.x / 2), grid.origin.y - (grid.screenSize.y / 2));
		grid.gridEdge = new Vector3(Mathf.FloorToInt((grid.screenSize.x / 2) / grid.gridSize), Mathf.FloorToInt((grid.screenSize.y / 2) / grid.gridSize));

		if (isDrawingOrigin)
		{
			DrawOrigin();
		}
		#endregion Draw Origin

		int divisionStepCount = 0;

		#region Vertical Lines
		for (float i = (grid.origin.x % grid.gridSize); i < Screen.width; i += grid.gridSize)
		{
			if (isDrawingAxis && i == grid.origin.x)
			{
				DrawLine(new Line(new Vector3(i, 0), new Vector3(i, Screen.width), axisColor));

				divisionStepCount++;
			}
			else if (isDrawingDivisions && (grid.origin.x % (grid.divisionCount * grid.gridSize)) + (divisionStepCount * (grid.divisionCount * grid.gridSize)) == i)
			{
				DrawLine(new Line(new Vector3(i, 0), new Vector3(i, Screen.width), divisionColor));

				divisionStepCount++;
			}
			else
			{
				DrawLine(new Line(new Vector3(i, 0), new Vector3(i, Screen.width), lineColor));
			}
		}
		#endregion Vertical Lines

		divisionStepCount = 0;

		#region Horizontal Lines
		for (float i = (grid.origin.y % grid.gridSize); i < Screen.width; i += grid.gridSize)
		{
			if (isDrawingAxis && i == grid.origin.y)
			{
				DrawLine(new Line(new Vector3(0, i), new Vector3(Screen.width, i), axisColor));

				divisionStepCount++;
			}
			else if (isDrawingDivisions && (grid.origin.y % (grid.divisionCount * grid.gridSize)) + (divisionStepCount * (grid.divisionCount * grid.gridSize)) == i)
			{
				DrawLine(new Line(new Vector3(0, i), new Vector3(Screen.width, i), divisionColor));

				divisionStepCount++;
			}
			else
			{
				DrawLine(new Line(new Vector3(0, i), new Vector3(Screen.width, i), lineColor));
			}
		}
		#endregion Horizontal Lines

		if (isDrawingParabolas)
		{
			//x^2
			DrawParabola(1, 0, 0, false, Color.blue);
			//	x^2 + 2x+ 1
			DrawParabola(1, 2, 1, false, Color.green);
			//  -2x ^ 2 + 10x + 12
			DrawParabola(-2, 10, 12, false, Color.red);
			//  -y ^ 3
			DrawParabola(-1, 0, 0, true, Color.magenta);
		}
	}

	//Takes the potential grid space and outputs it into screen space
	public Vector3 GridToScreen(Vector3 gridSpace)
	{
		//Add the gridSpace multiplied by its size to the center of the screen
		return new Vector3((Screen.width / 2) + (gridSpace.x * grid.gridSize), (Screen.height / 2) + (gridSpace.y * grid.gridSize));
	}

	//Takes in screen space and outputs it as grid space
	public Vector3 ScreenToGrid(Vector3 screenSpace)
	{
		//Subtract center screen from the given point and divide the value by the grids size
		return new Vector3((screenSpace.x - (Screen.width / 2)) / grid.gridSize, (screenSpace.y - (Screen.height / 2)) / grid.gridSize);
	}

	//Draws the given line
	public void DrawLine(Line line)
	{
		Glint.AddCommand(line);
	}

	Vector3[] verticies = new Vector3[4];
	[HideInInspector] public bool initializeOriginPoints = false;

	//Draws the Origin Point (or Symbol)
	public void DrawOrigin()
	{
		if (!initializeOriginPoints)
		{
			verticies[0] = new Vector3(grid.origin.x, grid.origin.y + grid.originSize);
			verticies[1] = new Vector3(grid.origin.x + grid.originSize, grid.origin.y);
			verticies[2] = new Vector3(grid.origin.x, grid.origin.y - grid.originSize);
			verticies[3] = new Vector3(grid.origin.x - grid.originSize, grid.origin.y);
			initializeOriginPoints = true;
		}

		Drawing.Glint.GLCommand quad = new Drawing.Glint.GLCommand(Drawing.Glint.DrawMode.Quads, originColor, verticies);

		Glint.AddCommand(quad);
	}

	DrawingObject spinDiamond = new DrawingObject();
	Vector3 spinDiamondCenter;
	[HideInInspector] public bool initializeSpinningDiamond = false;
	void DrawSpinningDiamond(float width = 2, float distanceFromOrigin = 7.5f, float rotationTime = 5)
	{
		float rotationSpeed = 360 / rotationTime;

		if (!initializeSpinningDiamond)
		{
			//Set object center position
			spinDiamondCenter = new Vector3(grid.origin.x, grid.origin.y + (distanceFromOrigin * grid.gridSize));
			//Retrieve current rotation
			spinDiamondCenter = DrawingTools.RotatePoint(grid.origin, spinDiamond.Rotation, spinDiamondCenter);
			initializeSpinningDiamond = true;
		}
		else
		{
			//Rotate center point
			spinDiamondCenter = DrawingTools.RotatePoint(grid.origin, Time.deltaTime * rotationSpeed, spinDiamondCenter);

			spinDiamond.Lines.Clear();

			spinDiamond.Lines.Add(new Line(
				new Vector3(spinDiamondCenter.x, spinDiamondCenter.y + (width / 2 * grid.gridSize)),
				new Vector3(spinDiamondCenter.x + (width / 2 * grid.gridSize), spinDiamondCenter.y),
				Color.white));

			spinDiamond.Lines.Add(new Line(
				new Vector3(spinDiamondCenter.x + (width / 2 * grid.gridSize), spinDiamondCenter.y),
				new Vector3(spinDiamondCenter.x, spinDiamondCenter.y - (width / 2 * grid.gridSize)),
				Color.white));

			spinDiamond.Lines.Add(new Line(
				new Vector3(spinDiamondCenter.x, spinDiamondCenter.y - (width / 2 * grid.gridSize)),
				new Vector3(spinDiamondCenter.x - (width / 2 * grid.gridSize), spinDiamondCenter.y),
				Color.white));

			spinDiamond.Lines.Add(new Line(
				new Vector3(spinDiamondCenter.x - (width / 2 * grid.gridSize), spinDiamondCenter.y),
				new Vector3(spinDiamondCenter.x, spinDiamondCenter.y + (width / 2 * grid.gridSize)),
				Color.white));

			//Update objects rotation and save it, is always between 0 and 360
			spinDiamond.Rotation = (spinDiamond.Rotation >= 360) ? (spinDiamond.Rotation -= 360) : (spinDiamond.Rotation += rotationSpeed * Time.deltaTime);
		}

		spinDiamond.Draw();
	}

	DrawingObject hexagon = new DrawingObject();
	Vector3 hexagonVertexPlacer;
	void DrawHexagon(float width)
	{
		hexagonVertexPlacer = new Vector3(grid.origin.x, grid.origin.y + ((width / 2) * grid.gridSize));
		hexagonVertexPlacer = DrawingTools.RotatePoint(grid.origin, 30, hexagonVertexPlacer);

		hexagon.Lines.Clear();

		for (int i = 0; i < 6; i++)
		{
			Vector3 Start = new Vector3(hexagonVertexPlacer.x, hexagonVertexPlacer.y);

			hexagonVertexPlacer = DrawingTools.RotatePoint(grid.origin, 60, hexagonVertexPlacer);

			Vector3 End = new Vector3(hexagonVertexPlacer.x, hexagonVertexPlacer.y);

			hexagon.Lines.Add(new Line(Start, End, Color.white));
		}

		hexagon.Draw();

	}

	DrawingObject Parabola = new DrawingObject();
	//y = ax^2+ bx + c 
	public void DrawParabola(float a = 0, float b = 0, float c = 0, bool yAxis = false, Color? color = null)
	{
		if (!color.HasValue)
			color = Color.white;

		Parabola.Lines.Clear();

		if (!yAxis)
		{
			for (float x = -grid.gridEdge.x; x < grid.gridEdge.x; x++)
			{
				Vector3 Start = new Vector3(x, (a * Mathf.Pow(x, 2)) + (b * x) + c);

				Vector3 End = new Vector3(x + 1, (a * Mathf.Pow(x + 1, 2)) + (b * (x + 1)) + c);

				Parabola.Lines.Add(new Line(Start, End, color.Value));
			}

			grid.DrawObject(Parabola, true);
		}
		else
		{
			for (float y = -grid.gridEdge.y; y < grid.gridEdge.y; y++)
			{
				Vector3 Start = new Vector3(a * Mathf.Pow(y, 3), y);

				Vector3 End = new Vector3(a * Mathf.Pow(y + 1, 3), y + 1);

				Parabola.Lines.Add(new Line(Start, End, color.Value));
			}

			grid.DrawObject(Parabola, true);
		}
	}
}