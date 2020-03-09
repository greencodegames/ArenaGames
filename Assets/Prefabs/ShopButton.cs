using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopButton : MonoBehaviour
{
   public void TakeItem()
	{
		string t;
		t = transform.Find("itemName").GetComponent<Text>().text;
		Debug.Log(t);
	}
}
