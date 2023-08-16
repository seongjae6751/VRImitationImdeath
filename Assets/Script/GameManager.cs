using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public PoolManager pool;

    public int nowGold = 0; // 현재 골드 보유량(골드 상태 창은 비활성화 되어있으므로 대신 정보를 받아줌)

    private void Awake()
    {
        Instance = this;
    }

    public void AddGold(int _cash) // 몬스터 죽이면 돈 얻기
    {
        nowGold += _cash;
    }

}
