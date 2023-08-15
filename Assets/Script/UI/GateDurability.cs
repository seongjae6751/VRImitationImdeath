using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GateDurability : MonoBehaviour
{
    [SerializeField]
    public Image[] durabilityImage; // ����Ʈ ������

    [SerializeField]
    GateLoop gateLoop; 
    public int setCount; // ����Ʈ�� �� ����

    private void Update()
    {
        setCount = gateLoop.missingMob; // ����Ʈ�� ���� ����
        if (setCount >= 1)
        {
            durabilityImage[10 - setCount].enabled = false; // ����Ʈ�� ���� ���� ���� �ε����� ���� ������ �̹��� ��Ȱ��ȭ
        }
    }
}
