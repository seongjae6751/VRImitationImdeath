using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Spawnser : MonoBehaviour
{

    //public Transform[] spawnPoint2;
    //public SpawnData[] spawnData;

    // 스폰 포인트
    // 다른 스크립트로 옮기고 싶은 정보들
    List<Vector3> spawnPoint = new List<Vector3>(); // 스폰 포인트의 이름과 벡터값으로 이루어진 딕셔너리
    public int[] nextMob = { 1, 2, 4, 5, 7, 10, 11, 13, 15, 17, 18, 20, 22, 24, 30 }; // 스테이지 별 소환 몬스터 수
    public int level = 1; // 스테이지 레벨
    private System.Random random;
    private int randomNumber;
    public bool tryOnce = true; // nav mesh 오류로 인한 컨트롤
    bool isLive = true; // 살아있는지 여부
    public int allMob;

    [SerializeField]
    WaveStart wavestart;

    Vector3 RoofWay = new Vector3(-45.010f, 36.7426f, 11.56856f);
    Vector3 Far = new Vector3(4.01f, 41.3326f, 19.27856f);
    Vector3 Temple1Left = new Vector3(-7.004f, 36.549f, 8.2085f);
    Vector3 Temple1right = new Vector3(2.3358f, 36.548f, 9.6885f);
    Vector3 Invisible = new Vector3(37.065f, 40.047f, -10.661f);
    Vector3 Temple2Left = new Vector3(33.785f, 34.082f, -10.631f);
    Vector3 Temple2Middle = new Vector3(34.945f, 34.065f, -14.291f);
    Vector3 Temple2Right = new Vector3(37.145f, 34.067f, -17.731f);
    Vector3 Underground = new Vector3(34.715f, 25.327f, -19.851f);


    void Awake()
    {
        AddData();
    }


    private void Update()
    {
        if (tryOnce && wavestart.waving)
        {
            Spawn();
            tryOnce = false;
        }

        if (allMob == 0)
        {
            // 아이템 선택
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
        allMob = nextMob[3];
        for (int i = 0; i < nextMob[3]; i++)
        {
            int seed = System.DateTime.Now.Millisecond;
            random = new System.Random(seed);
            randomNumber = random.Next(0, 8);
            GameObject enemy = GameManager.Instance.pool.Get(0);
            enemy.transform.position = spawnPoint[randomNumber];
            // enemy.GetComponent<Enemy>().Init(spawnData[level]);
        }
    }

    public void SetBool()
    {
        tryOnce = false;
    }
}

/*[System.Serializable]
public class SpawnData
{
    public int spawnTime;
    public int health;
    public float speed;
}
*/