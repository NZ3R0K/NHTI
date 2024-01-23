using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Shuttle : RigidbodyObject
{
	public Color LineColor;

	public float ThrustForce;
	public float RotationSpeed;

	[HideInInspector] public Vector3 movement;
	public float SnapAngle;

	public float FuelStart;
	public float Fuel;

	RigidbodyPolygon _leftFootCollider;
	RigidbodyPolygon _rightFootCollider;

	public int farthestCollisionZoneDetect = 3;

	float _landTime = 0;
	int _landType = -1;
	float _speedBeforeLand = 0;
	float _timeBeforeStart = 0;

	public void Draw(Game game, World world, Grid2D grid)
	{
		#region Draw Body
		List<Vector3> _bodyVerticies = new List<Vector3>();
		List<Line> _bodyLines = new List<Line>();

		//Get all verticies
		for (int i = 0; i < 9; i++)
			_bodyVerticies.Add(DrawingTools.RotatePoint(Position, Rotation.z, DrawingTools.EllipseRadiusPoint(Position, 45 * i - 22.5f, Scale)));

		if (_bodyLines.Count == 0)
			for (int i = 0; i < _bodyVerticies.Count; i++)
			{
				if (i + 1 != _bodyVerticies.Count)
					_bodyLines.Add(new Line(_bodyVerticies[i], _bodyVerticies[i + 1], LineColor));
				else
					_bodyLines.Add(new Line(_bodyVerticies[i], _bodyVerticies[0], LineColor));
			}

		if (_bodyLines.Count != 0)
		{
			for (int i = 0; i < _bodyLines.Count; i++)
			{
				_bodyLines[i].Draw(grid);
			}
		}
		#endregion Draw Body

		#region Draw Base
		List<Vector3> _baseVerticies = new List<Vector3>();

		_baseVerticies.Add(DrawingTools.RotatePoint(Position, Rotation.z, new Vector3(-1 + Position.x, -0.93f + Position.y)));
		_baseVerticies.Add(DrawingTools.RotatePoint(Position, Rotation.z, new Vector3(1 + Position.x, -0.93f + Position.y)));
		_baseVerticies.Add(DrawingTools.RotatePoint(Position, Rotation.z, new Vector3(1 + Position.x, -1.18f + Position.y)));
		_baseVerticies.Add(DrawingTools.RotatePoint(Position, Rotation.z, new Vector3(-1 + Position.x, -1.18f + Position.y)));

		for(int i = 0; i < _baseVerticies.Count; i++)
		{
			if (i + 1 != _baseVerticies.Count)
				grid.DrawLine(new Line(_baseVerticies[i], _baseVerticies[i + 1], LineColor));

			else
				grid.DrawLine(new Line(_baseVerticies[i], _baseVerticies[0], LineColor));
		}
		#endregion Draw Base

		#region Draw Thruster
		List<Vector3> _thrusterVerticies = new List<Vector3>();

		_thrusterVerticies.Add(DrawingTools.RotatePoint(Position, Rotation.z, new Vector3(-0.5f + Position.x, -1.18f + Position.y)));
		_thrusterVerticies.Add(DrawingTools.RotatePoint(Position, Rotation.z, new Vector3(0.5f + Position.x, -1.18f + Position.y)));
		_thrusterVerticies.Add(DrawingTools.RotatePoint(Position, Rotation.z, new Vector3(0.75f + Position.x, -1.93f + Position.y)));
		_thrusterVerticies.Add(DrawingTools.RotatePoint(Position, Rotation.z, new Vector3(-0.75f + Position.x, -1.93f + Position.y)));

		for (int i = 0; i < _thrusterVerticies.Count; i++)
		{
			if (i + 1 != _thrusterVerticies.Count)
				grid.DrawLine(new Line(_thrusterVerticies[i], _thrusterVerticies[i + 1], LineColor));

			else
				grid.DrawLine(new Line(_thrusterVerticies[i], _thrusterVerticies[0], LineColor));
		}
		#endregion Draw Thruster

		#region Draw Legs
		grid.DrawLine(new Line(
			DrawingTools.RotatePoint(Position, Rotation.z, new Vector3(-0.75f + Position.x, -1.18f + Position.y)),
			DrawingTools.RotatePoint(Position, Rotation.z, new Vector3(-1.25f + Position.x, -2.18f + Position.y)),
			LineColor));

		grid.DrawLine(new Line(
			DrawingTools.RotatePoint(Position, Rotation.z, new Vector3(0.75f + Position.x, -1.18f + Position.y)),
			DrawingTools.RotatePoint(Position, Rotation.z, new Vector3(1.25f + Position.x, -2.18f + Position.y)),
			LineColor));
		#endregion Draw Left

		#region Draw Feet

		#region Draw Left
		List<Vector3> _leftFootVerticies = new List<Vector3>();

		_leftFootVerticies.Add(DrawingTools.RotatePoint(Position, Rotation.z, new Vector3((-1.725f + Position.x), (-2.18f + Position.y))));
		_leftFootVerticies.Add(DrawingTools.RotatePoint(Position, Rotation.z, new Vector3((-1.125f + Position.x), (-2.18f + Position.y))));
		_leftFootVerticies.Add(DrawingTools.RotatePoint(Position, Rotation.z, new Vector3((-1.125f + Position.x), (-2.33f + Position.y))));
		_leftFootVerticies.Add(DrawingTools.RotatePoint(Position, Rotation.z, new Vector3((-1.725f + Position.x), (-2.33f + Position.y))));

		for (int i = 0; i < _leftFootVerticies.Count; i++)
		{
			if (i + 1 != _leftFootVerticies.Count)
				grid.DrawLine(new Line(_leftFootVerticies[i], _leftFootVerticies[i + 1], LineColor));

			else
				grid.DrawLine(new Line(_leftFootVerticies[i], _leftFootVerticies[0], LineColor));
		}



		#endregion Draw Left

		#region Draw Right
		List<Vector3> _rightFootVerticies = new List<Vector3>();

		_rightFootVerticies.Add(DrawingTools.RotatePoint(Position, Rotation.z, new Vector3((1.725f + Position.x), (-2.18f + Position.y))));
		_rightFootVerticies.Add(DrawingTools.RotatePoint(Position, Rotation.z, new Vector3((1.125f + Position.x), (-2.18f + Position.y))));
		_rightFootVerticies.Add(DrawingTools.RotatePoint(Position, Rotation.z, new Vector3((1.125f + Position.x), (-2.33f + Position.y))));
		_rightFootVerticies.Add(DrawingTools.RotatePoint(Position, Rotation.z, new Vector3((1.725f + Position.x), (-2.33f + Position.y))));

		for (int i = 0; i < _rightFootVerticies.Count; i++)
		{
			if (i + 1 != _rightFootVerticies.Count)
				grid.DrawLine(new Line(_rightFootVerticies[i], _rightFootVerticies[i + 1], LineColor));

			else
				grid.DrawLine(new Line(_rightFootVerticies[i], _rightFootVerticies[0], LineColor));
		}
		#endregion Draw Right

		#endregion Draw Feet


		CheckCollisions(game, world, grid);

		CheckLand(game);
	}

	public void Move()
	{
		if (isStatic) return;

		Thrust(movement.y);
		Rotate(movement.z);
	}

	void Thrust(float value)
	{
		if (value == 0) return;
		if (Fuel <= 0) return;

		AddForce(up * value * ThrustForce);

		Fuel -= Time.deltaTime * 10;
	}

	void Rotate(float value)
	{
		if (value < 0)
		{
			if (Rotation.z < 90f)
				Rotation.z += RotationSpeed * Time.deltaTime;
			else
				Rotation.z = 90f;
		}
		else if (value > 0)
		{
			if (Rotation.z > -90f)
				Rotation.z -= RotationSpeed * Time.deltaTime;
			else
				Rotation.z = -90f;
		}

		#region Snap Vertical Alignment
		if (value == 0 && Rotation.z < SnapAngle && Rotation.z > -SnapAngle)
		{
			if (Rotation.z < 0)
			{
				Rotation.z += Time.deltaTime * 90;
			}
			else if (Rotation.z > 0)
			{
				Rotation.z -= Time.deltaTime * 90;
			}

			if (Math.NearlyEqual(Rotation.z, 0, 1f))
			{
				Rotation.z = 0;
			}
		}
		#endregion Snap Vertical Alignment
	}

	void CheckCollisions(Game game, World world, Grid2D grid)
	{
		if (isStatic) return;

		#region Collider
		_leftFootCollider = new RigidbodyPolygon();
		_rightFootCollider = new RigidbodyPolygon();

		_leftFootCollider.Verticies.Add(DrawingTools.RotatePoint(Position, Rotation.z, new Vector3((-1.725f + Position.x), (-2.18f + Position.y))));
		_leftFootCollider.Verticies.Add(DrawingTools.RotatePoint(Position, Rotation.z, new Vector3((-1.125f + Position.x), (-2.18f + Position.y))));
		_leftFootCollider.Verticies.Add(DrawingTools.RotatePoint(Position, Rotation.z, new Vector3((-1.125f + Position.x), (-2.33f + Position.y))));
		_leftFootCollider.Verticies.Add(DrawingTools.RotatePoint(Position, Rotation.z, new Vector3((-1.725f + Position.x), (-2.33f + Position.y))));

		_rightFootCollider.Verticies.Add(DrawingTools.RotatePoint(Position, Rotation.z, new Vector3((1.725f + Position.x), (-2.18f + Position.y))));
		_rightFootCollider.Verticies.Add(DrawingTools.RotatePoint(Position, Rotation.z, new Vector3((1.125f + Position.x), (-2.18f + Position.y))));
		_rightFootCollider.Verticies.Add(DrawingTools.RotatePoint(Position, Rotation.z, new Vector3((1.125f + Position.x), (-2.33f + Position.y))));
		_rightFootCollider.Verticies.Add(DrawingTools.RotatePoint(Position, Rotation.z, new Vector3((1.725f + Position.x), (-2.33f + Position.y))));

		int shuttleGroundPolyIndex = (int)(((Position.x - (-160)) * 160) / (160 - (-160)));
		int minCheck = (shuttleGroundPolyIndex - farthestCollisionZoneDetect < 0) ? 0 : shuttleGroundPolyIndex - farthestCollisionZoneDetect;
		int maxCheck = (shuttleGroundPolyIndex + farthestCollisionZoneDetect > world.groundPolygons.Count - 1) ? world.groundPolygons.Count -1 : shuttleGroundPolyIndex + farthestCollisionZoneDetect;

		if (minCheck > maxCheck) minCheck = maxCheck;
		if (maxCheck < 0) maxCheck = minCheck = 0;

		bool collisionLeft = false;
		bool collisionRight = false;

		for (int i = minCheck; i < maxCheck; i++)
		{
			collisionLeft = _leftFootCollider.ShapeOverlap_SAT(_leftFootCollider, world.groundPolygons[i]);

			if (collisionLeft) break;
		}

		for (int i = minCheck; i < maxCheck; i++)
		{
			collisionRight = _rightFootCollider.ShapeOverlap_SAT(_rightFootCollider, world.groundPolygons[i]);

			if (collisionRight)	break;
		}

		if (collisionLeft && collisionRight)
		{
			foreach (RigidbodyPolygon zone in world.zonePolygons)
			{
				if (Position.x >= zone.Verticies[0].x && Position.x <= zone.Verticies[1].x)
				{
					if (Velocity.y > -1.6f)
					{
						Debug.Log($"Landed");
						_speedBeforeLand = Velocity.y;
						_landType = 0;
						Velocity = Vector3.zero;
						isStatic = true;
						return;
					}
					else
					{
						Debug.Log($"Crashed - TOO FAST");
						_landType = 1;
						Velocity = Vector3.zero;
						isStatic = true;
						return;
					}
				}
			}

			_landType = 2;
			Debug.Log($"Crashed Not a LZ");
			Velocity = Vector3.zero;
			isStatic = true;
			return;
		}
		
		if (collisionLeft | collisionRight)
		{
			_landType = 3;
			Debug.Log($"Crashed L: {collisionLeft} R:{collisionRight}");
			Velocity = Vector3.zero;
			isStatic = true;
			return;
		}
		#endregion Collider
	}

	void CheckLand(Game game)
	{
		if (!isStatic) return;

		_landTime += Time.deltaTime;

		if (_landType > 0)
		{
			float fuelLoss = Random.Range(FuelStart / 5, FuelStart / 3);
			Fuel -= fuelLoss;

			if (_landType == 1)
			{
				game.infoText.text = $"You Landed too Hard! \nFuel -{Math.Round(fuelLoss)}";
				game.infoText.enabled = true;
			}
			else if (_landType == 2)
			{
				game.infoText.text = $"You Crashed in an Unkown Place... \nFuel -{Math.Round(fuelLoss)}";
				game.infoText.enabled = true;
			}
			else if (_landType == 3)
			{
				game.infoText.text = $"You planted your face into the ground.. \nFuel -{Math.Round(fuelLoss)}";
				game.infoText.enabled = true;
			}
		}
		else if (_landType == 0)
		{
			int scoreIncrease = 100;

			if (_speedBeforeLand < -1.5f) scoreIncrease -= 80;

			else if (_speedBeforeLand < -1.25f) scoreIncrease -= 60;

			else if (_speedBeforeLand < -1) scoreIncrease -= 40;

			else if (_speedBeforeLand < -0.75f) scoreIncrease -= 20;

			game.infoText.text = $"You Successfully Landed! \nScore +{scoreIncrease}";
			game.infoText.enabled = true;
			game.score += scoreIncrease;
		}

		_landType = -1;

		if (Fuel <= 0 && isStatic)
		{
			game.infoText.text = $"Fuel Reserves Depleted! \nGAME OVER \n\n [SPACE] Play Again! \n [ESC] Exit Application";

			game.waitForInput = true;
		}


		if (_landTime >= 5 && !game.waitForInput)
		{
			game.infoText.enabled = false;
			game.infoText.text = "";
			isStatic = false;
			_landTime = 0;

			_timeBeforeStart = game.time;

			if (Fuel <= 0) game.Restart();
			else game.BeginGame();
		}
	}
}
