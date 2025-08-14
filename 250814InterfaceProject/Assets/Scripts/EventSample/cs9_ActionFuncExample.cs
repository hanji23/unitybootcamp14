using System;
using UnityEngine;

public class cs9_ActionFuncExample : MonoBehaviour
{
    //Action<T> �ִ� 16���� �Ű������� ���� �� �ֽ��ϴ�.
    //��ȯ���� �����ϴ�. (void)
    //������ �����̸�, ����� �����ʴ� ����
    public Action<int> myaction;
    public Action<int,string> myaction2;

    //func�� �������� ������ �κ��� func�� ����� �Լ��� ��ȯ Ÿ���Դϴ�.
    public Func<bool> func01;
    public Func<string, int> func02; //�Ű����� : string, ��ȯ int

    bool AttackAble()
    {
        int rand = UnityEngine.Random.Range(0, 10);
        return rand <= 3 ? true : false;
    }

    int result(string s) => int.Parse(s);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myaction += Rage;
        myaction2 += Heal;

        myaction(50);
        myaction2(150, "asdf");

        func01 = AttackAble;

        if (func01())
        {
            Debug.Log("���� ����");
        }
        else
        {
            Debug.Log("���� ����");
        }

        func02 = result;
        int point = func02("14");

        func01 = () => point > 10 ? true : false;
    }

    void Rage(int Value)
    {
        Debug.Log($"<color=red><b>���ݷ� {Value} ���! </b></color>");
    }

    void Heal(int Value, string character)
    {
        Debug.Log($"<color=green><b>{character} ü�� {Value} ȸ��! </b></color>");
    }
}
