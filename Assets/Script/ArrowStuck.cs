using UnityEngine;
using System.Collections;

public class ArrowStuck : MonoBehaviour {

	RaycastHit hit;
	public AudioClip hitSound; // 화살이 박힐때 소리

	
	void Update () {
		// 화살이 움직일 때 장애물이 있는지 체크
		if(GetComponent<Rigidbody>().velocity.magnitude > 0.5) {
			CheckForObstacles();
		}
		else {
			enabled = false;
		}
	}

	void CheckForObstacles() {
		// 레이캐스트의 길이는 화살보다 길어야 함
		float myVelocity = GetComponent<Rigidbody>().velocity.magnitude;
		// 화살표의 속도에 따라 레이캐스트의 길이 결정 / 이를 기반으로 화살은 속도가 너무 작으면 붙지 않음
		float raycastLength = myVelocity * 0.03f;
		
		if(Physics.Raycast(transform.position, transform.forward, out hit, raycastLength)) {
			GetComponent<AudioSource>().Stop();
			GetComponent<AudioSource>().clip = hitSound;
			GetComponent<AudioSource>().Play();
			
			// 화살 맞으면 힘 추가
			if(hit.transform.GetComponent<Rigidbody>()) {
				hit.transform.GetComponent<Rigidbody>().AddForce(transform.forward * myVelocity * 10);
			}
			
			// 화살 콜라이더 비 활성화 시키기
			GetComponent<BoxCollider>().enabled = false;
			
			// 리지드바디 고정
			GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
			// 화살 위치
			transform.position = hit.point;
			// 화살이 닿은 객체가 움직이면 화살도 같이 움직임
			transform.parent = hit.transform;
			
			// 화살 고정되면 스크립트 비활성화
			enabled = false;
		}
		else {
			// 화살을 위쪽으로 무겁게 만듦(활을 멀리 당기지 않으면 바닥으로 가게 함)
			Quaternion newRot = transform.rotation;
			newRot.SetLookRotation(GetComponent<Rigidbody>().velocity * 10000);
			transform.rotation = newRot;
		}
	}

	void OnCollisionEnter(Collision collision) {
		if(GetComponent<Rigidbody>().velocity.magnitude > 5) {
			if(collision.transform.tag != "Player") {
				GetComponent<BoxCollider>().enabled = false;

				// 리지드 바디 고정
				GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
				// 화살 위치
				foreach(ContactPoint contact in collision.contacts) {
					Vector3 pos = contact.point;
					transform.position = pos;
				}
                // 화살이 닿은 객체가 움직이면 화살도 같이 움직임
                transform.parent = collision.transform;
				
				enabled = false;
			}
		}
	}
}
