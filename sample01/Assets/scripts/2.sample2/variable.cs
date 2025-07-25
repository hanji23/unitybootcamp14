using System;
using UnityEngine;
// 유니티 인스펙터에서 변수에 대한 표현 확인하는 코드

public enum TYPE
{
    불, 물, 풀
}

//여러개를 선택하는 기능(Flag)
//값을 2의 제곱수로 표현함
//2의 제곱수는 비트연산으로 표현하기 쉬움 n << 1 (n의 제곱), n << 2 (n의 2 제곱)
[Flags]
public enum TYPE2
{
    독 = 1 << 0, 
    고스트 = 1 << 1, // 1에서 1칸 이동 (비트연산)
    드래곤 = 1 << 2,
    얼음 = 1 << 3
}

public class variable : MonoBehaviour
{
    //tip
    //데이터 앞에 u가 있으면 양수만 표현
    //ex)int의 표현 범위  -> -2147483648 ~ 2147483647 까지 표현 가능
    //   uint의 표현 범위 ->           0 ~ 4294967295

    //null은 "값이 없음"을 나타내는 값(0 또는 empty와는 다름)

    //유니티에서 자주 사용되는 /C# 기본데이터 타입(primitive)
    //정수(int)
    //실수(float)
    //논리(bool)
    //문자열(string)
    //널값허용(nullable) : 자료형?로 작성하면 해당 값은 null을 사용할 수 있음
    //public int  integer = null; X
    //public int? integer = null; O

    public int integer;
    public float Float;
    public string sentence;

    public TYPE type;
    public bool isdead;
    public TYPE2 type2;
}
