using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Item
{
	public override void GetBonus(PlayerController player)
	{
		player.damage = itemSO.ItemDamage;
		Debug.Log("Damage is " + itemSO.ItemDamage);
		GetStatsBonus(player);
	}
}
