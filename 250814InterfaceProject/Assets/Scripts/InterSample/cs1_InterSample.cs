using UnityEngine;

//�������̽�(interface) C# - 560p~
//���� ������ interface �̸� { ... }

//�ۼ�����
// ���� ������ class �ڽ�Ŭ������ : �θ�Ŭ����, �������̽�1, �������̽�2, ...
// Ŭ������ �������̽��� ���� ��� �ҽ� Ŭ������ ���� ����ؾ���

// ������ Ŭ���� ��� :
// ��ɿ� ���� ������ ����, ���� ����� �Ұ���, ���������ڿ� ���� ��� ����
// ���뼺�� �ִ� �ڵ��� ����� ������ ���� ���踦 �����ִ� ����

// �������̽� ��� :
// ��ɿ� ���� ���踦 ��Ź��(�߰� �ٸ� ����), �������̽��� ���� ��Ӱ���,
// ���� ��ӿ� ���� ���(���� �����ϱ⿡ �浹������ ���� ����)
//  �������� ��ü�� �ᱹ �������̽��� ������ 'Ŭ����' �ڽ�
// �������� ���ۿ� ���� ���踦 �����ϴ� ����

// -> �������̽��� ���յ��� ���Ƽ�, �������� ���� �ڵ带 ¥�� �����ϴ�.

public interface IThrowable
{

}

public interface IWeapon
{

}

public interface Icountable
{

}

public interface IPotion
{

}

public interface IUsable
{

}

public class Item
{

}

public class Sword : Item, IWeapon
{

}

public class Jabelin : Item, IWeapon, Icountable, IThrowable
{

}

public class MaxPotion : Item, IPotion, Icountable, IUsable
{

}

public class FirePostion : Item, IPotion, Icountable, IThrowable
{

}

public class cs1_InterSample : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
