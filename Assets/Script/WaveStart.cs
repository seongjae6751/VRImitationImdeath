using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveStart : MonoBehaviour
{
    [SerializeField]
    Spawnser spawnser;

    public bool waving = false; // 스폰 시작 여부를 결정

    public void SetWave()
    {
        Debug.Log("웨이브 실행");
        if (spawnser.gameProgress) // 게임 진행 중 중복 스폰 방지
        {
            waving = true;
            Debug.Log("웨이브 사실");
        }
    }
}