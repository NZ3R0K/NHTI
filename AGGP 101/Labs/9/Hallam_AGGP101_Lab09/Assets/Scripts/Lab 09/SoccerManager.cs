using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SoccerManager : MonoBehaviour
{
	public static SoccerManager self;


	int Player1Score = 0;
	int Player2Score = 0;

	public TextMeshProUGUI P1ScoreField;
	public TextMeshProUGUI P2ScoreField;

	private void Awake()
	{
		if (self)
		{
			Debug.LogWarning(self.gameObject.name + "Duplicate exists within instance, removing unneeded duplicates.");
			Destroy(this);
			return;
		}


		self = this;
	}

	private void Start()
	{
		Player1Score = 0;
		Player2Score = 0;
	}

	private void Update()
	{
		SetField();
	}

	public void SetField()
	{
		P1ScoreField.text = "P1: " + Player1Score;
		P2ScoreField.text = "P2: " + Player2Score;
	}

	public void AddScore(bool wasPlayer1)
	{
		if (wasPlayer1)
		{
			Player2Score++;
		}
		else
		{
			Player1Score++;
		}
	}
}
