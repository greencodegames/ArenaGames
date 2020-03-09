using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
	private Transform shopList;
	private Transform shopItem;

	private void Awake()
	{
		shopList = transform.Find("Shop");
		shopItem = shopList.Find("ItemButton");
		shopItem.gameObject.SetActive(false);
	}

	private void Start()
	{
		CreateItemButton("Armor 1", 100, 0);
		CreateItemButton("Armor 2", 150, 1);
		CreateItemButton("Sword 1", 70, 2);
		CreateItemButton("Sword 2", 120, 3);
	}

	private void CreateItemButton(/*Sprite itemSprite,*/ string itemName, int itemCost, int positionIndex)
	{
		Transform shopItemTransform = Instantiate(shopItem, shopList);
		RectTransform shopItemRectTransform = shopItemTransform.GetComponent<RectTransform>();

		float shopItemHeight = 80f;
		shopItemRectTransform.anchoredPosition = new Vector2(0, -shopItemHeight * positionIndex);

		//shopItemTransform.Find("itemImage").GetComponent<Image>().sprite = itemSprite;
		shopItemTransform.Find("itemName").GetComponent<Text>().text = itemName;
		shopItemTransform.Find("goldText").GetComponent<Text>().text = itemCost.ToString();
		shopItemTransform.gameObject.SetActive(true);
	}
}
