using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropController : MonoBehaviour
{

    public List<float> dropChances;
    public float dropChance;
    public List<float> moneyDrops;
    public List<ItemData> items;
    public ItemData lastDroppedItem;

    void Start()
    {
       // DropItems();
    }

    public void DropItems()
    {
        var money = Random.Range(0, moneyDrops.Count);
        Debug.Log("Dropped " + moneyDrops[money] + " gold");
        var drop = Random.Range(0f, 1f);
        if (drop <= dropChance)
        {
            var curItem = Random.Range(0, items.Count);
            var instItem = Instantiate(items[curItem]);
            instItem.level = Mathf.RoundToInt(instItem.baseLevel + Random.Range(0, instItem.levelRandom));
            Debug.Log(instItem.GetType());
            var itemRarity = Random.Range(0f, 1f);
            if (itemRarity <= dropChances[0])
            {
                instItem.rarity = Rarity.Legendary;
                Debug.Log("Legendary");
            }
            else if (itemRarity <= dropChances[1])
            {
				instItem.rarity = Rarity.Unique;
                Debug.Log("Epic");
            }
            else if (itemRarity <= dropChances[2])
            {
				instItem.rarity = Rarity.Rare;
                Debug.Log("Rare");
            }
            else
            {
				instItem.rarity = Rarity.Common;
                Debug.Log("Common");
            }
            if (instItem.GetType() == typeof(WeaponData))
            {
                var weapon = instItem as WeaponData;
                weapon.damage = Mathf.RoundToInt(weapon.damage + Random.Range(0, weapon.damageRandom));
                lastDroppedItem = weapon;
                weapon.RecalculateStats();
            }
            else
            {
                lastDroppedItem = instItem;
                instItem.RecalculateStats();
            }
        }
    }
}
