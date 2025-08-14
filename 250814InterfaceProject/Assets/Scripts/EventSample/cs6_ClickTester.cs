using UnityEngine;
using UnityEngine.EventSystems;

//�̺�Ʈ �ý��� ������Ʈ�� ���� �����ؾ���
// UI�� ��� �׷��� �����ɽ�Ʈ ������Ʈ�� �߰��Ǿ��־���ϸ�, RAYcast�� target�� üũ �Ǿ��־���մϴ�
// ������Ʈ�� ��쿡�� Collider / Collider2D ������Ʈ�� �߰� �Ǿ� �־�� �մϴ�.
// ���� ī�޶� Physics Raycaster�� �߰��Ǿ� �־�� �մϴ�.

//�����Ǵ� ��� ���� �Ϲ����� ����
//  1. Pointer Enter
//  2. Pointer Down
//  3. Begin Drag
//  4. Dragging
//  5. End Drag
//  6. Pointer Up
//  7. Pointer Exit
//  8. Select
//  9. Submit
// 10. move
// 11. Cancel

public class cs6_ClickTester : MonoBehaviour, IPointerClickHandler, IPointerUpHandler, IPointerDownHandler, IPointerExitHandler
{
    //PointerEventData : ���콺 Ŭ������ Ŭ�� ��ư, Ŭ�� Ƚ��, ������ ��ġ � ���� ������ ������ �ִ� Ŭ����

    //���콺�� 1ȸ Ŭ���ϴ� ���
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log($"��ġ�� ���콺 �������� ��ġ : {eventData.position}");
        Debug.Log($"���콺 Ŭ�� Ƚ�� : {eventData.clickCount}");
        Debug.Log($"���콺 Ŭ�� �ð� : {eventData.clickTime}");
        Debug.Log($"�������� �̵��� : {eventData.delta}");
        Debug.Log($"���� �巹�� ���� : {eventData.dragging}");

        //eventData.button = ��ư
        //eventData.phase = ������ �̺�Ʈ �ܰ�
        //eventData.pointId = ��ġ �Ǵ� ���콺 ������ ID
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("�����͸� ������ ��");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("������ Ż��");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("������ ��ġ�� �� ��");
    }
}
