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
    public bool once = true; // 몬스터 수를 한번만 차감하기 위한 장치
    public int bodyValue; // 몬스터의 몸 값

    [SerializeField] private Animator anim;
    

    void Start()
    {
        anim = GetComponent<Animator>();
        health = maxHealth;
    }

    void Update()
    {
        if (health <= 0 && once) // 체력이 0이면 사망
        {
            Dead();
            once = false;
        }
    }

    // 초기 세팅
/*    public void Init(SpawnData data)
    {
        isLive = true;
        speed = data.speed;
        maxHealth = data.health;
        health = data.health;
    }*/

    // 화살 맞으면 데미지
    public void Damage(int _dmg, Vector3 _targetPos) // 체력 차감
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
        GameObject.FindWithTag("Spawnser").GetComponent<Spawnser>().allMob -= 1; // 죽으면 소환된 현재 몬스터 수 하나 차감
        GameObject.FindWithTag("GameManager").GetComponent<GameManager>().AddGold(bodyValue); // 몸값만큼 돈 얻기
        anim.SetTrigger("Dead"); // 죽는 애니매이션 재생
        Destroy(gameObject, 4f); // 게임오브젝트 파괴
        isLive = false; 
    }
}
/*
public class SpawnData
{
    public int spawnTime;
    public int health;
    public float speed;
}*/