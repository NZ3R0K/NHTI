/* Notes :
- Added second fire ability with Fire2 for time being, does same action as Fire1 but with shorter cooldown.
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatController : MonoBehaviour
{
	public bool isPlayerOne = true;
	public float moveSpeed = 10;
	public float rotationSpeed = 120;

	//Input Variables
	bool forward = false;
	bool backward = false;
	bool left = false;
	bool right = false;

	float Horizontal = 0;
	float Vertical = 0;

	//Fire Variables
	public bool fireOneIsEnabled = true;
	public bool fireTwoIsEnabled = true;
	double fireOneCooldown = 0;
	double fireTwoCooldown = 0;
	public bool fireOneOnCooldown = false;
	public bool fireTwoOnCooldown = false;
	public double fireOneCooldownTime = 6;	//in Seconds.
	public double fireTwoCooldownTime = 6;	//in Seconds.
	public double cooldownOneSpeed = 1; //For Fire1 - 1 is normal speed : 2 is 2X faster : 0.5 is 2X slower. If there were to be powerups - this would change the "reload" speed.
	public double cooldownTwoSpeed = 1; //For Fire2 - 1 is normal speed : 2 is 2X faster : 0.5 is 2X slower. If there were to be powerups - this would change the "reload" speed.
	bool fire1 = false;
	bool fire2 = false;

	Rigidbody rigBod;

	//Shell Instantiate Variables
	public GameObject ShellPrefab;
	public GameObject SpawnLocation;


	void Start()	//On Start - get rigidbody of object and freeze its rotation
	{
		rigBod = gameObject.GetComponent<Rigidbody>();
		rigBod.constraints = RigidbodyConstraints.FreezeRotation;
	}

	void FixedUpdate()  //Check keystrokes.
	{
		if (isPlayerOne)
		{
			GetInputPlayer1();

			Horizontal = 0;
			Vertical = 0;

			if (forward)
			{
				Vertical = 1;
			}
			if (backward)
			{
				Vertical = -1;
			}
			if (right)
			{
				Horizontal = 1;
			}
			if (left)
			{
				Horizontal = -1;
			}
			if (fire1)
			{
				Fire1();
			}
			if (fire2)
			{
				Fire2();
			}

			Move(Vertical);
			Rotate(Horizontal);
		}

		if (!isPlayerOne)
		{
			GetInputPlayer2();

			
			Horizontal = 0;
			Vertical = 0;

			if (forward)
			{
				Vertical = 1;
			}
			if (backward)
			{
				Vertical = -1;
			}
			if (right)
			{
				Horizontal = 1;
			}
			if (left)
			{
				Horizontal = -1;
			}
			if (fire1)
			{
				Fire1();
			}
			if (fire2)
			{
				Fire2();
			}

			Move(Vertical);
			Rotate(Horizontal);
		
		}

		void GetInputPlayer1()
		{
			forward = Input.GetKey(KeyCode.W);
			backward = Input.GetKey(KeyCode.S);
			left = Input.GetKey(KeyCode.A);
			right = Input.GetKey(KeyCode.D);
			fire1 = Input.GetKey(KeyCode.Q);
			fire2 = Input.GetKey(KeyCode.E);
		}

		void GetInputPlayer2()
		{
			forward = Input.GetKey(KeyCode.I);
			backward = Input.GetKey(KeyCode.K);
			left = Input.GetKey(KeyCode.J);
			right = Input.GetKey(KeyCode.L);
			fire1 = Input.GetKey(KeyCode.U);
			fire2 = Input.GetKey(KeyCode.O);
		}

		void Move(float value)
		{
			rigBod.velocity = gameObject.transform.forward * moveSpeed * value;
		}

		void Rotate(float value)
		{
			gameObject.transform.Rotate(Vector3.up * value * rotationSpeed * Time.deltaTime);
		}
	}

	private void Update()	//Update fire cooldown time and availability.
	{
		//Fire 1
		if (fireOneCooldown > 0)	//If ability cooldown is over 0 seconds.
		{
			fireOneCooldown -= cooldownOneSpeed * Time.deltaTime;	//Countdown cooldown.
			fireOneOnCooldown = true;	//Disable Fire.
		}
		else //If ability is not on cooldown.
		{
			fireOneOnCooldown = false;	//Enable fire.
			fireOneCooldown = 0;	//Set cooldown to zero.
		}

		//Fire 2
		if (fireTwoCooldown > 0)    //If ability cooldown is over 0 seconds.
		{
			fireTwoCooldown -= cooldownOneSpeed * Time.deltaTime;   //Countdown cooldown.
			fireTwoOnCooldown = true;   //Disable Fire.
		}
		else //If ability is not on cooldown.
		{
			fireTwoOnCooldown = false;    //Enable fire.
			fireTwoCooldown = 0;    //Set cooldown to zero.
		}
	}

	public void Fire1()	//Checks if player has used ability and if fire1 is on cooldown, if available then call FireProjectile.
	{
		
		if (fireOneIsEnabled)   //If the player can fire
		{
			if (fireOneCooldown <= 0)   //If the ability is not on cooldown
			{
				fireOneCooldown = fireOneCooldownTime;
				FireProjectile();
			}
		}
	}

	public void FireProjectile()	//Spawns Projectile when Fire1 or Fire2 are active.
	{
		Debug.LogWarning("Projectile Launched");
		Instantiate(ShellPrefab,					//Object to Spawn
				SpawnLocation.transform.position,	//Position to Spawn Object
				SpawnLocation.transform.rotation);	//Rotation to Spawn Object
	}	

	public void Fire2() //Checks if player has used ability and if fire2 is on cooldown, if available then call FireProjectile.
	{
		if (fireTwoIsEnabled)   //If the player can fire
		{
			if (fireTwoCooldown <= 0)   //If the ability is not on cooldown
			{
				fireTwoCooldown = fireTwoCooldownTime;
				FireProjectile();
			}
		}
	}

	public void Reset()	//UNUSED
	{

	}
}