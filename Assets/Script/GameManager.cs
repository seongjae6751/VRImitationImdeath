using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public PoolManager pool;

    public int nowGold = 0;

    private void Awake()
    {
        Instance = this;
    }

    public void AddGold(int _cash)
    {
        nowGold += _cash;
    }

}
