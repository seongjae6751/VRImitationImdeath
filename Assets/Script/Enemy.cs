using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    // 몬스터 정보
    public float speed; // 몬스터 속도
    public float health; // 현재 체력
    public float maxHealth; // 스폰시 체력
    public bool isLive = true; // 살아있는지 여부
    public bool once = true;
    public int bodyValue;

    [SerializeField] private Animator anim;
    

    void Start()
    {
        anim = GetComponent<Animator>();
        health = maxHealth;
    }

    void Update()
    {
        if (health <= 0 && once) // 중복으로 현재 몬스터 수가 주는 것을 방지
        {
            Dead();
            once = false;
        }
    }

    // 초기 세팅
    public void Init(SpawnData data)
    {
        isLive = true;
        speed = data.speed;
        maxHealth = data.health;
        health = data.health;
    }

    // 화살 맞으면 데미지
    public void Damage(int _dmg, Vector3 _targetPos)
    {
        if (isLive)
        {
            health -= _dmg;
        }
        // 다치는 소리
    }

    // 죽으면 애니메이션 재생 및 파괴
    private void Dead()
    {
        GameObject.FindWithTag("Spawnser").GetComponent<Spawnser>().allMob -= 1;
        GameObject.FindWithTag("GameManager").GetComponent<GameManager>().AddGold(bodyValue);
        anim.SetTrigger("Dead");
        Destroy(gameObject, 4f);
        isLive = false;
    }
}

public class SpawnData
{
    public int spawnTime;
    public int health;
    public float speed;
}