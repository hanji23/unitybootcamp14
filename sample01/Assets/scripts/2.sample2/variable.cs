using System;
using UnityEngine;
// ����Ƽ �ν����Ϳ��� ������ ���� ǥ�� Ȯ���ϴ� �ڵ�

public enum TYPE
{
    ��, ��, Ǯ
}

//�������� �����ϴ� ���(Flag)
//���� 2�� �������� ǥ����
//2�� �������� ��Ʈ�������� ǥ���ϱ� ���� n << 1 (n�� ����), n << 2 (n�� 2 ����)
[Flags]
public enum TYPE2
{
    �� = 1 << 0, 
    ��Ʈ = 1 << 1, // 1���� 1ĭ �̵� (��Ʈ����)
    �巡�� = 1 << 2,
    ���� = 1 << 3
}

public class variable : MonoBehaviour
{
    //tip
    //������ �տ� u�� ������ ����� ǥ��
    //ex)int�� ǥ�� ����  -> -2147483648 ~ 2147483647 ���� ǥ�� ����
    //   uint�� ǥ�� ���� ->           0 ~ 4294967295

    //null�� "���� ����"�� ��Ÿ���� ��(0 �Ǵ� empty�ʹ� �ٸ�)

    //����Ƽ���� ���� ���Ǵ� /C# �⺻������ Ÿ��(primitive)
    //����(int)
    //�Ǽ�(float)
    //��(bool)
    //���ڿ�(string)
    //�ΰ����(nullable) : �ڷ���?�� �ۼ��ϸ� �ش� ���� null�� ����� �� ����
    //public int  integer = null; X
    //public int? integer = null; O

    public int integer;
    public float Float;
    public string sentence;

    public TYPE type;
    public bool isdead;
    public TYPE2 type2;
}
