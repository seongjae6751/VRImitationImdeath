using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    protected GameObject rightHand; 
    protected Rigidbody itemRb; 

    protected void Start()
    {
        rightHand = GameObject.Find("RightHand"); // 오른손의 정보를 받아옴(아이템은 오른손으로 획득)
    }

    public virtual void PullItem()
    {
        Vector3 pullDirection = rightHand.transform.position; // 오른속 벡터 값으로 당기기
        itemRb.AddForce(pullDirection * 2); // 힘 가하기
    }
}
