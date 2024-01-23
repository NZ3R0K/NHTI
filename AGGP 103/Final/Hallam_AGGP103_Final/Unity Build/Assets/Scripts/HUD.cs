using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUD : MonoBehaviour
{
	public TextMeshProUGUI ShardText;
	public PlayerController pc;

	public void Update()
	{
		SetField();
	}

	public void SetField()
	{
		ShardText.text = pc.currentShards.ToString();
	}
}
