using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateLoop : MonoBehaviour
{
    [SerializeField]
    Spawnser spawnser;
    public bool StageStart = true; // 스테이지 시작 여부
    public int missingMob = 0; // 놓친 몬스터 수
    
    // 게이트 안에 들어가는 적 숫자 카운트 후 파괴
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Enemy"))
        {
            Destroy(other.gameObject); // 게이트 안에 적 들어가면 파괴
            CountMissing(); // 놓친 적 세기
            spawnser.allMob--; // 남은 몬스터 수 하나 차감
        }
    }

    // 놓친 적 수 세기
    private void CountMissing()
    {
        missingMob++;
    }
}