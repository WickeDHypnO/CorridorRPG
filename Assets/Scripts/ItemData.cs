using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
	Weapon,
	OffHand,
	Helmet,
	BodyArmor,
	LowerArmor
}

public class ItemData : ScriptableObject {
	public ItemType type;
	public Sprite icon;
}
