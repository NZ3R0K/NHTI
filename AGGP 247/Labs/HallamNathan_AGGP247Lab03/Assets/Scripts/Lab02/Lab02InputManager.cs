using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Lab02InputManager : MonoBehaviour
{
	Lab02 main;

	Lab02Binds gridBindings;

	InputAction gridSize;
	InputAction divisionCount;
	InputAction placeOrigin;
	InputAction toggleOrigin;
	InputAction toggleAxis;
	InputAction toggleDividers;
	InputAction toggleShapes;
	InputAction toggleParabolas;
	InputAction cursor;

	InputAction modifier;

	bool modifierPressed;

	private void Awake()
	{
		main = GetComponent<Lab02>();

		gridBindings = new Lab02Binds();

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

		toggleShapes = gridBindings.Grid.ToggleShapes;
		toggleShapes.performed += ToggleShapes;

		toggleParabolas = gridBindings.Grid.ToggleParabolas;
		toggleParabolas.performed += ToggleParabolas;

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
		toggleShapes.Enable();
		toggleParabolas.Enable();

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
		toggleShapes.Disable();
		toggleParabolas.Disable();

		cursor.Disable();

		modifier.Disable();
	}

	private void Update()
	{
		modifierPressed = modifier.IsPressed();
	}

	private void ChangeGridSize(InputAction.CallbackContext context)
	{
		if (modifierPressed) return;
		
		if (context.ReadValue<float>() < 0 && main.getGrid.gridSize > main.getGrid.minGridSize)
			main.getGrid.gridSize--;
		else if (context.ReadValue<float>() > 0)
			main.getGrid.gridSize++;	
	}

	private void ChangeDivisionCount(InputAction.CallbackContext context)
	{
		if (context.ReadValue<float>() < 0 && main.getGrid.divisionCount > main.getGrid.minDivisionCount)
			main.getGrid.divisionCount--;
		else if (context.ReadValue<float>() > 0)
			main.getGrid.divisionCount++;
	}

	private void PlaceOrigin(InputAction.CallbackContext context)
	{
		Vector2 position = cursor.ReadValue<Vector2>();

		main.getGrid.origin = new Vector2(Mathf.FloorToInt(position.x), Mathf.FloorToInt(position.y));

		main.initializeOriginPoints = false;
		main.initializeSpinningDiamond = false;
	}

	private void ToggleOrigin(InputAction.CallbackContext context)
	{
		main.isDrawingOrigin = !main.isDrawingOrigin;
	}

	private void ToggleAxis(InputAction.CallbackContext context)
	{
		main.isDrawingAxis = !main.isDrawingAxis;
	}

	private void ToggleDividers(InputAction.CallbackContext context)
	{
		main.isDrawingDivisions = !main.isDrawingDivisions;
	}

	private void ToggleShapes(InputAction.CallbackContext context)
	{
		main.isDrawingShapes = !main.isDrawingShapes;
	}

	private void ToggleParabolas(InputAction.CallbackContext context)
	{
		main.isDrawingParabolas = !main.isDrawingParabolas;
	}
}
