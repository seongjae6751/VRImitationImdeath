using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GateDurability : MonoBehaviour
{
    [SerializeField]
    public Image[] durabilityImage;

    [SerializeField]
    GateLoop gateLoop;
    public int setCount;

    // Update is called once per frame
    private void Update()
    {
        setCount = gateLoop.missingMob;
        durabilityImage[10 - setCount].enabled = false;
    }
}
