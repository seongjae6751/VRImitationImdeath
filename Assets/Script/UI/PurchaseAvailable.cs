using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PurchaseAvailable : MonoBehaviour
{
    [SerializeField]
    GoldInfo goldInfo;

    [SerializeField]
    Text bloodPrice;

    [SerializeField]
    Text minePrice;

    public int item1BloodPrice = 1000;

    public int item2MinePrice = 2500;

    private void Update()
    {
        CheckBloodColor();
        CheckMineColor();
    }

    private void CheckBloodColor()
    {
        if (goldInfo.gold < item1BloodPrice)
        {
            bloodPrice.color = Color.red;
        }
        else
        {
            bloodPrice.color = Color.white;
        }
    }

    private void CheckMineColor()
    {
        if (goldInfo.gold < item2MinePrice)
        {
            minePrice.color = Color.red;
        }
        else
        {
            minePrice.color = Color.white;
        }

    }
}
