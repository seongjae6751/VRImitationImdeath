using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GateLevel : MonoBehaviour
{
    public int gateLevel = 0; // 게이트 레벨
    public bool tryOnce = true;

    [SerializeField]
    Spawnser spawnser;

    [SerializeField]
    private Text level;

    private void Update()
    {
        if (spawnser.allMob == 0 && tryOnce)
        {
            gateLevel++;
            checkLevel();
            tryOnce = false;
        }
    }

    private void checkLevel()
    {
        level.text = "Wave" + gateLevel.ToString();
    }
}
