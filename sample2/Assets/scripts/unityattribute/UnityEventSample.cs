using UnityEngine;
using UnityEngine.Events;

public class UnityEventSample : MonoBehaviour
{
    //Tooltip�� �ν����Ϳ��� �ʵ尪�� ���콺�� �÷����� ������ �����ִ� ���
    [Tooltip("�̺�Ʈ ����Ʈ�� �߰��ϰ�, ������ ����� ���� ���� ������Ʈ�� ����ϼ���")]
    public UnityEvent action;

    private void Update()
    {
        action.Invoke();//�׼ǿ� ��ϵ� �Լ��� ����
    }
    public void move()
    {
        gameObject.transform.Translate(0, 1, 0);
    }
}
