using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Balls : CollisionShape
{
	public MTransform transform = new MTransform();
	public MRigidbody rb = new MRigidbody();
	public float lifetime = 10f;

	public int ID;

	public Balls(Vector3 position, Vector3 rotation)
	{
		transform.Position = position;
		transform.Rotation = rotation;
	}

	public void Update(Vector3 gravity)
	{
		transform.Update();
		rb.Update(transform, gravity);

		lifetime -= Time.deltaTime;

		if (lifetime < 0)
		{
			Lab05Part2.instance.PhysObjects.Remove(Lab05Part2.instance.balls.Find(x => x.ID == this.ID));
			Lab05Part2.instance.balls.Remove(Lab05Part2.instance.balls.Find(x => x.ID == this.ID));
		}
	}

	public void Draw(Grid2D grid)
	{
		DrawingTools.DrawCircle(grid.GridToScreen(transform.Position), 10, 8, Color.white);
	}
}
