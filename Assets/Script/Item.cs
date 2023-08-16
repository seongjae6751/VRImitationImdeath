using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    protected GameObject rightHand; 
    protected Rigidbody itemRb; 

    protected void Start()
    {
        rightHand = GameObject.Find("RightHand"); // �������� ������ �޾ƿ�(�������� ���������� ȹ��)
    }

    public virtual void PullItem()
    {
        Vector3 pullDirection = rightHand.transform.position; // ������ ���� ������ ����
        itemRb.AddForce(pullDirection * 2); // �� ���ϱ�
    }
}
