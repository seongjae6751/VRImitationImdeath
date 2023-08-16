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
        if (spawnser.allMob == 0 && itemActive) // ��� ���� ������ ���� ���� â ����
        {
            itemSet.SetActive(true); // ������ Ȱ��ȭ
            itemActive = false; // ��� ������ Ȱ��ȭ �Ǵ� �� ����
            gatelevel.GateLevelUp(); // ������ Ȱ��ȭ�� ���ÿ� ����Ʈ ���� �ø���
            gatelevel.CheckLevel(); // ����Ʈ ���� ���� ���� �� ǥ��
            spawnser.gameProgress = true; // �ٽ� ������ �� �ְ� �� ����
        }
    }

    public void SetItem() // ������ ��Ȱ��ȭ �Լ�
    {
        itemSet.SetActive(false);
    }
}
