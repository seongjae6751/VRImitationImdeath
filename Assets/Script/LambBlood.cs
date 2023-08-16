using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LambBlood : Item // 아이템 클래스를 상속
{
    [SerializeField]
    GateDurability gateDurability; 

    public override void PullItem()
    {
        if (transform.position.z <= rightHand.transform.position.z)
        {
            base.PullItem(); // 부모 클래스의 메소드 실행
            Destroy(gameObject); // 아이템 흡수 시 아이템 파괴
        }
        gateDurability.setCount--; // 아이템 흡수시 포털 체력 증가
        gateDurability.durabilityImage[10 - gateDurability.setCount].enabled = true;
    }
}
