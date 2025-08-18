using UnityEngine;
using UnityEngine.Events;
//using UnityEngine.Events ���ӽ����̽� ������ �ʼ�
//����Ƽ �̺�Ʈ

//C#�� event���� ������
//1. �ν����Ϳ��� Ȯ���� �����ϴ�
//2. �߰� ���� ����� +=, -= ���� ���� �ʰ� AddListener�� RemoveListener�� �����մϴ�

//                  UnityAction     vs     UnityEvent  
//Ÿ��                delegate                class
//���                �Լ� ����               �����Ϳ��� �ڵ鷯 ������� ����
//����                  +,-                   AddListener(), RemoveListener()
//����Ȳ      ��ũ��Ʈ �ڵ� �� ó��         �ν����Ϳ� �̺�Ʈ �ý���
//�ӵ�                  ����                  ����(���� ������ ���� �Ľ� �� ��Ÿ�� ���� ���)
//�޸�                ����                  ����
//GC �߻�����           ����                  ����
//���Ǽ�          ��ü ���� �ؾ���            �ٷ� ��� ���� ���� ����

//UnityAction�� unityEvent�� ����ϴ� �ڵ带 ������ �� ȿ�����Դϴ�.
//�Ϲ� delegate�� UnityAction<T>�� ���� Ÿ�Կ� ���� ������ �ȵǾ��־� ���� ���� ����ؾ� �մϴ�

//����Ҽ� �ִ� ������
//1. C# delegate
//2. Unity UnityAction 
//3. C# Func<T>, Action<T>


//�� �پ��� delegate���� ���� ��� ����ؾ��ϴ°�?
// ������ ���Ѵ�     -> C# delegate

//   �ݹ�              -> Action, UnityAction

// UnityEvent���� ���� -> UnityAction
//    �ν����� ����

// �̺�Ʈ �ñ״�ó     -> delegate, Func(Return), Action
// �ʿ�(�����ϰ� ����)

//�̺�Ʈ �ñ״�ó : ȣ��Ǵ����� ������ �Լ� ����
//C#�� EventHandler�� ����
//ex) delegate void EventHandler(object sender, EventArgs e)

//�ñ״�ó
//1.��ȯŸ��(void)
//2.�Ű�����(object, EventArgs)

public class cs1_EventSample3 : MonoBehaviour
{
    public UnityEvent OnKButtonEnter; 
    public UnityAction OnAction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //OnKButtonEnter += Sample(); // C#�� event ó�� ������ ����
        OnKButtonEnter.AddListener(Sample);

        OnAction += Sample2;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            OnKButtonEnter?.Invoke();
        }
    }

    private void Sample()
    {
        Debug.Log("<color=cyan>Sample ����</color>");
    }

    private void Sample2()
    {
        Debug.Log("<color=green>Sample2 ����</color>");
    }
}
