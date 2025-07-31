using System.Collections.Generic;//c#���� �������ִ� �ڷᱸ��(List<T>, dictionary<K, V>���� ��) ��� ����
using System;
using UnityEngine;

public class InspectorAttribute : MonoBehaviour
{
    // struct - ����� ���� Ÿ�� / value Ÿ�� / GC �ʿ� ����
    // ���� �������� ������ ���� �Ҵ�/�����ϴ� ���信�� Ȱ�� ex) Vector3
    [System.Serializable]
    public struct BOOK 
    {
        public string name;
        public string description;
    }

    // class - ��ü�� ���� ���赵(�Ӽ��� ���) / ����Ƽ������ Ŭ���� ����� ����(������) / ���� ���������� �Ǽ� �߻� ���ɼ��� ����
    [Serializable]// == [System.Serializable]
    public class Item 
    {
        public string name; 
        public string description;
    }

    [Header("score")]//public int ponit;
    public int ponit;
    public int max_point;
    [Header("info")]
    public string nickname;

    public job myjob;

    //�ν����Ϳ� �����ϱ� ���� ���� ���� ����
    [HideInInspector]
    public int value = 5;

    //����Ƽ���� �����(private) �ʵ带 �ν����Ϳ� �����Ű�� ����Ƽ�� ����ȭ �ý��ۿ� ���Խ�ŵ�ϴ�
    [SerializeField]
    private int value2 = 7;

    //������
    //public -> ����ǰ� ���ٰ���
    //private -> ���� x, ���� x
    //SerializeField + private -> ���� x, �ν����Ϳ����� ��������

    // *����ȭ(Serialization) : �����͸� ���尡���� �������� ��ȯ�ϴ� �۾�
    //                          �� ��ȯ�� ���� ��, ������, ���� � �����ϰ� �����ϴ� �۾��� ������ �� �ֽ��ϴ�.

    //����ȭ ����
    // 1. public or [SerializeField]
    // 2. static�� �ƴ� ���(����ȭ�� �� ������ ����)
    // 3. ����ȭ ������ ������ Ÿ���� ���

    //   - ����ȭ ������ ������
    //     1. �⺻ ������(int, float, bool, string...)
    //     2. ����Ƽ���� �������ִ� ����ü(Vector3, Quaternion, Color)
    //     3. ����Ƽ ��ü ����(Gameobject, Transform, Material)
    //     4. [Serializable] �Ӽ��� ���� Ŭ����
    //     5. �迭/ ����Ʈ

    //   - ����ȭ �Ұ����� ������
    //     1. Dictionary<K, V>
    //     2. Interface(�������̽�)
    //     3. static Ű���尡 ���� �ʵ�
    //     4. abstract Ű���尡 ���� Ŭ����


    //Space : ���� ���̸�ŭ ������ ����ϴ�

    //TextArea : �� ���ڿ��� �����ٷ� ���� �� �ִ� ����
    //[TextArea]�� ����ϸ� ������ �Է��� ������ ���°� �ȴ�
    //[TextArea(�⺻ ǥ����, �ִ���)]�� ���� �ν����� �󿡼��� ���̸� �����մϴ�
    //���ڿ� ���̿� ���� �������� �κ��� �����ϴ�.
    [Space(10)] [TextArea(5,10)]
    public string quest_info;

    public BOOK book;
    public Item item;

    //����Ƽ �ν����Ϳ����� �迭�� ����Ʈ�� ������ �˴ϴ�
    //����Ʈ<T>�� T ���¿� �����͸� ������ ���������� ������ �� �ִ� �������Դϴ�
    //�������� �˻�, �߰�, �������� ����� �����˴ϴ�.
    public List<Item> item_list;

    //�迭
    public BOOK[] bokks = new BOOK[5];

    //���� : ����, ����, �ü�, ������
    public enum job
    {
        ����, 
        ����, 
        �ü�, 
        ������
    }

    //Range(�ּ�, �ִ�) �� ���� �ش簪�� �����Ϳ��� �ּҰ��� �ִ밡 �����Ǿ��ִ� ��ũ�� ������ ������ ����˴ϴ�(������ ���� ��)
    [Range(0,100)]public int bgm;
    [Range(0,100)]public float sfx;
}
