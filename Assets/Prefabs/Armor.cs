using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : Item
{ 
	public override void GetBonus(PlayerController player)
	{
		Debug.Log("Armor is " + itemSO.ItemArmor);
		GetStatsBonus(player);
	}
}
