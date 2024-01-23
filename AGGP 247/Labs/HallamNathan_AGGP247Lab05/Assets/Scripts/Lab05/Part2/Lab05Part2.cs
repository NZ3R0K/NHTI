using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lab05Part2 : MonoBehaviour
{
	public static Lab05Part2 instance;

	public Grid2D grid = new Grid2D();

	public Cannon cannon;

	public List<Balls> balls = new List<Balls>();

	[HideInInspector] public List<CollisionShape> PhysObjects = new List<CollisionShape>();

	public Vector3 worldGravity = new Vector3(0f, 9.81f, 0f);

	public float groundHeight = 50;

	void Start()
	{
		instance = this;

		grid.origin = new Vector3(Screen.width / 2, Screen.height / 2);
	}

	private void Update()
	{
		grid.DrawLine(new Line(new Vector3(0, groundHeight), new Vector3(Screen.width, groundHeight), Color.white), false);

		cannon.DrawCannon(grid);

		foreach (Balls ball in balls)
		{
			ball.Draw(grid);

			ball.Update(worldGravity);
		}
	}
}
