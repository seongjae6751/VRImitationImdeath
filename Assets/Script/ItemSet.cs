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

    private bool itemActive = true;

    // Update is called once per frame
    void Update()
    {
        if (spawnser.allMob == 0 && itemActive)
        {
            itemSet.SetActive(true);
        }

        if (waveStart.waving)
        {
            itemSet.SetActive(false);
            itemActive = false;
        }
    }
}
