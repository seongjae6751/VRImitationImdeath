using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] 
    Enemy enemy;
    [SerializeField]
    public NavMeshAgent nav;

    Vector3 destination = new Vector3(-14.527f, 31.433f, -28.151f); // 목적지(게이트 위치)

    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        nav.enabled = false; // 몬스터 스폰 전에 내비 매시를 꺼야 함(setDestination함수를 위함)
        nav.speed = enemy.speed;
    }

    void Update()
    {
        if (!GameObject.FindWithTag("Spawnser").GetComponent<Spawnser>().setNav) // 스폰 되었는지 확인
        {
            nav.enabled = true; // 스폰 되었으면 내비 메시 다시 켬
        }
        if (enemy.isLive)
        {
            Move(); // 살아있으면 움직이게 함
        }
        if (!enemy.isLive) 
        {
            nav.enabled = false; // 몹 죽으면 내비 메시 끔
        }
    }
/*    public void SetBool(bool _nav)
    {
        nav.enabled = _nav;
    }

    public void SetNav(bool _nav)
    {
        nav.enabled = _nav;
    }*/

    private void Move() 
    {
        nav.SetDestination(destination); // 목적지까지 이동
    }
}
