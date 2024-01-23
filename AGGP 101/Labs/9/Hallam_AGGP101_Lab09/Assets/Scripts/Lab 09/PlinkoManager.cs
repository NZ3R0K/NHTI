using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlinkoManager : MonoBehaviour
{
	public static PlinkoManager self;


	int Score = 0;

	public TextMeshProUGUI ScoreField;

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
		Score = 0;
	}

	private void Update()
	{
		SetField();
	}

	public void SetField()
	{
		ScoreField.text = "Score: " + Score;
	}

	public void AddScore(int score)
	{
		Score += score;
	}
}
