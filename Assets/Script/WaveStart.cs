using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveStart : MonoBehaviour
{
    [SerializeField]
    Spawnser spawnser;

    public bool waving = false; // ���� ���� ���θ� ����

    public void SetWave()
    {
        Debug.Log("���̺� ����");
        if (spawnser.gameProgress) // ���� ���� �� �ߺ� ���� ����
        {
            waving = true;
            Debug.Log("���̺� ���");
        }
    }
}