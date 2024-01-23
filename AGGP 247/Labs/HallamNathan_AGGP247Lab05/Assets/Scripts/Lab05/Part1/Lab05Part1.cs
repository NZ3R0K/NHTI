using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lab05Part1 : MonoBehaviour
{
	public Grid2D grid = new Grid2D();

	public Ship ship;

	private Vector3 horizontalOffset;
	private Vector3 verticalOffset;
	private float horizontalEdge;
	private float verticalEdge;

	// Start is called before the first frame update
	void Start()
	{
		grid.origin = new Vector3(Screen.width / 2, Screen.height / 2);

		horizontalOffset = (Camera.main.ViewportToWorldPoint(new Vector3(1.0f, 0.5f, -Camera.main.transform.position.z)));
		verticalOffset = (Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 1.0f, -Camera.main.transform.position.z)));
		horizontalEdge = horizontalOffset.x *8;
		verticalEdge = verticalOffset.y *8;
	}

	// Update is called once per frame
	void Update()
	{
		ship.Update();

		ship.DrawShip(grid);

		ship.ScreenWrap(horizontalOffset, verticalOffset, horizontalEdge, verticalEdge, grid);
	}

	private void FixedUpdate()
	{
		ship.transform.Update();
	}
}
