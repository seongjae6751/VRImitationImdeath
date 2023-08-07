using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public GameObject[] prefabs; // ���� ������ ���� ����

    List<GameObject>[] pools; // Ǯ ��� ����Ʈ

    private void Awake() // pool �ʱ�ȭ
    {
        pools = new List<GameObject>[prefabs.Length];

        for (int index = 0; index < pools.Length; index++)
        {
            pools[index] = new List<GameObject>();
        }
    }

    public GameObject Get(int index) // ���� ��ȯ �Լ�
    {
        GameObject select = null;

        foreach (GameObject item in pools[index]) // ��Ȱ��ȭ �� �����տ� ����
        {
            select = item; // �߰��ϸ� select ������ �Ҵ�
            select.SetActive(true);
            break;
        }

        if (!select) // ������ ���Ӱ� ����
        {
            select = Instantiate(prefabs[index], transform);
            pools[index].Add(select);
        }

        return select;
    }
}
