using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CombatController : MonoBehaviour
{
	//Input Variables
	public bool isPlayerOne = true;
	public float moveSpeed = 10;
	public float rotationSpeed = 120;
	public bool useGamePad = false;

	bool forward = false;
	bool backward = false;
	bool left = false;
	bool right = false;

	float axis_LHorz = 0;
	float axis_LVert = 0;
	float axis_RHorz = 0;
	float axis_RVert = 0;
	public double padDeadZone = 0.1;

	//Fire Variables
	bool fireOneIsEnabled = true;
	bool fireTwoIsEnabled = true;
	double fireOneCooldown = 0;
	double fireTwoCooldown = 0;
	public bool fireOneOnCooldown = false;
	public bool fireTwoOnCooldown = false;
	public double fireOneCooldownTime = 6;  //in Seconds.
	public double fireTwoCooldownTime = 0.5;  //in Seconds.
	public double cooldownOneSpeed = 1; //For Fire1 - 1 is normal speed : 2 is 2X faster : 0.5 is 2X slower. If there were to be powerups - this would change the "reload" speed.
	public double cooldownTwoSpeed = 1; //For Fire2 - 1 is normal speed : 2 is 2X faster : 0.5 is 2X slower. If there were to be powerups - this would change the "reload" speed.
	bool fire1 = false;
	bool fire2 = false;

	Rigidbody rigBod;

	//Shell Instantiate Variables
	public GameObject ShellPrefab;
	public GameObject SpawnLocation;

	//Raycast Variables
	public GameObject ObjectRay;
	public GameObject HitIcon;
	public bool useObjectRay = true;

	public float rayDrawDistance = 50;
	public float rayCastDistance = 50;

	//Reset Variables
	Vector3 StartingLocation;
	Quaternion StartingRotation;
	public GameObject DeathDecal;

	AudioSource soundEffect;
	public AudioClip soundFire1;
	public AudioClip soundFire2;

	private void Start()
	{
		rigBod = gameObject.GetComponent<Rigidbody>();

		StartingLocation = gameObject.transform.position;
		StartingRotation = gameObject.transform.rotation;
		soundEffect = gameObject.AddComponent<AudioSource>();
	}

	private void FixedUpdate()
	{
		GetInput();

		Move(axis_LVert);
		Rotate(axis_LHorz);

		if (fire1)
		{
			Fire1();
		}

		if (fire2)
		{
			Fire2();
		}
	}

	void GetInput()
	{
		axis_LHorz = 0;
		axis_LVert = 0;
		axis_RHorz = 0;
		axis_RVert = 0;

		if (useGamePad)
		{
			GetInputGamePad(Gamepad.current);
			return;
		}

		if (isPlayerOne)
		{
			GetInputPlayer1();
		}
		else
		{
			GetInputPlayer2();
		}

		UpdateKeyboardInput();
	}

	void GetInputGamePad(Gamepad gpad)
	{
		Vector2 LStick = gpad.leftStick.ReadValue();
		Vector2 RStick = gpad.rightStick.ReadValue();

		axis_LHorz = LStick.x;
		axis_LVert = LStick.y;
		axis_RHorz = RStick.x;

		fire1 = gpad.buttonSouth.wasPressedThisFrame;
		fire2 = gpad.buttonEast.wasPressedThisFrame;
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

	void UpdateKeyboardInput()
	{
		if (forward)
		{
			axis_LVert = 1;
		}
		if (backward)
		{
			axis_LVert = -1;
		}
		if (right)
		{
			axis_LHorz = 1;
		}
		if (left)
		{
			axis_LHorz = -1;
		}
	}

	void Move(float value)
	{
		if (Mathf.Abs(value) < padDeadZone)
		{
			value = 0;
		}

		rigBod.velocity = gameObject.transform.forward * moveSpeed * value;
	}

	void Rotate(float value)
	{
		if (Mathf.Abs(value) < padDeadZone)
		{
			value = 0;
		}

		gameObject.transform.Rotate(Vector3.up * value * rotationSpeed * Time.deltaTime);
	}

	private void Update()   //Update fire cooldown time and availability.
	{
		//Fire 1
		if (fireOneCooldown > 0)    //If ability cooldown is over 0 seconds.
		{
			fireOneCooldown -= cooldownOneSpeed * Time.deltaTime;   //Countdown cooldown.
			fireOneOnCooldown = true;   //Disable Fire.
		}
		else //If ability is not on cooldown.
		{
			fireOneOnCooldown = false;  //Enable fire.
			fireOneCooldown = 0;    //Set cooldown to zero.
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

	private void Fire1() //Checks if player has used ability and if fire1 is on cooldown, if available then call FireProjectile.
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

	private void FireProjectile()    //Spawns Projectile when Fire1 or Fire2 are active.
	{
		float audioShift = Random.Range(-.25f, .25f);
		soundEffect.pitch = 1 + audioShift;
		soundEffect.PlayOneShot(soundFire1);

		Debug.LogWarning("Projectile Launched");
		Instantiate(ShellPrefab,                    //Object to Spawn
				SpawnLocation.transform.position,   //Position to Spawn Object
				SpawnLocation.transform.rotation);  //Rotation to Spawn Object
	}

	private void Fire2() //Checks if player has used ability and if fire2 is on cooldown, if available then call FireProjectile.
	{
		if (fireTwoIsEnabled)   //If the player can fire
		{
			if (fireTwoCooldown <= 0)   //If the ability is not on cooldown
			{
				fireTwoCooldown = fireTwoCooldownTime;

				float audioShift = Random.Range(-.15f, .15f);
				soundEffect.pitch = 1 + audioShift;
				soundEffect.PlayOneShot(soundFire2);

				//Raycasting
				Ray directionRay = new Ray(gameObject.transform.position, gameObject.transform.forward);

				rayDrawDistance = rayCastDistance;

				RaycastHit hit;

				bool foundhit = Physics.Raycast(directionRay, out hit, rayCastDistance);
				if (foundhit)
				{
					rayDrawDistance = hit.distance; //If there is a hit, set the draw distance of the ray to the contact point.
					Debug.Log("Found: " + hit.collider.gameObject.name);
					HitIcon.transform.position = hit.point; //When there is a hit, place object at contact point
				}
				else
				{
					HitIcon.transform.position = new Vector3(0, -10, 0); //Move to hidden position when not in use
				}
			}
		}
	}

	public void Reset()
	{
		Instantiate(DeathDecal,                    //Object to Spawn
		gameObject.transform.position,   //Position to Spawn Object
		gameObject.transform.rotation);  //Rotation to Spawn Object

		gameObject.transform.position = StartingLocation;
		gameObject.transform.rotation = StartingRotation;
	}
}
