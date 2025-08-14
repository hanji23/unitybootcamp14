using System;
using UnityEngine;

public class cs9_ActionFuncExample : MonoBehaviour
{
    //Action<T> 최대 16개의 매개변수를 받을 수 있습니다.
    //반환값은 없습니다. (void)
    //전달이 목적이며, 결과는 받지않는 형태
    public Action<int> myaction;
    public Action<int,string> myaction2;

    //func는 마지막에 적히는 부분이 func가 사용할 함수의 반환 타입입니다.
    public Func<bool> func01;
    public Func<string, int> func02; //매개변수 : string, 반환 int

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
            Debug.Log("공격 성공");
        }
        else
        {
            Debug.Log("공격 실패");
        }

        func02 = result;
        int point = func02("14");

        func01 = () => point > 10 ? true : false;
    }

    void Rage(int Value)
    {
        Debug.Log($"<color=red><b>공격력 {Value} 상승! </b></color>");
    }

    void Heal(int Value, string character)
    {
        Debug.Log($"<color=green><b>{character} 체력 {Value} 회복! </b></color>");
    }
}
