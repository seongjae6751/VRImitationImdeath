using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveStart : MonoBehaviour
{
    [SerializeField]
    Spawnser spawnser;

    public AudioSource bellSound;

    public bool waving = false; // ���� ���� ���θ� ����

    public void SetWave()
    {
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().volume = 1;
        GetComponent<AudioSource>().Play();
        if (spawnser.gameProgress) // ���� ���� �� �ߺ� ���� ����
        {
            waving = true;
            Debug.Log("�Ҹ� üũ");
        }
    }
}