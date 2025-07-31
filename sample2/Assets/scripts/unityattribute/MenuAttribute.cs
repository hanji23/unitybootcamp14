using UnityEngine;
//Attribute : [AddComponentMenu("")]ó�� Ŭ������ �Լ�, ���� �տ� �ٴ� []���� Attribute(�Ӽ�)
//�����Ϳ� ���� Ȯ���̳� ����� ���� �� ���ۿ��� �����Ǵ� ���
//������ : ����ڰ� �����͸� �� ����������, ���������� ����ϱ� ����

//1. AddComponentMenu("�׷��̸�/����̸�")
//Editor�� Component�� �޴��� �߰��ϴ� ���
//�׷��� ������� �׷��� �����Ǹ�, �ƴ� ��쿡�� ��ɸ� ����˴ϴ�
//���� ���� ��� ������ ���� ���ɱ����� ������ �ֽ��ϴ�
//  Ư������ -> ���� -> �빮�� -> �ҹ���
[AddComponentMenu("Sample/AddComponentMenu")]
//[AddComponentMenu("0_Sample/AddComponentMenu")]



public class MenuAttribute : MonoBehaviour
{
    //ContextMenuItem(������� ǥ���� �̸�, �Լ��� �̸�)
    // �� message�� ������� MessgaeReset����� �����Ϳ��� ����Ҽ� �ֽ��ϴ�
    [ContextMenuItem("�޼��� �ʱ�ȭ", "MessageReset")]
    public string message = "";

    public void MessageReset()
    {
        message = "";
    }


    [ContextMenu("��� �޼��� ȣ��")]
    public void MenuAttributeMethod()
    {
        Debug.LogWarning("���! ���!");
    }

}
