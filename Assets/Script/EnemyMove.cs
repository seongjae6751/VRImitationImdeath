using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

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
        nav.enabled = false;
        nav.speed = enemy.speed;
    }

    void Update()
    {
        if (!GameObject.FindWithTag("Spawnser").GetComponent<Spawnser>().setNav)
        {
            nav.enabled = true;
        }
        if (enemy.isLive)
        {
            Move();
        }
    }
    public void SetBool(bool _nav)
    {
        nav.enabled = _nav;
    }

    public void SetNav(bool _nav)
    {
        nav.enabled = _nav;
    }

    private void Move()
    {
        nav.SetDestination(destination);
    }
}
