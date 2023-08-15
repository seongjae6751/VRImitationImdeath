using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveStart : MonoBehaviour
{
    [SerializeField]
    Spawnser spawnser;

    public bool waving = false;

    public void SetWave()
    {
        if (!spawnser.gameProgress)
        {
            waving = true;
        }
    }
}