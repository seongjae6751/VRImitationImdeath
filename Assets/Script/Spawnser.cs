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

    // ���� ����Ʈ
    // �ٸ� ��ũ��Ʈ�� �ű�� ���� ������
    List<Vector3> spawnPoint = new List<Vector3>(); // ���� ����Ʈ�� �̸��� ���Ͱ����� �̷���� ��ųʸ�
    public int[] nextMob = { 1, 2, 4, 5, 7, 10, 11, 13, 15, 17, 18, 20, 22, 24, 30 }; // �������� �� ��ȯ ���� ��
    public int level = 1; // �������� ����
    private System.Random random;
    private int randomNumber;
    public bool setNav = true; // nav mesh ������ ���� ��Ʈ��
    public bool trySecond = false;
    private int mobNum = 0; // ���� ���� ����
    private int setMob;
    private int waveLevel;
    public bool gameProgress = true; // ���� ���� ������ ����(���� �� �ߺ� ������ �����ϱ� ����)
    public int allMob = 1; // ó������ �������� Ȱ��ȭ �Ǵ°� ����(�������� 0�� �Ǿ�� ����)

    [SerializeField]
    WaveStart wavestart;

    [SerializeField]
    GateLevel gatelevel;

    [SerializeField]
    ItemSet itemset;

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
        SelectMob(gatelevel.gateLevel);
        if (wavestart.waving && gameProgress)
        {
            GameObject.FindWithTag("Set").GetComponent<ItemSet>().SetItem();
            waveLevel = gatelevel.gateLevel - 1; // ����Ʈ ������ 1���� �����ϹǷ� ����Ʈ �ε��� 0�� ���߱� ����
            Spawn(waveLevel);
            wavestart.waving = false;
            setNav = false;
            gameProgress = false;
        }
    }

    void AddData() // ���� ����Ʈ �߰�
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

    private void SelectMob(int _selmob)
    {
        mobNum = (_selmob / 3) + 1;
    }

    public void Spawn(int wave)
    {
        allMob = nextMob[wave];
        itemset.itemActive = true;
        for (int i = 0; i < nextMob[wave]; i++)
        {
            int seed = System.DateTime.Now.Millisecond;
            random = new System.Random(seed);
            randomNumber = random.Next(0, 8);
            setMob = UnityEngine.Random.Range(0, mobNum);
            GameObject enemy = GameManager.Instance.pool.Get(setMob);
            enemy.transform.position = spawnPoint[randomNumber];
        }
    }
}