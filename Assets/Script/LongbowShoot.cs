using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class LongbowShoot : MonoBehaviour {

	public Transform arrowSpawn; // 화살 스폰 포인트
	public Transform projectile; // 인스턴스화될 화살
	public AudioClip drawSound; // 시위 당길때 소리
	public AudioClip shootSound; //화살 날릴 때 소리
	int maxPower = 2000; // 화살 적용되는 최고 힘
	float power; // 화살이 얼마나 멀리 갈것인가
	public float destroyTime = 10; // 화살 사라지는 시간 
	public bool destroyArrows = false; // 화살이 사라졌는지 여부
	public XRController controller = null;

  	void Update () {
        
		// vr 컨트롤러
		/*if (controller.inputDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool Abutton) {

		}*/

        if (Input.GetMouseButtonDown(0)) {
			// 소리 재생
			GetComponent<AudioSource>().Stop();
			GetComponent<AudioSource>().clip = drawSound;
			GetComponent<AudioSource>().volume = 1;
			GetComponent<AudioSource>().Play();
			
			// 애니메이션 재생
			GetComponent<Animation>().Play("Draw");
			GetComponent<Animation>()["Draw"].speed = 1;
			GetComponent<Animation>()["Draw"].wrapMode = WrapMode.Once;
			
			// 화살 스폰 가능 여부
			arrowSpawn.transform.GetComponent<Renderer>().enabled = true;

			// 파워 0으로
			power = 0;
		}
		if(Input.GetMouseButton(0)) {
			// 파워 증가
			if(power < maxPower) { // power는 2000을 초과하면 안됨
				power += maxPower * Time.deltaTime; // 매초마다 파워 더하기
			}
		}
		if(Input.GetMouseButtonUp(0)) {
			// 활 애니메이션 계산
			// 활을 다 당기지 않고 쐈을 때, shoot 애니메이션을 처음부터 계산하지 않기 위함임
			float percent = GetComponent<Animation>()["Draw"].time / GetComponent<Animation>()["Draw"].length; 
			float shootTime = 1 * percent;
			
			// 발사 소리
			GetComponent<AudioSource>().Stop();
			GetComponent<AudioSource>().time = 0.2f;
			GetComponent<AudioSource>().clip = shootSound;
			if(percent == 0) {
				GetComponent<AudioSource>().volume = 1;
			}
			else {
				// 소리는 활 파워에 따라 결정 됨
				GetComponent<AudioSource>().volume = 1 * percent;
			}
			GetComponent<AudioSource>().Play();
			
			// 마우스 올리면 발사 애니메이션 구현
			GetComponent<Animation>().Play("Shoot");
			GetComponent<Animation>()["Shoot"].speed = 1;
			GetComponent<Animation>()["Shoot"].time = shootTime;
			GetComponent<Animation>()["Shoot"].wrapMode = WrapMode.Once;
			
			// 화살 스폰 금지
			arrowSpawn.transform.GetComponent<Renderer>().enabled = false;
			
			// 활 인스턴스 생성
			Transform arrow = Instantiate(projectile, arrowSpawn.transform.position, transform.rotation) as Transform;
			
			// 힘에 따라 화살에 힘 추가
			arrow.transform.GetComponent<Rigidbody>().AddForce(transform.forward * power);
			
			if(destroyArrows == true) {
				// 주어진 시간이 지나면 화살 파괴
				Destroy(arrow.gameObject, destroyTime); 
			}
		}
	}
}
