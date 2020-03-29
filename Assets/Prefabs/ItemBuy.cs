using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class ItemBuy : MonoBehaviour
{
	private PlayerController player;
	public Item _item;
	private bool flag = false;

	public void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
	}

	public void TakeItem()
	{
		if (player.itemList.Count != 0)
		{
			for (int i = 0; i < player.itemList.Count; i++)
			{
				if (_item.itemSO.typeItem == player.itemList[i].itemSO.typeItem)
				{
					flag = true;
					break;
				}
			}
			
			if(!flag)
			{
				if (player.gold - _item.itemSO.ItemCost >= 0)
					AddItem();
				else
					Debug.Log("Вам не хватает денег");
			}
			else
				Debug.Log("Вы уже купили " + _item.itemSO.ItemName);
		}
		else
			AddItem();
  }

	public void AddItem()
	{
		player.gold -= _item.itemSO.ItemCost;
		player.goldText.text = "Gold: " + player.gold;
		player.itemList.Add(_item);
		_item.GetBonus(player);
		Debug.Log(_item.itemSO.ItemName);
		gameObject.GetComponent<Image>().color = new Color(118/255.0f,78/255.0f, 53/255.0f);
	}
}
