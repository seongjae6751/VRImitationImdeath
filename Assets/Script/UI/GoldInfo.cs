using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldInfo : MonoBehaviour
{
    [SerializeField]
    Text goldReserves;

    [SerializeField]
    GameManager gameManager;

    public int gold = 0; // 현재 골드 보유량

    private void Update()
    {
        gold = gameManager.nowGold;
        CheckGold();
    }

    public void CheckGold()
    {
        goldReserves.text =  gold.ToString();
    }
}
