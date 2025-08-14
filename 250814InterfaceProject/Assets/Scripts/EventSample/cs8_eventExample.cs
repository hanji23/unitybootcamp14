using System;
using UnityEngine;

//C# event 526p

//event : Ư�� ��Ȳ�� �߻������� �˸��� ������ ��Ŀ����
// 1. �÷��̾ �׾����� �˸� ���� -> �޼ҵ� ȣ��
//Action

//public class Tester : MonoBehaviour
//{

//    private void Start()
//    {
//        cs8_eventExample eventExample = new cs8_eventExample();
//        eventExample.onDeath?.Invoke();
//        //eventExample.onStart?.Invoke(); //event Ű���尡 ���� ��� �ܺο��� ȣ�� �Ұ���

//        eventExample.onDeath = null;
//        //eventExample.onStart = null; // event Ű����� ������ �Ұ����մϴ�

//        eventExample.onDeath += Samples;
//        eventExample.onStart += Samples; // ���� / ���� ����
//    }

//    private void Samples()
//    {

//    }
//}

public class cs8_eventExample : MonoBehaviour
{
    //                  Action,         event Action ����
    //�ܺ� ȣ��             O                   X
    //�ܺ� ����             O                   X
    //�������              O                   O
    //�������              O                   O
    //�� �뵵      ���η���, �ݹ�            �̺�Ʈ �˸�

    public Action onDeath;
    public event Action onStart;

    private void Start()
    {
        //�׼��� += ���� �Լ�(�޼ҵ�)�� �׼ǿ� ����Ҽ� �ֽ��ϴ� (����)
        //�׼��� -= ���� �Լ�(�޼ҵ�)�� �׼ǿ��� ���� �Ҽ� �ֽ��ϴ� (����)
        //�׼��� ����� ȣ���ϸ� ��ϵǾ��ִ� �Լ��� ���������� ȣ��˴ϴ�
        onStart += Ready;
        onStart += Fight;

        onDeath += Damaged;
        onDeath += Dead;

        onStart?.Invoke(); // onStart�� ��ϵ� ����� �����ϴ� �ڵ� (Invoke("�Լ�", �����ð�) �ϰ�� �ٸ�)
        onDeath?.Invoke();
        
        //�Լ� ó�� ȣ���ϴ� �͵� �����մϴ�
        onStart();
        onDeath();
        //���� ���̴� ����(������ �����ؼ�) ���� ��Ÿ�� ����
        //��� Invoke ����̸� nullüũ ���� -> �ܺο����� ȣ��, ������ �䱸�� ��õ
        //�Լ� ���´� ���� ���� -> ���� �ڵ� �̰ų� �ܼ� ȣ���� ��� �ش� ��� ��õ
    }

    private void Fight()
    {
        Debug.Log("<color=yellow><b>����!</b></color>");
    }

    private void Ready()
    {
        Debug.Log("<color=cyan><b>�غ�</b></color>");
    }

    private void Dead()
    {
        Debug.Log("<color=red><b>����</b></color>");
    }

    private void Damaged()
    {
        Debug.Log("<color=blue><b>�ƾ�</b></color>");
    }
}
