using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewSpiritItemObject", menuName = "Inventory/Items/SpiritItem")]
public class ItemSpirit_SO : Item_SO
{
    public void Awake()
    {
        type = ItemType.SPIRIT;
    }

    public PlayerCharacter_SO playerCharacter;
    public int spPlus;
}
