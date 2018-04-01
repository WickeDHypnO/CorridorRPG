using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropController : MonoBehaviour {

	public List<float> dropChances;
	public float dropChance;
	public List<float> moneyDrops;

	public void DropItems()
	{
		var money = Random.Range(0, moneyDrops.Count);
		Debug.Log("Dropped " + moneyDrops[money] + " gold");
		var drop = Random.Range(0f, 1f);
		if(drop <= dropChance)
		{
			var item = Random.Range(0f,1f);
			if(item <= dropChances[0])
			{
				Debug.Log("Legendary");
			}
			else if(item <= dropChances[1])
			{
				Debug.Log("Epic");
			}
			else if(item <= dropChances[2])
			{
				Debug.Log("Rare");
			}
			else
			{
				Debug.Log("Common");
			}
		}
	}
}
