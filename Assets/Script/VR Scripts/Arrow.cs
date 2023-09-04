using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Arrow : XRGrabInteractable
{

    [SerializeField] private float speed = 2000.0f; // 화살 속도
    [SerializeField] private int destroyTime; // 붕괴 시간
    public AudioClip shootSound; // 날라가는 소리

    private new Rigidbody rigidbody;
    private ArrowCaster caster;
    private bool launched = false;

    private RaycastHit hit;

    protected override void Awake()
    {
        base.Awake();
        rigidbody = GetComponent<Rigidbody>();
        caster = GetComponent<ArrowCaster>();
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);
        if (args.interactorObject is Notch notch)
        {
            if (notch.CanRelease)
                LaunchArrow(notch);
        }
    }

    private void LaunchArrow(Notch notch)
    {
        launched = true;
        ApplyForce(notch.PullMeasurer);
        StartCoroutine(LaunchRoutine());
    }

    private void ApplyForce(PullMeasurer pullMeasurer)
    {
        rigidbody.AddForce(transform.forward * (pullMeasurer.PullAmount * speed));
    }

    private IEnumerator LaunchRoutine()
    {
        // 날라가는 동안 방향 설정
        while (!caster.CheckForCollision(out hit))
        {
            GetComponent<AudioSource>().Stop();
            GetComponent<AudioSource>().clip = shootSound;
            GetComponent<AudioSource>().volume = 1;
            GetComponent<AudioSource>().Play();
            SetDirection();
            GetComponent<AudioSource>().Stop();
            yield return null;
        }

        // 화살이 나는것을 멈췄을 때
        DisablePhysics();
        ChildArrow(hit);
        CheckForHittable(hit);

        if (hit.transform.GetComponent<WaveStart>())
        {
            Debug.Log("웨이브 발생");
            hit.transform.GetComponent<WaveStart>().SetWave();
        }

        if (hit.transform.GetComponent<Enemy>())
        {
            Debug.Log("몬스터 부상");
            hit.transform.GetComponent<Enemy>().Damage(10, transform.position);
        }
    }

    private void SetDirection()
    {
        if (rigidbody.velocity.z > 0.5f)
            transform.forward = rigidbody.velocity;
    }

    private void DisablePhysics()
    {
        rigidbody.isKinematic = true;
        rigidbody.useGravity = false;
    }

    private void ChildArrow(RaycastHit hit)
    {
        transform.SetParent(hit.transform);
    }

    private void CheckForHittable(RaycastHit hit)
    {
        if (hit.transform.TryGetComponent(out IArrowHittable hittable))
            hittable.Hit(this);
        Destroy(gameObject, destroyTime);
    }

    public override bool IsSelectableBy(IXRSelectInteractor interactor)
    {
        return base.IsSelectableBy(interactor) && !launched;
    }
}
