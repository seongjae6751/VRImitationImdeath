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
        if (spawnser.allMob == 0 && itemActive)
        {
            itemSet.SetActive(true);
            itemActive = false;
            gatelevel.GateLevelUp();
            gatelevel.CheckLevel();
            spawnser.gameProgress = true;
        }
    }

    public void SetItem()
    {
        itemSet.SetActive(false);
    }
}
