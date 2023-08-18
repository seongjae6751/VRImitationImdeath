using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Spawnser : MonoBehaviour
{
    List<Vector3> spawnPoint = new List<Vector3>(); // 스폰 포인트의 이름과 벡터값으로 이루어진 딕셔너리
    public int[] nextMob = { 1, 2, 4, 5, 7, 10, 11, 13, 15, 17, 18, 20, 22, 24, 30 }; // 스테이지 별 소환 몬스터 수
    public int level = 1; // 스테이지 레벨
    private System.Random random;
    private int randomNumber; // 랜덤 스폰 장소
    public bool setNav = true; // nav mesh 오류로 인한 컨트롤
    public bool trySecond = false;
    private int mobNum = 0; // 몬스터 선택 범위
    private int setMob; // 어떤 몬스터를 스폰할 지 인덱스 값
    private int waveLevel; // 현재 게이트 레벨
    public bool gameProgress = true; // 게임 진행 중인지 여부(게임 중 중복 스폰을 방지하기 위함)
    public int allMob = 1; // 처음부터 아이템이 활성화 되는거 방지(아이템은 0이 되어야 보임)

    [SerializeField]
    WaveStart wavestart;

    [SerializeField]
    GateLevel gatelevel;

    [SerializeField]
    ItemSet itemset;

    // 스폰 포인트
    Vector3 RoofWay = new Vector3(-45.010f, 36.7426f, 11.56856f);
    Vector3 Far = new Vector3(4.01f, 41.3326f, 19.27856f);
    Vector3 Temple1Left = new Vector3(-7.004f, 36.549f, 8.2085f);
    Vector3 Temple1right = new Vector3(2.3358f, 36.548f, 9.6885f);
    Vector3 Invisible = new Vector3(37.065f, 40.047f, -10.661f);
    Vector3 Temple2Left = new Vector3(33.785f, 34.082f, -10.631f);
    Vector3 Temple2Middle = new Vector3(34.945f, 34.065f, -14.291f);
    Vector3 Temple2Right = new Vector3(38.26f, 34.067f, -17.731f);
    Vector3 Underground = new Vector3(34.715f, 34.06f, -21.29f);


    void Awake()
    {
        AddData();
    }


    private void Update()
    {
        SelectMob(gatelevel.gateLevel); 
        if (wavestart.waving && gameProgress) // 게임이 진행중이고 웨이브 시작시 
        {
            itemset.SetItem(); // 아이템 세트 비활성화
            waveLevel = gatelevel.gateLevel - 1; // 게이트 레벨은 1부터 시작하므로 리스트 인덱스 0과 맞추기 위함
            Spawn(waveLevel); // 몬스터 스폰
            wavestart.waving = false; // 중복 방지
            setNav = false; // 내비 메시 끄고 켜기 위한 trigger
            gameProgress = false; // 게임 중 중복 스폰 방지
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

    private void SelectMob(int _selmob) // 게이트 레벨에 따라 몹 선택 범위 결정
    {
        /* ex)0,1,2 레벨 - > 0번째 인덱스
              3,4,5 레벨 - > 1번째 인덱스
              ....*/
        mobNum = (_selmob / 3) + 1;
    }

    public void Spawn(int wave)
    {
        allMob = nextMob[wave]; // 스폰되는 몬스터 수 현재 웨이브 레벨에 따라 결정
        itemset.itemActive = true; // 아이템 세트 다시 활성화 할 수 있게 대기
        for (int i = 0; i < nextMob[wave]; i++) // 정해진 수 만큼 몬스터 중복 소환
        {
            int seed = System.DateTime.Now.Millisecond;
            random = new System.Random(seed);
            randomNumber = random.Next(0, 9);
            setMob = UnityEngine.Random.Range(0, mobNum);
            GameObject enemy = GameManager.Instance.pool.Get(setMob); // 소환될 몬스터 랜덤 현재 레벨 범위 내에서 선택
            enemy.transform.position = spawnPoint[randomNumber]; // 스폰 장소 랜덤 생성
        }
    }
}