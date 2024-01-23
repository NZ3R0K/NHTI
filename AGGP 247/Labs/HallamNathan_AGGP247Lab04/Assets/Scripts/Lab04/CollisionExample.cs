using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Drawing.Glint;

public class CollisionExample : MonoBehaviour
{
	#region Variables
		public Grid2D grid = new Grid2D();
		bool initializeOriginPoints = false;
	
		#region Drawing What?
			[Header("Drawing What?")]
			public bool isDrawingOrigin = true;
			public bool isDrawingGrid = true;
			public bool isDrawingAxis = true;
			public bool isDrawingDivisions = true;
			public bool isDrawingRectangle = false;
			public bool isDrawingCircle = false;
			public bool isDrawingTriangle = false;
		#endregion Drawing What?

		#region Color
			[Header("COLORS")]
			public Color axisColor = Color.white;
			public Color lineColor = Color.gray;
			public Color divisionColor = Color.yellow;
			public Color originColor = Color.green;
		#endregion Color

		#region Shapes
			[Header("Shapes")]
			public Vector3 thePoint;
			public CollisionShape rectangle;
			public CollisionCircle circle;
			public CollisionShape triangle;
		#endregion Shapes

	#endregion Variables

	#region Methods
		#region Unity
			void Start()
				{
					grid.origin = new Vector3(Screen.width / 2, Screen.height / 2);
				}

			void Update()
			{
				DrawGrid();
				DrawOrigin();
				DrawPoint();
				DrawRectangle();
				DrawCircle();
				DrawTriangle();
			}
		#endregion Unity

		#region Grid
			//Draws the given line
			public void DrawLine(Line line, bool gridSpace = false)
			{
				if (gridSpace)
				{
					line.start = grid.GridToScreen(line.start);
					line.end = grid.GridToScreen(line.end);
				}

				Glint.AddCommand(line);
			}

			List<Vector3> originVerticies = new List<Vector3>();
			GLCommand originCommand;
			void DrawOrigin()
			{
				grid.screenSize = new Vector3(Screen.width, Screen.height);
				grid.originOffset = new Vector3(grid.origin.x - (grid.screenSize.x / 2), grid.origin.y - (grid.screenSize.y / 2));
				grid.gridEdge = new Vector3(Mathf.FloorToInt((grid.screenSize.x / 2) / grid.gridSize), Mathf.FloorToInt((grid.screenSize.y / 2) / grid.gridSize));

				if (!isDrawingOrigin) return;

				if (!initializeOriginPoints)
				{
					originVerticies.Clear();
					originVerticies.Add(new Vector3(grid.origin.x, grid.origin.y + grid.originSize));
					originVerticies.Add(new Vector3(grid.origin.x + grid.originSize, grid.origin.y));
					originVerticies.Add(new Vector3(grid.origin.x, grid.origin.y - grid.originSize));
					originVerticies.Add(new Vector3(grid.origin.x - grid.originSize, grid.origin.y));
					initializeOriginPoints = true;

					originCommand = new GLCommand(DrawMode.Quads, originColor, originVerticies.ToArray());
				}

				Glint.AddCommand(originCommand);
			}

			void DrawGrid()
			{
				if (!isDrawingGrid) return;

				int divisionStepCount = 0;

				#region Vertical Lines
				for (float i = (grid.origin.x % grid.gridSize); i < Screen.width; i += grid.gridSize)
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
						DrawLine(new Line(new Vector3(i, 0), new Vector3(i, Screen.width), lineColor));
				#endregion Vertical Lines

				divisionStepCount = 0;

				#region Horizontal Lines
				for (float i = (grid.origin.y % grid.gridSize); i < Screen.width; i += grid.gridSize)
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
						DrawLine(new Line(new Vector3(0, i), new Vector3(Screen.width, i), lineColor));
				#endregion Horizontal Lines
			}

			void DrawPoint()
			{
				thePoint = grid.ScreenToGrid(Input.mousePosition);

				DrawingTools.DrawCircle(thePoint, 0.25f, 32, Color.white, grid);
			}
		#endregion Grid

		#region Draw Shapes
			void DrawRectangle()
			{
				if (!isDrawingRectangle) return;

				#region Draw Rectangle Hollow
				for (int i = 0; i < rectangle.Verticies.Count; i++)
				{		
					if (i == rectangle.Verticies.Count - 1)
						DrawLine(new Line(rectangle.Verticies[i] + rectangle.Center, rectangle.Verticies[0] + rectangle.Center, rectangle.EdgeColor), true);
					else 
						DrawLine(new Line(rectangle.Verticies[i] + rectangle.Center, rectangle.Verticies[i + 1] + rectangle.Center, rectangle.EdgeColor), true);
				}
				#endregion Draw Rectangle Hollow

				#region Inside Rect Guard Clause
				for (int i = 0; i < rectangle.Verticies.Count; i++)
				{
					if (i == rectangle.Verticies.Count - 1)
					{
						if (!isRight(thePoint, rectangle.Verticies[i] + rectangle.Center, rectangle.Verticies[0] + rectangle.Center))
							return;
					}
					else
					{
						if (!isRight(thePoint, rectangle.Verticies[i] + rectangle.Center, rectangle.Verticies[i + 1] + rectangle.Center))
							return;
					}
				}
				#endregion Inside Rect Guard Clause

				#region Refresh Pixel List
				if (rectangle.Center != rectangle.OldCenter)
				{
					rectangle.OldCenter = rectangle.Center;
					rectangle.update = true;
				}
				if (rectangle.Verticies != rectangle.OldVerticies)
				{
					rectangle.OldVerticies = rectangle.Verticies;
					rectangle.update = true;
				}

				if (rectangle.update)
				{
					rectangle.fillPixels.Clear();

					for (int h = 0; h < Screen.height; h++)
					{
						for (int w = 0; w < Screen.width; w++)
						{
							Vector3 pixel = grid.ScreenToGrid(new Vector3(w, h));

							if (isRight(pixel, rectangle.Verticies[0] + rectangle.Center, rectangle.Verticies[1] + rectangle.Center) &&
								isRight(pixel, rectangle.Verticies[1] + rectangle.Center, rectangle.Verticies[2] + rectangle.Center) &&
								isRight(pixel, rectangle.Verticies[2] + rectangle.Center, rectangle.Verticies[3] + rectangle.Center) &&
								isRight(pixel, rectangle.Verticies[3] + rectangle.Center, rectangle.Verticies[0] + rectangle.Center))
							{
								rectangle.fillPixels.Add(pixel);
							}
						}
					}

					Vector3 start = Vector3.zero;
					Vector3 end = Vector3.zero;

					rectangle.fillLines.Clear();

					// Go through list of pixels
					for (int i = 0; i < rectangle.fillPixels.Count; i++)
					{
						if (i == 0) start = rectangle.fillPixels[0];

						if (i == rectangle.fillPixels.Count - 1 || rectangle.fillPixels[i].y != rectangle.fillPixels[i + 1].y)
						{
							end = rectangle.fillPixels[i];
							rectangle.fillLines.Add(new Line(start, end, rectangle.FillColor));
							if (i < rectangle.fillPixels.Count - 1)
								start = rectangle.fillPixels[i + 1];
						}
					}

					rectangle.update = false;
				}
				#endregion Refresh Pixel List

				#region Draw Rectangle Filled
				foreach (Line line in rectangle.fillLines)
					DrawLine(line, true);
				#endregion Draw Rectangle Filled
			}

			void DrawCircle()
			{
				if (!isDrawingCircle) return;

				#region Draw Cricle Hollow
				if (circle.Sides < 3) circle.Sides = 3;
				if (circle.Sides > 360) circle.Sides = 360;

				float vertexAngle = 360 / circle.Sides;

				circle.Verticies.Clear();

				for (int i = 0; i < circle.Sides; i++)
					circle.Verticies.Add(grid.GridToScreen(DrawingTools.EllipseRadiusPoint(circle.Center, vertexAngle * i, circle.Axis)));

				for (int i = 0; i < circle.Verticies.Count; i++)
				{
					if (i == circle.Verticies.Count - 1)
						DrawLine(new Line(circle.Verticies[i], circle.Verticies[0], circle.EdgeColor));
					else
						DrawLine(new Line(circle.Verticies[i], circle.Verticies[i + 1], circle.EdgeColor));
				}
				#endregion Draw Cricle Hollow

				#region Inside Circle Guard Clause
				if (checkIfPointInsideEllipse(thePoint, circle.Center, circle.Axis) >= 1) return;
				#endregion Inside Circle Guard Clause

				#region Refresh Pixel List
				if (circle.Center != circle.OldCenter)
				{
					circle.OldCenter = circle.Center;
					circle.update = true;
				}
				if (circle.Axis != circle.OldAxis)
				{
					circle.OldAxis = circle.Axis;
					circle.update = true;
				}
				if (circle.Sides != circle.OldSides)
				{
					circle.OldSides = circle.Sides;
					circle.update = true;
				}

				if (circle.update)
				{
					circle.fillPixels.Clear();

					for (int h = 0; h < Screen.height; h++)
					{
						for (int w = 0; w < Screen.width; w++)
						{
							Vector3 pixel = grid.ScreenToGrid(new Vector3(w, h));

							if (checkIfPointInsideEllipse(pixel, circle.Center, circle.Axis) < 1)
								circle.fillPixels.Add(pixel);
						}
					}

					Vector3 start = Vector3.zero;
					Vector3 end = Vector3.zero;

					circle.fillLines.Clear();

					// Go through list of pixels
					for (int i = 0; i < circle.fillPixels.Count; i++)
					{
						if (i == 0) start = circle.fillPixels[0];

						if (i == circle.fillPixels.Count - 1 || circle.fillPixels[i].y != circle.fillPixels[i + 1].y)
						{
							end = circle.fillPixels[i];
							circle.fillLines.Add(new Line(start, end, circle.FillColor));
							if (i < circle.fillPixels.Count - 1)
								start = circle.fillPixels[i + 1];
						}
					}

					circle.update = false;
				}
				#endregion Refresh Pixel List

				#region Draw Circle Filled
				foreach (Line line in circle.fillLines)
					DrawLine(line, true);
				#endregion Draw Circle Filled
			}

			void DrawTriangle()
			{
				if (!isDrawingTriangle) return;

				#region Draw Triangle Hollow
				for (int i = 0; i < triangle.Verticies.Count; i++)
				{
					if (i == triangle.Verticies.Count - 1)
						DrawLine(new Line(triangle.Verticies[i] + triangle.Center, triangle.Verticies[0] + triangle.Center, triangle.EdgeColor), true);
					else
						DrawLine(new Line(triangle.Verticies[i] + triangle.Center, triangle.Verticies[i + 1] + triangle.Center, triangle.EdgeColor), true);
				}
				#endregion Draw Triangle Hollow

				#region Inside Triangle Guard Clause
				if (!isInsideTriangle(
					thePoint, 
					triangle.Verticies[0] + triangle.Center, 
					triangle.Verticies[1] + triangle.Center, 
					triangle.Verticies[2] + triangle.Center)
					) return;
				#endregion Inside Triangle Guard Clause

				#region Refresh Pixel List
				if (triangle.Center != triangle.OldCenter)
				{
					triangle.OldCenter = triangle.Center;
					triangle.update = true;
				}
				if (triangle.Verticies != triangle.OldVerticies)
				{
					triangle.OldVerticies = triangle.Verticies;
					triangle.update = true;
				}

				if (triangle.update)
				{
					triangle.fillPixels.Clear();

					for (int h = 0; h < Screen.height; h++)
					{
						for (int w = 0; w < Screen.width; w++)
						{
							Vector3 pixel = grid.ScreenToGrid(new Vector3(w, h));

							if (isInsideTriangle(pixel, triangle.Verticies[0] + triangle.Center, triangle.Verticies[1] + triangle.Center, triangle.Verticies[2] + triangle.Center))
								triangle.fillPixels.Add(pixel);
						}
					}

					Vector3 start = Vector3.zero;
					Vector3 end = Vector3.zero;

					triangle.fillLines.Clear();

					// Go through list of pixels
					for (int i = 0; i < triangle.fillPixels.Count; i++)
					{
						if (i == 0) start = triangle.fillPixels[0];

						if (i == triangle.fillPixels.Count - 1 || triangle.fillPixels[i].y != triangle.fillPixels[i + 1].y)
						{
							end = triangle.fillPixels[i];
							triangle.fillLines.Add(new Line(start, end, triangle.FillColor));
							if (i < triangle.fillPixels.Count - 1)
								start = triangle.fillPixels[i + 1];
						}
					}

					triangle.update = false;
				}
				#endregion Refresh Pixel List

				#region Draw Triangle Filled
				foreach (Line line in triangle.fillLines)
					DrawLine(line, true);
				#endregion Draw Triangle Filled
			}
		#endregion Draw Shapes

		#region Shape Collision Methods
			/// <summary>
			/// Used to see if a point is inside a polygon
			/// </summary>
			/// <param name="point">The point to look for</param>
			/// <param name="A">Verticie A</param>
			/// <param name="B">Verticie B</param>
			/// <returns>True if point is to the right of the given line AB</returns>
			bool isRight(Vector3 point, Vector3 A, Vector3 B)
			{
				if (((B.x - point.x) * (A.y - point.y) - (A.x - point.x) * (B.y - point.y)) > 0)
					return true;

				return false;
			}

			//https://www.geeksforgeeks.org/check-if-a-point-is-inside-outside-or-on-the-ellipse/
			float checkIfPointInsideEllipse(Vector3 Point, Vector3 Center, Vector3 Axis)
			{
				// checking the equation of
				// ellipse with the given point
				float p = (Mathf.Pow((Point.x - Center.x), 2) /
						 Mathf.Pow(Axis.x, 2)) +
						(Mathf.Pow((Point.y - Center.y), 2) /
						 Mathf.Pow(Axis.y, 2));

				return p;
			}

			//https://www.geeksforgeeks.org/check-whether-a-given-point-lies-inside-a-triangle-or-not/
			bool isInsideTriangle(Vector3 point, Vector3 Verticie1, Vector3 Verticie2, Vector3 Verticie3)
			{
				/* Calculate area of triangle ABC */
				float A = AreaOfTriangle(Verticie1, Verticie2, Verticie3);

				/* Calculate area of triangle PBC */
				float A1 = AreaOfTriangle(point, Verticie2, Verticie3);

				/* Calculate area of triangle PAC */
				float A2 = AreaOfTriangle(Verticie1, point, Verticie3);

				/* Calculate area of triangle PAB */
				float A3 = AreaOfTriangle(Verticie1, Verticie2, point);

				/* Check if sum of A1, A2 and A3 is same as A */
				return NearlyEqual(A, A1 + A2 + A3);
			}

			float AreaOfTriangle(Vector3 Verticie1, Vector3 Verticie2, Vector3 Verticie3)
			{
				return Mathf.Abs((Verticie1.x * (Verticie2.y - Verticie3.y) +
								 Verticie2.x * (Verticie3.y - Verticie1.y) +
								 Verticie3.x * (Verticie1.y - Verticie2.y)) / 2f);
			}

			public bool NearlyEqual(float f1, float f2)
			{
				float check = f1 - f2;
				return (Mathf.Abs(check) < 0.001);
			}
		#endregion Shape Collision Methods

	#endregion Methods
}


#region Shape Structs
[System.Serializable]
public class CollisionShape 
{
	public Vector3 Center;
	[Tooltip("Points must go in a clockwise fashion for collision detection to work")]
	public List<Vector3> Verticies = new List<Vector3>();

	public Color EdgeColor;
	public Color FillColor;
	[HideInInspector] public List<Vector3> fillPixels = new List<Vector3>();
	[HideInInspector] public List<Line> fillLines = new List<Line>();
	[HideInInspector] public List<Vector3> OldVerticies = new List<Vector3>();
	[HideInInspector] public Vector3 OldCenter = Vector2.zero;
	[HideInInspector] public bool update = true;
}

[System.Serializable]
public class CollisionCircle : CollisionShape
{
	public Vector3 Axis = Vector2.one;
	public int Sides = 32;
	[HideInInspector] public Vector3 OldAxis = Vector2.one;
	[HideInInspector] public int OldSides = 32;
}
#endregion Shape Structs