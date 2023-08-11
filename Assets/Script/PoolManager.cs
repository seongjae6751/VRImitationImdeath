using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public GameObject[] prefabs; // ���� ������ ���� ����

    List<GameObject>[] pools; // Ǯ ��� ����Ʈ

    public int poolCount = 0;

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
        GameObject select = Instantiate(prefabs[index], transform);

        /*        GameObject select = null;
                foreach (GameObject item in pools[index]) // ��Ȱ��ȭ �� �����տ� ����
                {
                    select = item; // �߰��ϸ� select ������ �Ҵ�
                    select.SetActive(true);
                    break;
                }
                if (!select) // ������ ���Ӱ� ����
                {
                    select = Instantiate(prefabs[index], transform);
                    pools[poolCount].Add(select);
                }*/
        return select;
    }
}
