using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
	private Transform shopList;
	public Transform shopItem;
	private ItemBuy itemBuy;
	private ShopLists shopLists;

	private void Awake()
	{
		shopLists = GameObject.FindGameObjectWithTag("GameController").GetComponent<ShopLists>();
		shopList = transform.Find("Shop");
		//shopItem = shopList.Find("ItemButton");
		shopItem.gameObject.SetActive(false);
	}

	private void Start()
	{
		for (int i = 0; i < shopLists.MainShop.Count; i++)
		{
			CreateItemButton(shopLists.MainShop[i], i);
		}
	}

	private void CreateItemButton(GameObject itemObject, int i)
	{
		var _item = itemObject.GetComponent<Item>();
		Transform shopItemTransform = Instantiate(shopItem, shopList);
		RectTransform shopItemRectTransform = shopItemTransform.GetComponent<RectTransform>();

		float shopItemHeight = 80f;
		shopItemRectTransform.anchoredPosition = new Vector2(0, -shopItemHeight * i);		
		shopItemTransform.GetComponent<ItemBuy>()._item = _item;
		shopItemTransform.gameObject.name = _item.itemSO.ItemName;
		shopItemTransform.Find("itemName").GetComponent<Text>().text = _item.itemSO.ItemName;
		shopItemTransform.Find("goldText").GetComponent<Text>().text = _item.itemSO.ItemCost.ToString();
		shopItemTransform.gameObject.SetActive(true);
	}
}
