using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoccerNet : MonoBehaviour
{

	public bool isTeamA = true;

	void OnTriggerEnter(Collider other)
	{
		Debug.LogWarning("Entered: " + other.gameObject.name);

		SoccerBall soccerBallScr = other.gameObject.GetComponent<SoccerBall>();
		if (soccerBallScr)
		{
			Debug.LogWarning("Ball Entered the Net!");
			soccerBallScr.Reset();
			if (isTeamA)
			{
				Debug.Log("Team B Scored!");
			}
			if (!isTeamA)
			{
				Debug.Log("Team A Scored!");
			}
			SoccerManager.self.AddScore(isTeamA);
		}
	}

	void OnTriggerExit(Collider other)
	{
		Debug.LogWarning("Exited: " + other.gameObject.name);	
	}



}
