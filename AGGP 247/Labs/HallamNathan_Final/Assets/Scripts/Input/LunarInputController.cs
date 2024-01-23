using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LunarInputController : MonoBehaviour
{
	private Game _gameManager;

	public static Shuttle_InputActions landerActions;
	public InputActionMap shuttleMap { get; private set; }
	public InputActionMap systemMap { get; private set; }

	public void Awake()
	{
		_gameManager = GetComponent<Game>();

		if (landerActions == null)
			landerActions = new Shuttle_InputActions();
	}

	public void OnEnable()
	{
		shuttleMap = landerActions.Shuttle;
		systemMap = landerActions.System;

		landerActions.Shuttle.Thrust.performed += Shuttle_Thrust;
		landerActions.Shuttle.Rotate.performed += Shuttle_Rotate;

		landerActions.System.Play.performed += System_Play;
		landerActions.System.Exit.performed += System_Exit;

		shuttleMap.Enable();
		systemMap.Enable();
	}

	private void Shuttle_Thrust(InputAction.CallbackContext context)
	{
		_gameManager.shuttle.movement.y = context.ReadValue<float>();
	}

	private void Shuttle_Rotate(InputAction.CallbackContext context)
	{
		_gameManager.shuttle.movement.z = context.ReadValue<float>();
	}

	private void System_Play(InputAction.CallbackContext context)
	{
		if (!_gameManager.waitForInput) return;

		_gameManager.Restart();
		_gameManager.infoText.enabled = false;
		_gameManager.waitForInput = false;
	}

	private void System_Exit(InputAction.CallbackContext context)
	{
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#endif

		Application.Quit();
	}
}
