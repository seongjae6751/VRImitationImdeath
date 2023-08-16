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

    public int gold = 0; // ���� ��� ������

    private void Update()
    {
        gold = gameManager.nowGold; // ���â�� ��Ȱ��ȭ �Ǿ��ٰ� �����Ƿ� �׻� Ȱ��ȭ�� ���� �Ŵ������� ��� ������ �޾ƿ�
        CheckGold();
    }

    public void CheckGold() // ���� ��� ǥ��
    {
        goldReserves.text =  gold.ToString();
    }
}
