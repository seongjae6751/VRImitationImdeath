using UnityEngine;

public class ArrowCaster : MonoBehaviour
{
    [SerializeField] private Transform tip; // 화살촉
    [SerializeField] private LayerMask layerMask = ~0; // 모든 레이어와 상호 작용 허용

    private Vector3 lastPosition = Vector3.zero;

    public bool CheckForCollision(out RaycastHit hit)
    {
        if (lastPosition == Vector3.zero)
            lastPosition = tip.position;

        bool collided = Physics.Linecast(lastPosition, tip.position, out hit, layerMask);
        lastPosition = collided ? lastPosition : tip.position;

        return collided;
    }
}
