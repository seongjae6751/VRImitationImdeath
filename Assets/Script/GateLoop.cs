using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateLoop : MonoBehaviour
{
    public bool StageStart = true; // �������� ���� ����
    public int missingMob = 0; // ��ģ ���� ��
    
    // ����Ʈ �ȿ� ���� �� ���� ī��Ʈ �� �ı�
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Enemy")
        {
            Destroy(other.gameObject);
            CountMissing();
        }
    }

    // ��ģ �� �� ����
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
