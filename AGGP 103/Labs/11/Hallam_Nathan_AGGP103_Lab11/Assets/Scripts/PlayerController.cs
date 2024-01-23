using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public int playerId = 0;
	public float moveSpeed = 10f;



	Rigidbody2D rb;
	public Animator animator;

	void Start()    //On Start - get rigidbody of object and freeze its rotation
	{
		rb = gameObject.GetComponent<Rigidbody2D>();
		rb.constraints = RigidbodyConstraints2D.FreezeRotation;
	}

	Vector2 movement;

	private void Update()
	{
		movement.x = Input.GetAxisRaw("Horizontal");
		movement.y = Input.GetAxisRaw("Vertical");

		animator.SetFloat("Horizontal", movement.x);
		animator.SetFloat("Vertical", movement.y);
		animator.SetFloat("Speed", movement.sqrMagnitude);
	}



	void FixedUpdate()  //Check keystrokes.
	{
		if (playerId == 1)
		{
			rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

		}
	}
}
