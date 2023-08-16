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
        gold = gameManager.nowGold; // 골드창은 비활성화 되었다가 켜지므로 항상 활성화인 게임 매니저한테 골드 정보를 받아옴
        CheckGold();
    }

    public void CheckGold() // 현재 골드 표시
    {
        goldReserves.text =  gold.ToString();
    }
}
