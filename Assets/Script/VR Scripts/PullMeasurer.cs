using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PullMeasurer : XRBaseInteractable
{
    [SerializeField] private Transform start; // 활 시위 시작
    [SerializeField] private Transform end; // 활 시위 끝
    public AudioClip drawSound;

    // 외부에서 읽기만 가능하고 변경은 불가능하게 설정
    public float PullAmount { get; private set; } = 0.0f;

    // 시작점과 끝점사이에서 pullamount의 양에 따라 계산된 위치 반환
    public Vector3 PullPosition => Vector3.Lerp(start.position, end.position, PullAmount);


    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);
        PullAmount = 0;
    }


    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        base.ProcessInteractable(updatePhase);

        if (isSelected) // 잡히면
        {
            // 측정기를 잡는 동안 당기기 값 업데이트
            if (updatePhase == XRInteractionUpdateOrder.UpdatePhase.Dynamic)
                UpdatePull();
        }
    }

    private void UpdatePull()
    {
        // 당겨진 양을 계산하기 위해 인터랙터의 포지션 이용
        Vector3 interactorPosition = firstInteractorSelecting.transform.position;

        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().clip = drawSound;
        GetComponent<AudioSource>().Play();

        PullAmount = CalculatePull(interactorPosition) * 2;
    }

    // 당긴 양 계산
    private float CalculatePull(Vector3 pullPosition)
    {
        // 방향, 길이
        Vector3 pullDirection = pullPosition - start.position; // 시작 지점에서 pull 지점으로 얼마나 당겨졌는지를 알기 위함
        Vector3 targetDirection = end.position - start.position; // 시작 지점에서 끝 지점 위치로 나타내는 방향임

        // 당기는 방향을 알기 위함
        float maxLength = targetDirection.magnitude; // 당기기를 최대한 할 수 있는 길이
        targetDirection.Normalize(); // 모든 방향의 벡터 길이를 맞추기 위함

        float pullValue = Vector3.Dot(pullDirection, targetDirection) / maxLength; // 두 백터간의 내적 계산(얼마나 비슷한 방향인지를 알기 위함임)
        return Mathf.Clamp(pullValue, 0.0f, 1.0f); // 당기기 값의 최대는 1임
    }

    private void OnDrawGizmos()
    {
        // 시작 지점부터 끝 까지 라인 그림
        if (start && end)
            Gizmos.DrawLine(start.position, end.position);
    }
}
