using System;
using UnityEngine;

public class cs3_JsonTester : MonoBehaviour
{
    //����Ƽ���� ��ü(Object)�� �ʵ�(field)�� json���� ��ȯ�ϱ� ���ؼ���
    //���������� �޸𸮿��� �����͸� �а� ���� �۾��� �����ؾ���
    //���� [Serializable] �Ӽ��� �߰��� �ش� ������ ���� ����ȭ�� ó������ �ʿ䰡 �ֽ��ϴ�

    //����ȭ�� �����͸� �����ϰų� �����ϱ����� �������� �������� ���·� �������ִ� �۾��� �ǹ��մϴ�.

    [Serializable]
    public class Data
    {
        public int hp;
        public int atk;
        public int def;
        public string[] items;
        public Postion postion;
        public string Quest;
        public bool isDead;
    }

    [Serializable]
    public class Postion
    {
        public float x;
        public float y;
    }

    public Data my_data;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var jsonText = Resources.Load<TextAsset>("data01");
        if (jsonText == null)
        {
            Debug.LogError("���ҽ� �������� �ش� ������ ã������");
            return;
        }
        my_data = JsonUtility.FromJson<Data>(jsonText.text);

        Debug.Log(my_data.hp);
        Debug.Log(my_data.Quest);
        Debug.Log(my_data.def);
        Debug.Log(my_data.postion.x);
        Debug.Log(my_data.postion.y);

        foreach(var item in my_data.items)
        {
            Debug.Log(item);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
