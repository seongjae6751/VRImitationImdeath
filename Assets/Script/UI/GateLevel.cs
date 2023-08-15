using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GateLevel : MonoBehaviour
{
    public int gateLevel = 0; // ����Ʈ ����
    // public bool tryOnce = true;

    [SerializeField]
    Spawnser spawnser;

    [SerializeField]
    private Text level;

    public void GateLevelUp()
    {
        gateLevel++;
    }

    public void CheckLevel()
    {
        level.text = "Wave" + gateLevel.ToString();
    }
}
