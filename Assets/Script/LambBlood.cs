using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LambBlood : Item // ������ Ŭ������ ���
{
    [SerializeField]
    GateDurability gateDurability; 

    public override void PullItem()
    {
        if (transform.position.z <= rightHand.transform.position.z)
        {
            base.PullItem(); // �θ� Ŭ������ �޼ҵ� ����
            Destroy(gameObject); // ������ ��� �� ������ �ı�
        }
        gateDurability.setCount--; // ������ ����� ���� ü�� ����
        gateDurability.durabilityImage[10 - gateDurability.setCount].enabled = true;
    }
}
