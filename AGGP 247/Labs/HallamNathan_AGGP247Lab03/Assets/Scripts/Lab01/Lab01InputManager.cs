using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Lab01InputManager : MonoBehaviour
{
	Lab01 main;

	Lab01Binds gridBindings;

	InputAction gridSize;
	InputAction divisionCount;
	InputAction placeOrigin;
	InputAction toggleOrigin;
	InputAction toggleAxis;
	InputAction toggleDividers;
	InputAction cursor;

	InputAction modifier;

	bool modifierPressed;

	private void Awake()
	{
		main = GetComponent<Lab01>();

		gridBindings = new Lab01Binds();

		gridSize = gridBindings.Grid.Gridsize;
		gridSize.performed += ChangeGridSize;

		divisionCount = gridBindings.Grid.DivisionCount;
		divisionCount.performed += ChangeDivisionCount;

		placeOrigin = gridBindings.Grid.PlaceOrigin;
		placeOrigin.performed += PlaceOrigin;

		toggleOrigin = gridBindings.Grid.ToggleOrigin;
		toggleOrigin.performed += ToggleOrigin;

		toggleAxis = gridBindings.Grid.ToggleAxis;
		toggleAxis.performed += ToggleAxis;

		toggleDividers = gridBindings.Grid.ToggleDividers;
		toggleDividers.performed += ToggleDividers;

		cursor = gridBindings.Grid.Cursor;

		modifier = gridBindings.Grid.Modifier;
	}

	private void OnEnable()
	{		
		gridSize.Enable();		
		divisionCount.Enable();		
		placeOrigin.Enable();		
		toggleOrigin.Enable();		
		toggleAxis.Enable();	
		toggleDividers.Enable();

		cursor.Enable();

		modifier.Enable();
	}

	private void OnDisable()
	{
		gridSize.Disable();
		divisionCount.Disable();
		placeOrigin.Disable();
		toggleOrigin.Disable();
		toggleAxis.Disable();
		toggleDividers.Disable();

		cursor.Disable();

		modifier.Disable();
	}

	private void Update()
	{
		modifierPressed = modifier.IsPressed();
	}

	private void ChangeGridSize(InputAction.CallbackContext context)
	{
		if (!modifierPressed)
		{
			if (context.ReadValue<float>() < 0 && main.getGrid.gridSize > main.getGrid.minGridSize)
			{
				main.getGrid.gridSize--;
			}
			else if (context.ReadValue<float>() > 0)
			{
				main.getGrid.gridSize++;
			}
		}
	}

	private void ChangeDivisionCount(InputAction.CallbackContext context)
	{
		if (context.ReadValue<float>() < 0 && main.getGrid.divisionCount > main.getGrid.minDivisionCount)
		{
			main.getGrid.divisionCount--;
		}
		else if (context.ReadValue<float>() > 0)
		{
			main.getGrid.divisionCount++;
		}
	}

	private void PlaceOrigin(InputAction.CallbackContext context)
	{
		Vector2 position = cursor.ReadValue<Vector2>();

		main.getGrid.origin = new Vector2(Mathf.FloorToInt(position.x), Mathf.FloorToInt(position.y));
	}

	private void ToggleOrigin(InputAction.CallbackContext context)
	{
		if (main.isDrawingOrigin)
		{
			main.isDrawingOrigin = false;
		}
		else
		{
			main.isDrawingOrigin = true;
		}
	}

	private void ToggleAxis(InputAction.CallbackContext context)
	{
		if (main.isDrawingAxis)
		{
			main.isDrawingAxis = false;
		}
		else
		{
			main.isDrawingAxis = true;
		}
	}

	private void ToggleDividers(InputAction.CallbackContext context)
	{
		if (main.isDrawingDivisions)
		{
			main.isDrawingDivisions = false;
		}
		else
		{
			main.isDrawingDivisions = true;
		}
	}
}
