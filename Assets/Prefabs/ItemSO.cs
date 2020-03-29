using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Item", fileName = "New Item")]
public class ItemSO : ScriptableObject
{
	[SerializeField] private string itemName;

	public string ItemName
	{
		get { return itemName; }
		set { itemName = value; }
	}

	[SerializeField] private Sprite itemImage;
	public Sprite ItemImage
	{
		get { return itemImage; }
		set { itemImage = value; }
	}

	[SerializeField] private int itemCost;
	public int ItemCost
	{
		get { return itemCost; }
		set { itemCost = value; }
	}

	[SerializeField] private int itemDamage;
	public int ItemDamage
	{
		get { return itemDamage; }
		set { itemDamage = value; }
	}

	[SerializeField] private int itemArmor;
	public int ItemArmor
	{
		get { return itemArmor; }
		set { itemArmor = value; }
	}

	[SerializeField] private float WeaponSpeedAttack;
	public float weaponSpeedAttack
	{
		get { return WeaponSpeedAttack; }
		set { WeaponSpeedAttack = value; }
	}

	[SerializeField] private float BonusStrength;
	public float bonusStrength
	{
		get { return BonusStrength; }
		set { BonusStrength = value; }
	}

	[SerializeField] private float BonusAgility;
	public float bonusAgility
	{
		get { return BonusAgility; }
		set { BonusAgility = value; }
	}

	[SerializeField] private float BonusIntelligence;
	public float bonusIntelligence
	{
		get { return BonusIntelligence; }
		set { BonusIntelligence = value; }
	}

	[SerializeField] private float BonusSpeed;
	public float bonusSpeed
	{
		get { return BonusSpeed; }
		set { BonusSpeed = value; }
	}

	public enum TypeItem
	{
		Armor,
		Weapon,
	}
	public TypeItem typeItem;

}
