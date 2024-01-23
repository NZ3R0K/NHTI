using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Lab03InputManager : MonoBehaviour
{
	Lab03 main;

	Lab03Binds gridBindings;

	InputActionMap gridMap;
	InputActionMap defaultMap;
	InputActionMap circleMap;
	InputActionMap ellipseMap;

	InputAction gridSize;
	InputAction divisionCount;
	InputAction placeOrigin;
	InputAction toggleOrigin;
	InputAction toggleAxis;
	InputAction toggleDividers;
	InputAction toggleShapes;
	InputAction toggleParabolas;
	InputAction cursor;
	InputAction changeDrawingGroup;

	InputAction modifier;

	bool modifierPressed;

	InputAction moveCircle;
	InputAction toggleCircle;
	InputAction circleRadius;
	InputAction circleSideCount;

	InputAction moveEllipse;
	InputAction toggleEllipse;
	InputAction ellipseHorizontalAxis;
	InputAction ellipseVerticalAxis;
	InputAction ellipseSideCount;

	private void Awake()
	{
		main = GetComponent<Lab03>();

		gridBindings = new Lab03Binds();

		gridMap = gridBindings.Grid;
		defaultMap = gridBindings.Default;
		circleMap = gridBindings.Circle;
		ellipseMap = gridBindings.Ellipse;

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

		changeDrawingGroup = gridBindings.Grid.ChangeDrawingGroup;
		changeDrawingGroup.performed += ChangeDrawingGroup;

		modifier = gridBindings.Grid.Modifier;

		defaultMap.Enable();

		toggleShapes = gridBindings.Default.ToggleShapes;
		toggleShapes.performed += ToggleShapes;

		toggleParabolas = gridBindings.Default.ToggleParabolas;
		toggleParabolas.performed += ToggleParabolas;

		moveCircle = gridBindings.Circle.MoveCircle;
		moveCircle.performed += MoveCircle;
		toggleCircle = gridBindings.Circle.ToggleCricle;
		toggleCircle.performed += ToggleCircle;
		circleRadius = gridBindings.Circle.ChangeRadius;
		circleRadius.performed += ChangeCircleRadius;
		circleSideCount = gridBindings.Circle.ChangeSideCount;
		circleSideCount.performed += ChangeCircleSideCount;

		moveEllipse = gridBindings.Ellipse.MoveEllipse;
		moveEllipse.performed += MoveEllipse;
		toggleEllipse = gridBindings.Ellipse.ToggleEllipse;
		toggleEllipse.performed += ToggleEllipse;
		ellipseHorizontalAxis = gridBindings.Ellipse.ChangeHorizontalAxis;
		ellipseHorizontalAxis.performed += ChangeEllipseHorizontalAxis;	
		ellipseVerticalAxis = gridBindings.Ellipse.ChangeVerticalAxis;
		ellipseVerticalAxis.performed += ChangeEllipseVerticalAxis;
		ellipseSideCount = gridBindings.Ellipse.ChangeSideCount;
		ellipseSideCount.performed += ChangeEllipseSideCount;
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

		changeDrawingGroup.Enable();

		modifier.Enable();

		toggleShapes.Enable();
		toggleParabolas.Enable();
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

		changeDrawingGroup.Disable();

		modifier.Disable();

		toggleShapes.Disable();
		toggleParabolas.Disable();

		moveCircle.Disable();
		toggleCircle.Disable();
		circleRadius.Disable();
		circleSideCount.Disable();

		moveEllipse.Disable();
		toggleEllipse.Disable();
		ellipseHorizontalAxis.Disable();
		ellipseVerticalAxis.Disable();
		ellipseSideCount.Disable();
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

	private void ChangeDrawingGroup(InputAction.CallbackContext context)
	{
		main.currentDrawingGroup++;

		if (main.currentDrawingGroup > 2)
			main.currentDrawingGroup = 0;

		switch (main.currentDrawingGroup)
		{
			case 0:
				Debug.Log("Current Group : Grid");
				defaultMap.Enable();
				circleMap.Disable();
				ellipseMap.Disable();
				break;
			case 1:
				Debug.Log("Current Group : Circle");
				defaultMap.Disable();
				circleMap.Enable();
				ellipseMap.Disable();
				break;
			case 2:
				Debug.Log("Current Group : Ellipse");
				defaultMap.Disable();
				circleMap.Disable();
				ellipseMap.Enable();
				break;
		}
	}

	private void ChangeCircleRadius(InputAction.CallbackContext context)
	{
		if (context.ReadValue<float>() < 0 && main.getCircle.Width > 0)
			main.getCircle.Width--;
		else if (context.ReadValue<float>() > 0)
			main.getCircle.Width++;

		main.getCircle.ClearGeometrics();
	}

	private void ChangeCircleSideCount(InputAction.CallbackContext context)
	{
		if (context.ReadValue<float>() < 0 && main.getCircle.Sides > 2)
			main.getCircle.Sides--;
		else if (context.ReadValue<float>() > 0)
			main.getCircle.Sides++;

		main.getCircle.ClearGeometrics();
	}

	private void ToggleCircle(InputAction.CallbackContext context)
	{
		main.isDrawingCircle = !main.isDrawingCircle;
	}

	private void MoveCircle(InputAction.CallbackContext context)
	{
		Vector2 position = cursor.ReadValue<Vector2>();

		main.getCircle.Center = main.ScreenToGrid(new Vector2(Mathf.FloorToInt(position.x), Mathf.FloorToInt(position.y)));

		main.getCircle.ClearGeometrics();
	}

	private void ChangeEllipseHorizontalAxis(InputAction.CallbackContext context)
	{
		if (context.ReadValue<float>() < 0 && main.getEllipse.Axis.x > 0)
			main.getEllipse.Axis.x--;
		else if (context.ReadValue<float>() > 0)
			main.getEllipse.Axis.x++;

		main.getEllipse.ClearGeometrics();
	}

	private void ChangeEllipseVerticalAxis(InputAction.CallbackContext context)
	{
		if (context.ReadValue<float>() < 0 && main.getEllipse.Axis.y > 0)
			main.getEllipse.Axis.y--;
		else if (context.ReadValue<float>() > 0)
			main.getEllipse.Axis.y++;

		main.getEllipse.ClearGeometrics();
	}

	private void ChangeEllipseSideCount(InputAction.CallbackContext context)
	{
		if (context.ReadValue<float>() < 0 && main.getEllipse.Sides > 2)
			main.getEllipse.Sides--;
		else if (context.ReadValue<float>() > 0)
			main.getEllipse.Sides++;

		main.getEllipse.ClearGeometrics();
	}

	private void MoveEllipse(InputAction.CallbackContext context)
	{
		Vector2 position = cursor.ReadValue<Vector2>();

		main.getEllipse.Center = main.ScreenToGrid(new Vector2(Mathf.FloorToInt(position.x), Mathf.FloorToInt(position.y)));

		main.getEllipse.ClearGeometrics();
	}

	private void ToggleEllipse(InputAction.CallbackContext context)
	{
		main.isDrawingEllipse = !main.isDrawingEllipse;
	}
}
