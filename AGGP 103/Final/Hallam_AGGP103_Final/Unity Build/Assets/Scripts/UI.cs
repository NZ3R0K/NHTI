using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;	

public class UI : MonoBehaviour
{
	public Image Health;
	public Image Mana;
	public Image DebuffOutline;
	public Image DebuffBar;
	public Image Icon;

	public PlayerController pc;


	private void Awake()
	{
		pc.currentHealth = pc.maxHealth;
		pc.currentMana = pc.maxMana;
	}

	private void FixedUpdate()
	{
		float healthPercentage = pc.currentHealth / pc.maxHealth;
		float manaPercentage = pc.currentMana / pc.maxMana;
		float poisonPercentage = pc.debuffTime / pc.debuffSetTime;


		Health.fillAmount = healthPercentage;
		Mana.fillAmount = manaPercentage;
		DebuffBar.fillAmount = poisonPercentage;

		if (pc.effectPoison == false)
		{
			DebuffBar.enabled = false;
			DebuffOutline.enabled = false;
			Icon.enabled = false;
		}
		else
		{
			DebuffBar.enabled = true;
			DebuffOutline.enabled = true;
			Icon.enabled = true;
		}
	}
}
