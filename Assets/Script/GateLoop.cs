using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateLoop : MonoBehaviour
{
    public bool StageStart = true; // 스테이지 시작 여부
    public int missingMob = 0; // 놓친 몬스터 수
    
    // 게이트 안에 들어가는 적 숫자 카운트 후 파괴
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Enemy")
        {
            Destroy(other.gameObject);
            CountMissing();
        }
    }

    // 놓친 적 수 세기
    private void CountMissing()
    {
        missingMob++;
    }

/*    // 
    public int returnMissing()
    {
        return missingMob;
    }*/
}
