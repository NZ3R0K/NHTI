using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
	public int playerId = 0;
	public float moveSpeed = 10f;
	float currentMoveSpeed = 0f;
	public float maxHealth = 100f;
	public float currentHealth = 0f;
	float savedHealth;
	public float maxMana = 100f;
	public float currentMana = 0f;
	public float manaRegen = 10f;

	public float damageTic = 1;
	float tic;

	int savedShards;
	public int currentShards = 0;

	//[HideInInspector]
	public bool effectPoison = false;
	public float debuffTime = 0;
	public float debuffSetTime = 4;

	Rigidbody2D rb;
	public Animator animator;
	public PauseIG pause;

	public Transform SpawnPoint;
	public GameObject Projectile;
	public GameObject Pivot;
	public Canvas DeathCanvas;
	public Canvas HUD;
	private Vector2 lookDirection;
	private float lookAngle;
	public float deathTime = 0;

	void Start()    //On Start - get rigidbody of object and freeze its rotation
	{
		rb = gameObject.GetComponent<Rigidbody2D>();
		rb.constraints = RigidbodyConstraints2D.FreezeRotation;

		currentMana = maxMana;
		currentMoveSpeed = moveSpeed;

		if (PlayerPrefs.GetFloat("Health") <= 0)
		{
			currentHealth = maxHealth;
		}
		else
		{
			currentHealth = PlayerPrefs.GetFloat("Health");
		}

		currentShards = PlayerPrefs.GetInt("Shards");
	}

	Vector2 movement;
	Vector2 lastMove;
	float animTime;

	public void Update()
	{
		if (animTime == 0)
		{
			currentMoveSpeed = moveSpeed;
			animator.SetBool("MoveAnim", true);
		}
		else
		{
			currentMoveSpeed = 0;
			animator.SetBool("MoveAnim", false);
		}

		if (effectPoison == true)
		{
			tic += Time.deltaTime;
			debuffTime -= Time.deltaTime;
		}
		else
		{
			debuffTime = 0;
		}

		if (debuffTime <= 0)
		{
			effectPoison = false;
		}
		else
		{
			effectPoison = true;
		}

		if (deathTime > 5)
		{
			SceneManager.LoadScene(0);
		}

		ProcessInputs();
		
		if (pause.gameIsPaused == false)
		{
			Animate();
		}


		lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
		lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
		SpawnPoint.transform.rotation = Quaternion.Euler(0f, 0f, lookAngle - 90f);

		Pivot.transform.rotation = Quaternion.AngleAxis(lookAngle - 90f, Vector3.forward);

		if (Input.GetMouseButtonDown(0) && currentMana > 10 && deathTime == 0 && pause.gameIsPaused == false)
		{
			FireProjectile();
			currentMana -= 10;
			animator.SetBool("Attack", true);
		}

		if (currentMana >= maxMana)
		{
			currentMana = maxMana;
		}
		else
		{
			currentMana += 10 * Time.deltaTime;
		}

		if (animTime > 0)
		{
			animTime += Time.deltaTime;
		}


		if (animTime >= 0.5)
		{
			animator.SetBool("Attack", false);
			animTime = 0;
		}

		if (currentHealth <= 0 && deathTime == 0)
		{
			Death();
		}

		if (effectPoison == true)
		{
			Damage(5);
		}
	}

	void ProcessInputs()
	{
		float moveX = Input.GetAxisRaw("Horizontal");
		float moveY = Input.GetAxisRaw("Vertical");

		if ((moveX == 0 && moveY == 0) && movement.x != 0 || movement.y != 0)
		{
			lastMove = movement;
		}

		movement = new Vector2(moveX, moveY).normalized;
	}

	void Animate()
	{
		animator.SetFloat("MoveX", lookDirection.x);
		animator.SetFloat("MoveY", lookDirection.y);
		animator.SetFloat("MoveMagnitude", movement.magnitude);
		animator.SetFloat("LastMoveX", lookDirection.x);
		animator.SetFloat("LastMoveY", lookDirection.y);
	}

	void FixedUpdate()  //Check keystrokes.
	{
		if (deathTime > 0)
		{
			deathTime += Time.deltaTime;
		}

		if (deathTime > 3)
		{
			DeathCanvas.GetComponent<Canvas>().enabled = true;
			HUD.GetComponent<Canvas>().enabled = false;
		}

		if (playerId == 1 && deathTime == 0)
		{
			rb.MovePosition(rb.position + movement * currentMoveSpeed * Time.fixedDeltaTime);
		}
	}

	public void Damage(float damage)
	{
		if (tic >= damageTic)
		{
			Debug.Log("Damage Taken" + damage);
			currentHealth -= damage;
			tic = 0;
			PlayerPrefs.SetFloat("Health", currentHealth);
		}
	}

	private void FireProjectile()
	{
		animTime = 0.001f;

		GameObject fireball = Instantiate(Projectile, SpawnPoint.position, SpawnPoint.rotation);
		fireball.GetComponent<Rigidbody2D>().velocity = SpawnPoint.up * 10f;
		animator.SetBool("Attack", false);
	}

	private void Death()
	{
		PlayerPrefs.SetInt("Shards", 0);
		animator.SetBool("Death", true);
		deathTime = 0.1f;
	}

	public void IncreaseShards()
	{
		currentShards++;
		savedShards = currentShards;
		PlayerPrefs.SetInt("Shards", savedShards);
	}
}
