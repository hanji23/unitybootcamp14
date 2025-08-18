using UnityEngine;
using System;

//C#�� Event ����
//Ŭ���̳� ��ġ�� ���� ������ ó���ϴ� �ϳ��� �ý���

//������(Publisher)
//������� �ൿ�� ��ٸ��ٰ� �����ڿ��� �˷��ִ� ������ �����մϴ�

//������(Subscribers)
//�̺�Ʈ �����ڿ� ���� ������ ���� ������� �ൿ�� ���޹޾Ƽ� �����ϴ� ������ �����մϴ�.

//�������� ��� �������� �ൿ ��ü�� �����ڰ� �˾ƾ��� �ʿ�� ���� ����.

//�������� ��� ���к��ϰ� ������ ��� ���� �����ڵ��� ����� ��� �� �� ����.

//event ����� ���ؼ� System ���ӽ����̽�(using System;)�� ����ؾ��մϴ�.

public class cs1_EventSample : MonoBehaviour
{
    public event EventHandler OnSpaceEnter;
    //�̺�Ʈ �̸��� ������ ���� On + ���� / ������ ��������ϴ�.

    //C#���� �������ִ� delegate Ÿ��
    //EvnetHandler�� ��� ��ġ�� Ŭ�� ���� �̺�Ʈ�� �����ϴ� �뵵
    //�Ű�����
    //Object sender <- object Ÿ���� �����͸� ���� ������ ������, �̺�Ʈ�� �߻���Ų ����� �ǹ��մϴ�.
    //EventArgs e   <- �̺�Ʈ�� ���õ� �����͸� ��� �ִ� ��ü�� �ǹ��մϴ�.
    // �� �ش� ���� EventArgs �Ǵ� �ش� �ڽ� Ŭ������ �� �� �ֽ��ϴ�.

    private void Start()
    {
        //���� ���
        //�̺�Ʈ�� += ���¿� �´� �޼ҵ� �̸�;
        OnSpaceEnter += Debug_OnSpaceEnter;
    }

    // Update is called once per frame
    void Update()
    {
        //1) �̺�Ʈ ���� ��� �̺�Ʈ ��(this, EventArgs.Empty)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Null �˻縦 �����ϰ� ����(�̺�Ʈ ������ �ȵ����� ��쿡�� �����ϸ� �ȵǱ� ����)
            if (OnSpaceEnter != null)
            {
                OnSpaceEnter(this, EventArgs.Empty);
                //this : �̺�Ʈ�� �߻���Ų ��ü(���� Ŭ����)
                //EventArgs.Empty : �̺�Ʈ ���࿡ �־� Ư���� �߰��Ǵ� �����Ͱ� ������ �ǹ��մϴ�.
            }
        }

        //2) �̺�Ʈ ���� ��� Invoke �Լ��� ����ϴ� ���
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnSpaceEnter?.Invoke(this, EventArgs.Empty);
            //?�� ���� null�� �ƴҶ� ó���ǵ��� �Ѵ�.

            // " ? "
            // int?�� ���� �ڷ����� ? �� ���̰� Nullable �� Ÿ������ ����ϴ� ���
            //������������ null ���� ������ �ְ� ���ټ� �ְ� ���ݴϴ�. (T?)
            //Ÿ���� ������ �� ���˴ϴ�
            //�� ������ Ÿ�Կ� ���˴ϴ�

            //?.�� ���·� ���̴� ��� Null ���� �����ڷ� ����ϴ� ���
            //��ü�� null�� �ƴ� ���� ����� ���� ȣ���� �����ϵ��� �����մϴ�.
            //�޼ҵ�(Method), �Ӽ�(Property), �̺�Ʈ(Event) ���� ȣ��ÿ� ���˴ϴ�.
            //���۷��� ������ Ÿ�� �Ǵ� nullable ��ü�� ������� ����մϴ�
            // -> if(object != null) ������ �ڵ� ��� ����մϴ�
        }
    }

    private void Debug_OnSpaceEnter(object sender, EventArgs e)
    {
        Debug.Log("<color=yellow>���� Ű �Է� �̺�Ʈ ����</color>");
    }
}
