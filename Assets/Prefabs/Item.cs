using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
	public ItemSO itemSO;

	public virtual void GetBonus(PlayerController player)
	{
		Debug.Log(itemSO.ItemName);
	}

	public void GetStatsBonus(PlayerController player)
	{
		player.Strength += itemSO.bonusStrength;
		player.Agility += itemSO.bonusAgility;
		player.Intelligence += itemSO.bonusIntelligence;
		player.speedMove += itemSO.bonusSpeed;
	}
}
