using UnityEngine;

public class sample2 : MonoBehaviour
{
    public sample1 sample1;

    private void Awake()
    {
        sample1 = GameObject.FindWithTag("s1").GetComponent<sample1>();
        //1. GameObject.FindWithTag("�±��̸�")
        // ������ �ش� �±׸� ������ �ִ� ������Ʈ�� �˻��ϴ� ���
        //2. GameObject.getComponent<T>
        // ���� ������Ʈ�� getComponent<T>�� ���� T�� ������Ʈ�� ������ �ۼ����ָ� �ش� ���� ������Ʈ�� ������Ʈ�� �������ִ� ���� ������

        // �� ����� ���� �޾ƿ��� �� -> T

        Debug.Log(sample1.cc.massage);

        //edit -> project settings -> script execution order
        //����Ƽ������ script execution order ����� ���� ��ũ��Ʈ ó�� ������ ���� ������ ���� �Ҽ� ����
        //���ڰ� Ŭ���� ���߿� �����
    }

}
