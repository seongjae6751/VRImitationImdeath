using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GateDurability : MonoBehaviour
{
    [SerializeField]
    public Image[] durabilityImage; // 게이트 내구도

    [SerializeField]
    GateLoop gateLoop; 
    public int setCount; // 게이트에 들어간 몬스터

    private void Update()
    {
        setCount = gateLoop.missingMob; // 게이트에 들어가는 몬스터
        if (setCount >= 1)
        {
            durabilityImage[10 - setCount].enabled = false; // 게이트에 들어가는 몬스터 수를 인덱스로 갖는 내구도 이미지 비활성화
        }
    }
}
