using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float speed; // ���� �ӵ�
    public float health; // ���� ü��
    public float maxHealth; // ������ ü��
    bool isLive = true; // ����ִ��� ����

    Vector3 destination = new Vector3(-14.527f, 31.433f, -28.151f); // ������(����Ʈ ��ġ)
    [SerializeField] private Animator anim;
    [SerializeField] private NavMeshAgent nav;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isLive)
        {
            nav.speed = speed;
            Move();
        }
    }

    private void Move()
    {
        nav.SetDestination(destination);
    }

    public void Init(SpawnData data)
    {
        speed = data.speed;
        maxHealth = data.health;
        health = data.health;
    }

    public void Damage(int _dmg, Vector3 _targetPos)
    {
        if (isLive)
        {
            health -= _dmg;
        }

        if (health <= 0 )
        {
            Dead();
            return;
        }

        // ��ġ�� �Ҹ�
    }

    private void Dead()
    {
        anim.SetTrigger("Dead");
        gameObject.SetActive(false);
        isLive = false;
    }
}
