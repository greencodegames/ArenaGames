using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ItemSO))]
public class ItemEditor : Editor
{
	private ItemSO _item;

	private void OnEnable()
	{
		_item = (ItemSO)target;
	}

	public override void OnInspectorGUI()
	{
		_item.ItemName = EditorGUILayout.TextField("Название предмета", _item.ItemName);
		_item.ItemCost = EditorGUILayout.IntField("Стоимость предмета", _item.ItemCost);
		_item.ItemImage = (Sprite)EditorGUILayout.ObjectField("Иконка предмета", _item.ItemImage, typeof(Sprite), false);

		_item.bonusStrength = EditorGUILayout.FloatField("Бонусная сила", _item.bonusStrength);
		_item.bonusAgility = EditorGUILayout.FloatField("Бонусная ловкость", _item.bonusAgility);
		_item.bonusIntelligence = EditorGUILayout.FloatField("Бонусный интеллект", _item.bonusIntelligence);
		_item.bonusSpeed = EditorGUILayout.FloatField("Бонусная скорость", _item.bonusSpeed);

		_item.typeItem = (ItemSO.TypeItem)EditorGUILayout.EnumPopup("Тип предмета", _item.typeItem);

		if(_item.typeItem == ItemSO.TypeItem.Weapon)
		{
			_item.ItemDamage = EditorGUILayout.IntField("Дамаг оружия", _item.ItemDamage);
			_item.weaponSpeedAttack = EditorGUILayout.FloatField("Скорость атаки оружия", _item.weaponSpeedAttack);
		}

		if(_item.typeItem == ItemSO.TypeItem.Armor)
		{
			_item.ItemArmor = EditorGUILayout.IntField("Показатель брони", _item.ItemArmor);
		}
	}
}
