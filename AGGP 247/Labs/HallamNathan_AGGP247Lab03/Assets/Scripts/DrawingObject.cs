using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Drawing.Glint;

public class DrawingObject : MonoBehaviour
{
	public bool PerformDraw = true;
	public float Rotation = 0;
	public Vector3 Scale = Vector3.zero;
	public Vector3 Center = Vector3.zero;
	public List<ICommandInstruction> Lines = new List<ICommandInstruction>();
	protected List<Vector3> vertices = new List<Vector3>(); //Used by Ellipse and Circle

	public void Start()
	{
		Initialize();
	}

	public virtual void Initialize()
	{

	}

	/// <summary>
	/// Resets the Lines and Vertices of the object, allowing it to redraw the positions
	/// </summary>
	public virtual void ClearGeometrics()
	{
		vertices.Clear();
		Lines.Clear();
	}

	public virtual void Update()
	{
		if (PerformDraw)
		{
			Draw();
		}
	}

	/// <summary>
	/// Draws the Drawing Object Instance
	/// </summary>
	/// <param name="grid">Optional, When a Grid2d is applied, object is drawn relative to the grid and location is in Grid space</param>
	public virtual void Draw(Grid2D grid = null)
	{
		if (Lines.Count != 0)
		{
			for (int i = 0; i < Lines.Count; i++)
			{
				Lines[i].Draw(grid);
			}
		}
	}
}