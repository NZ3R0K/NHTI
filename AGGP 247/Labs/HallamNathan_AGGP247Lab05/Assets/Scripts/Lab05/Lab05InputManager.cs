using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Lab05InputManager : MonoBehaviour
{
	Lab05Part1 shipMain;
	Lab05Part2 cannonMain;

	Lab05Binds Bindings;

	InputActionMap ShipMap;
	InputActionMap CannonMap;

	InputAction switchScene;

	InputAction shipThrust;
	InputAction shipRotate;

	InputAction cannonPower;
	InputAction cannonRotation;
	InputAction cannonShoot;

	private void Awake()
	{
		shipMain = GetComponent<Lab05Part1>();
		cannonMain = GetComponent<Lab05Part2>();

		Bindings = new Lab05Binds();

		switchScene = Bindings.General.SwitchScene;
		switchScene.performed += SwitchScene;

		ShipMap = Bindings.Ship;
		shipThrust = Bindings.Ship.Thrust;
		shipThrust.performed += ShipThrust;
		shipThrust.canceled += ShipThrust;
		shipRotate = Bindings.Ship.Rotate;
		shipRotate.performed += ShipRotate;
		shipRotate.canceled += ShipRotate;

		CannonMap = Bindings.Cannon;
		cannonPower = Bindings.Cannon.ChangePower;
		cannonPower.performed += CannonPower;
		cannonRotation = Bindings.Cannon.Rotate;
		cannonRotation.performed += CannonRotate;
		cannonShoot = Bindings.Cannon.Shoot;
		cannonShoot.performed += CannonShoot;
	}

	private void OnEnable()
	{
		switchScene.Enable();

		if (shipMain.enabled)
		{
			ShipMap.Enable();
			CannonMap.Disable();
			cannonMain.enabled = false;
		}
		if (cannonMain.enabled)
		{
			ShipMap.Disable();
			CannonMap.Enable();
			shipMain.enabled = false;
		}
	}

	private void OnDisable()
	{
		ShipMap.Disable();
		CannonMap.Disable();
		switchScene.Disable();
	}

	private void SwitchScene(InputAction.CallbackContext context)
	{
		if (ShipMap.enabled)
		{
			ShipMap.Disable();
			shipMain.enabled = false;
			CannonMap.Enable();
			cannonMain.enabled = true;
		}
		else if (!ShipMap.enabled)
		{
			ShipMap.Enable();
			shipMain.enabled = true;
			CannonMap.Disable();
			cannonMain.enabled = false;
		}
	}

	private void ShipThrust(InputAction.CallbackContext context)
	{
		shipMain.ship.InputVelocity.y = context.ReadValue<float>();
	}

	private void ShipRotate(InputAction.CallbackContext context)
	{
		shipMain.ship.InputVelocity.x = context.ReadValue<float>();
	}

	private void CannonPower(InputAction.CallbackContext context)
	{
		cannonMain.cannon.ChangePower(context.ReadValue<float>());
	}

	private void CannonRotate(InputAction.CallbackContext context)
	{
		cannonMain.cannon.Rotate(context.ReadValue<float>());
	}

	private void CannonShoot(InputAction.CallbackContext context)
	{
		cannonMain.cannon.Shoot();
	}
}
