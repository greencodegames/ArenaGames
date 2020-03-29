using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainShop : MonoBehaviour
{
	public GameObject MainShopUI;

	private void Start()
	{
		MainShopUI.SetActive(false);
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
			MainShopUI.SetActive(true);
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
			MainShopUI.SetActive(false);
	}
}
