using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    // ���� ����
    public float speed; // ���� �ӵ�
    public float health; // ���� ü��
    public float maxHealth; // ������ ü��
    public bool isLive = true; // ����ִ��� ����
    public bool once = true; // ���� ���� �ѹ��� �����ϱ� ���� ��ġ
    public int bodyValue; // ������ �� ��

    [SerializeField] private Animator anim;
    

    void Start()
    {
        anim = GetComponent<Animator>();
        health = maxHealth;
    }

    void Update()
    {
        if (health <= 0 && once) // ü���� 0�̸� ���
        {
            Dead();
            once = false;
        }
    }

    // �ʱ� ����
/*    public void Init(SpawnData data)
    {
        isLive = true;
        speed = data.speed;
        maxHealth = data.health;
        health = data.health;
    }*/

    // ȭ�� ������ ������
    public void Damage(int _dmg, Vector3 _targetPos) // ü�� ����
    {
        if (isLive)
        {
            health -= _dmg;
        }
        // ��ġ�� �Ҹ�
    }

    // ������ �ִϸ��̼� ��� �� �ı�
    private void Dead()
    {
        GameObject.FindWithTag("Spawnser").GetComponent<Spawnser>().allMob -= 1; // ������ ��ȯ�� ���� ���� �� �ϳ� ����
        GameObject.FindWithTag("GameManager").GetComponent<GameManager>().AddGold(bodyValue); // ������ŭ �� ���
        anim.SetTrigger("Dead"); // �״� �ִϸ��̼� ���
        Destroy(gameObject, 4f); // ���ӿ�����Ʈ �ı�
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