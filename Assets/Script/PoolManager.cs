using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public GameObject[] prefabs; // 몬스터 프리팹 보관 변수

    List<GameObject>[] pools; // 풀 담당 리스트

    private void Awake() // pool 초기화
    {
        pools = new List<GameObject>[prefabs.Length];

        for (int index = 0; index < pools.Length; index++)
        {
            pools[index] = new List<GameObject>();
        }
    }

    public GameObject Get(int index) // 몬스터 반환 함수
    {
        GameObject select = null;

        foreach (GameObject item in pools[index]) // 비활성화 된 프리팹에 접근
        {
            select = item; // 발견하면 select 변수에 할당
            select.SetActive(true);
            break;
        }

        if (!select) // 없으면 새롭게 생성
        {
            select = Instantiate(prefabs[index], transform);
            pools[index].Add(select);
        }

        return select;
    }
}
