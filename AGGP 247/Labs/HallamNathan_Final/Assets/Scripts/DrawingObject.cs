using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Drawing.Glint;

public class DrawingObject : RigidbodyObject
{
	public bool PerformDraw = true;
	protected bool _updateShape = true;
	public List<ICommandInstruction> Lines = new List<ICommandInstruction>();
	public Color LineColor;
	protected Color _oldLineColor;

	public void Start()
	{
		Initialize();
	}

	public virtual void Initialize()
	{

	}

	public virtual void Update()
	{
		if (_updateShape) UpdateShape();
	}

	protected virtual void UpdateShape()
	{

	}

	/// <summary>
	/// Draws the Drawing Object Instance
	/// </summary>
	/// <param name="grid">Optional, When a Grid2d is applied, object is drawn relative to the grid and location is in Grid space</param>
	public virtual void Draw(Grid2D grid = null)
	{
		if (_oldPosition != Position)
		{
			_oldPosition = Position;
			_updateShape = true;
		}

		if (_oldRotation != Rotation)
		{
			_oldRotation = Rotation;
			_updateShape = true;
		}

		if (_oldScale != Scale)
		{
			_oldScale = Scale;
			_updateShape = true;
		}

		if (_oldLineColor != LineColor)
		{
			_oldLineColor = LineColor;
			_updateShape = true;
		}

		if (Lines.Count != 0)
		{
			for (int i = 0; i < Lines.Count; i++)
			{
				Lines[i].Draw(grid);
			}
		}
	}
}