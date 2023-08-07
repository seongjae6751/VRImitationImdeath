using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    // 몬스터 정보
    public float speed; // 몬스터 속도
    public float health; // 현재 체력
    public float maxHealth; // 스폰시 체력
    bool isLive = true; // 살아있는지 여부

    /*public SpawnData[] spawnData;*/
    bool tryOnce = true; // nav mesh 오류로 인한 컨트롤

    Vector3 destination = new Vector3(-14.527f, 31.433f, -28.151f); // 목적지(게이트 위치)

    [SerializeField] private Animator anim;
    [SerializeField] private NavMeshAgent nav;


    // 다른 스크립트로 옮기고 싶은 정보들
    List<Vector3> spawnPoint = new List<Vector3>(); // 스폰 포인트의 이름과 벡터값으로 이루어진 딕셔너리
    public int[] nextMob = { 1, 2, 4, 5, 7, 10, 11, 13, 15, 17, 18, 20, 22, 24, 30 }; // 스테이지 별 소환 몬스터 수
    public int level = 1; // 스테이지 레벨
    private int seed;
    private System.Random random;
    private int randomNumber;

    Vector3 RoofWay = new Vector3(-45.010f, 36.7426f, 11.56856f);
    Vector3 Far = new Vector3(4.01f, 41.3326f, 19.27856f);
    Vector3 Temple1Left = new Vector3(-7.004f, 36.549f, 8.2085f);
    Vector3 Temple1right = new Vector3(2.3358f, 36.548f, 9.6885f);
    Vector3 Invisible = new Vector3(37.065f, 40.047f, -10.661f);
    Vector3 Temple2Left = new Vector3(33.785f, 34.082f, -10.631f);
    Vector3 Temple2Middle = new Vector3(34.945f, 34.065f, -14.291f);
    Vector3 Temple2Right = new Vector3(37.145f, 34.067f, -17.731f);
    Vector3 Underground = new Vector3(34.715f, 25.327f, -19.851f);

    void Start()
    {
        AddData();
        anim = GetComponent<Animator>();
        nav = GetComponent<NavMeshAgent>();
        nav.enabled = false;
    }

    void Update()
    {
        for (int i = 0; i <= nextMob[2]; i++)
        {
            int seed = System.DateTime.Now.Millisecond;
            random = new System.Random(seed);
            Spawn();
        }
        nav.enabled = true;
        tryOnce = false;
        if (tryOnce)
        {
            
        }
        if (isLive)
        {
            nav.speed = speed;
            Move();
        }
    }


    void AddData() // 스폰 포인트 추가
    {
        spawnPoint.Add(RoofWay);
        spawnPoint.Add(Far);
        spawnPoint.Add(Temple1Left);
        spawnPoint.Add(Temple1right);
        spawnPoint.Add(Invisible);
        spawnPoint.Add(Temple2Left);
        spawnPoint.Add(Temple2Middle);
        spawnPoint.Add(Temple2Right);
        spawnPoint.Add(Underground);
    }

    public void Spawn()
    {
        randomNumber = random.Next(0, 8);
        GameObject enemy = GameManager.Instance.pool.Get(0);
        enemy.transform.position = spawnPoint[randomNumber];
        // enemy.GetComponent<Enemy>().Init(spawnData[level]);
    }

    private void Move()
    {
        nav.SetDestination(destination);
    }

    public void Init(SpawnData data)
    {
        isLive = true;
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

        if (health <= 0)
        {
            Dead();
            return;
        }

        // 다치는 소리
    }

    private void Dead()
    {
        anim.SetTrigger("Dead");
        gameObject.SetActive(false);
        isLive = false;
    }
}

public class SpawnData
{
    public int spawnTime;
    public int health;
    public float speed;
}