using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSet : MonoBehaviour
{
    [SerializeField]
    GameObject itemSet;

    [SerializeField]
    Spawnser spawnser;

    [SerializeField]
    WaveStart waveStart;

    [SerializeField]
    GateLevel gatelevel;

    public bool itemActive = true;

    // Update is called once per frame
    void Update()
    {
        if (spawnser.allMob == 0 && itemActive) // 모든 몬스터 죽으면 몬스터 선택 창 열림
        {
            itemSet.SetActive(true); // 아이템 활성화
            itemActive = false; // 계속 아이템 활성화 되는 것 방지
            gatelevel.GateLevelUp(); // 아이템 활성화와 동시에 게이트 레벨 올리기
            gatelevel.CheckLevel(); // 게이트 레벨 게임 월드 상 표시
            spawnser.gameProgress = true; // 다시 스폰할 수 있게 값 변경
        }
    }

    public void SetItem() // 아이템 비활성화 함수
    {
        itemSet.SetActive(false);
    }
}
