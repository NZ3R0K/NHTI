using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class World
{
	public Vector3 Gravity;

	public int zoomedOutSize = 6;
	public int zoomedInSize = 12;
	public bool zoom = false;

	[Tooltip("The amount of pixels minimum the shuttle needs to land.")]
	public int smallestShuttlePixelLandingSize = 12;

	List<Vector3> _groundPixelValues = new List<Vector3>();

	public Color GroundColor;
	public Color ZoneColor;

	public int terrainHighestVertical;
	public int terrainLowestVertical;

	public int verticalOffset100;
	public int verticalOffset75;
	public int verticalOffset50;
	public int verticalOffset25;

	public int minZonesAllowed = 3;
	public int maxZonesAllowed = 10;
	[Tooltip("How many segments the zone uses as a minimum.")]
	public int minZoneSize = 3;
	[Tooltip("How many segments the zone uses as a maximum.")]
	public int maxZoneSize = 10;

	[Tooltip("How many spaces will be skipped between zones, and the edge of the screen.")]
	public int zoneBuffer = 5;

	public float zoneBlinkTimer = 0.1f;

	public bool RegenerateTerrain;


	public List<RigidbodyPolygon> groundPolygons = new List<RigidbodyPolygon>();
	public List<RigidbodyPolygon> zonePolygons = new List<RigidbodyPolygon>();



	public void GenerateTerrain(Grid2D grid)
	{
		groundPolygons.Clear();
		zonePolygons.Clear();

		float startingVertical = Random.Range(terrainLowestVertical, terrainHighestVertical);

		int zoneCount = Random.Range(minZonesAllowed, maxZonesAllowed);

		int bufferRemaining = zoneBuffer;

		float terrainMedian = (terrainHighestVertical + terrainLowestVertical) / 2;
		float top50 = (terrainHighestVertical + terrainMedian) / 2;
		float top75 = (terrainHighestVertical + top50) / 2;
		float top25 = (top50 + terrainMedian) / 2;
		float bottom50 = (terrainLowestVertical + terrainMedian) / 2;
		float bottom75 = (terrainLowestVertical + bottom50) / 2;
		float bottom25 = (bottom50 + terrainMedian) / 2;

		float upperLimit = 0;
		float lowerLimit = 0;

		for (int i = 0; i <= Screen.width; i += smallestShuttlePixelLandingSize)
		{
			if (i == 0)
			{		
				_groundPixelValues.Add(grid.ScreenToGrid(new Vector3(i, (grid.screenSize.y / 2) + grid.ScaleGridToScreen(startingVertical))));
				bufferRemaining--;
			}
			else
			{
				bool doZone = false;

				float verticalOffset = 10;

				if (_groundPixelValues[i / smallestShuttlePixelLandingSize - 1].y >= top75) // Top 75 - 100
				{
					upperLimit = 10;
					lowerLimit = -90;
					verticalOffset = verticalOffset100;
				}
				else if (_groundPixelValues[i / smallestShuttlePixelLandingSize - 1].y < top75
					&& _groundPixelValues[i / smallestShuttlePixelLandingSize - 1].y >= top50) // Top 50 - 75
				{
					upperLimit = 20;
					lowerLimit = -80;
					verticalOffset = verticalOffset75;
				}
				else if (_groundPixelValues[i / smallestShuttlePixelLandingSize - 1].y < top75
					&& _groundPixelValues[i / smallestShuttlePixelLandingSize - 1].y >= top25) // Top 25 - 50
				{
					upperLimit = 40;
					lowerLimit = -60;
					verticalOffset = verticalOffset50;
				}
				else if (_groundPixelValues[i / smallestShuttlePixelLandingSize - 1].y < top25
					&& _groundPixelValues[i / smallestShuttlePixelLandingSize - 1].y >= bottom25) // Mid -25 - 25
				{
					upperLimit = 50;
					lowerLimit = -50;
					verticalOffset = verticalOffset25;
				}
				else if (_groundPixelValues[i / smallestShuttlePixelLandingSize - 1].y < bottom25
					&& _groundPixelValues[i / smallestShuttlePixelLandingSize - 1].y >= bottom50) // Bottom -50 - -25
				{
					upperLimit = 60;
					lowerLimit = -40;
					verticalOffset = verticalOffset50;
				}
				else if (_groundPixelValues[i / smallestShuttlePixelLandingSize - 1].y < bottom50
					&& _groundPixelValues[i / smallestShuttlePixelLandingSize - 1].y >= bottom75) // Bottom -75 - -50
				{
					upperLimit = 80;
					lowerLimit = -20;
					verticalOffset = verticalOffset75;
				}
				else if (_groundPixelValues[i / smallestShuttlePixelLandingSize - 1].y <= bottom75) // Bottom -75 - -100
				{
					upperLimit = 90;
					lowerLimit = -10;
					verticalOffset = verticalOffset100;
				}

				float direction = Random.Range(lowerLimit, upperLimit);

				float verticalRound;

				if (direction > 0) verticalRound = Math.Round(Random.Range(0, verticalOffset / 2));
				else if (direction < 0) verticalRound = Math.Round(Random.Range(-verticalOffset / 2, 0));
				else verticalRound = Math.Round(Random.Range(-verticalOffset / 2, verticalOffset / 2));



				float newY = _groundPixelValues[(i / smallestShuttlePixelLandingSize) - 1].y + verticalRound;

				if (newY > terrainHighestVertical)
					newY = terrainHighestVertical;

				else if (newY < terrainLowestVertical)
					newY = terrainLowestVertical;

				if (zoneCount > 0 && bufferRemaining <= 0) doZone = (Random.Range(0, 99) > 89 + (bufferRemaining / maxZonesAllowed)) ? true : false;




				if (!doZone)
				{
					_groundPixelValues.Add(grid.ScreenToGrid(new Vector3(i, (grid.screenSize.y / 2) + grid.ScaleGridToScreen(newY))));
					bufferRemaining--;
				}
				else
				{
					i = ZoneGeneration(grid, i, newY, out bufferRemaining);
					zoneCount--;
				}
			}		
		}

		for (int i = 0; i < _groundPixelValues.Count; i++)
		{
			RigidbodyPolygon polygon = new RigidbodyPolygon();
			polygon.isStatic = true;

			if (i != _groundPixelValues.Count - 1)
			{
				polygon.Verticies.Add(_groundPixelValues[i]);
				polygon.Verticies.Add(_groundPixelValues[i + 1]);
				polygon.Verticies.Add(new Vector3(_groundPixelValues[i + 1].x, grid.ScaleScreenToGrid(-grid.screenSize.y / 2)));
				polygon.Verticies.Add(new Vector3(_groundPixelValues[i].x, grid.ScaleScreenToGrid(-grid.screenSize.y / 2)));
			}
			else
			{
				polygon.Verticies.Add(_groundPixelValues[i]);
				polygon.Verticies.Add(_groundPixelValues[0]);
				polygon.Verticies.Add(new Vector3(_groundPixelValues[0].x, 0));
				polygon.Verticies.Add(new Vector3(_groundPixelValues[i].x, 0));
			}

			groundPolygons.Add(polygon);
		}

		_groundPixelValues.Clear();

		RegenerateTerrain = false;
	}

	int ZoneGeneration(Grid2D grid, int i, float newY, out int buffer)
	{
		int zoneLength = Random.Range(minZoneSize, maxZoneSize);

		RigidbodyPolygon zone = new RigidbodyPolygon();

		int start = i;

		do
		{
			_groundPixelValues.Add(grid.ScreenToGrid(new Vector3(i, (grid.screenSize.y / 2) + grid.ScaleGridToScreen(newY))));

			i += smallestShuttlePixelLandingSize;

			zoneLength--;
		}
		while (zoneLength > 0);

		zone.Verticies.Add(_groundPixelValues[start / smallestShuttlePixelLandingSize]);
		zone.Verticies.Add(_groundPixelValues[i / smallestShuttlePixelLandingSize - 1]);
		zone.Verticies.Add(new Vector3(_groundPixelValues[i / smallestShuttlePixelLandingSize - 1].x, grid.ScaleScreenToGrid(-grid.screenSize.y / 2)));
		zone.Verticies.Add(new Vector3(_groundPixelValues[start / smallestShuttlePixelLandingSize].x, grid.ScaleScreenToGrid(-grid.screenSize.y / 2)));

		zonePolygons.Add(zone);

		i -= smallestShuttlePixelLandingSize;

		buffer = zoneBuffer;

		return i;
	}

	float _blinkTimer = 0;
	bool _blinkZone;

	public void DrawTerrain(Grid2D grid)
	{
		if (RegenerateTerrain) GenerateTerrain(grid);

		for (int i = 0; i < groundPolygons.Count - 1; i++)
		{
			bool drawZone = false;

			foreach (RigidbodyPolygon zone in zonePolygons)
			{
				if (groundPolygons[i].Verticies[0].x >= zone.Verticies[0].x && groundPolygons[i].Verticies[1].x <= zone.Verticies[1].x)
				{
					drawZone = true;
					break;
				}
			}

			if (!drawZone) grid.DrawLine(new Line(groundPolygons[i].Verticies[0], groundPolygons[i].Verticies[1], GroundColor));
		}


		if (_blinkTimer <= 0)
		{
			_blinkZone = !_blinkZone;

			_blinkTimer = zoneBlinkTimer;
		}
		else _blinkTimer -= Time.deltaTime;

		if (_blinkZone)
		{
			foreach (RigidbodyPolygon zone in zonePolygons)
			{
				grid.DrawLine(new Line(zone.Verticies[0], zone.Verticies[1], ZoneColor));
			}
		}
	}
}