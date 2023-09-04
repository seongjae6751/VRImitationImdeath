using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

// 화살통 클래스
public class Quiver : XRBaseInteractable
{
    [SerializeField] private GameObject arrowPrefab;

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        CreateAndSelectArrow(args);
    }

    // 
    private void CreateAndSelectArrow(SelectEnterEventArgs args)
    {
        // 화살 생성 및 손에 쥐어줌
        Arrow arrow = CreateArrow(args.interactorObject.transform);
        interactionManager.SelectEnter(args.interactorObject, arrow);
    }

    // 화살 생성
    private Arrow CreateArrow(Transform orientation)
    {
        // 화살 생성 및 반환
        GameObject arrowObject = Instantiate(arrowPrefab, orientation.position, orientation.rotation);
        return arrowObject.GetComponent<Arrow>();
    }
}
