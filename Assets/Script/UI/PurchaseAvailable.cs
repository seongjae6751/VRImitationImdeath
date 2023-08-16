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

    // 양의 피 가격
    public int item1BloodPrice = 1000;
    
    // 지뢰 가격
    public int item2MinePrice = 2500;

    private void Update()
    {
        CheckBloodColor();
        CheckMineColor();
    }

    private void CheckBloodColor() // 양의 피 살 수 없으면 빨간색, 있으면 흰색 표시
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

    private void CheckMineColor() // 지뢰 살 수 없으면 빨간색, 있으면 흰색 표시
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
