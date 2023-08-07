using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Spawnser : MonoBehaviour
{

    public Transform[] spawnPoint2;
    //public SpawnData[] spawnData;

    void Awake()
    {
        // spawnPoint2 = GetComponentsInChildren<Transform>();
    }

}

/*[System.Serializable]
public class SpawnData
{
    public int spawnTime;
    public int health;
    public float speed;
}
*/