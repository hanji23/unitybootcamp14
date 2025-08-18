using System;
using UnityEngine;
using UnityEngine.UI;

public class LottoEventArgs : EventArgs
{
    //������ ���� ���� ���� (������Ƽ�� �۾��ϸ�, get ��ɸ� �ַ� Ȱ��ȭ �մϴ�.)
    public int Value { get; } //Value�� ���� ���ٸ� ����

    //EventArgs�� ���� ������ ����ϸ� ���� �����˴ϴ�(������)
    public LottoEventArgs(int value)
    {
        Value = value;
    }
}
//enum itemList
//{
//    ���,
//    �峭����,
//    ������ġ,
//    �峭����ġ,
//    �����۵���,
//    �峭������,
//    ���ź��,
//    ��,
//    ��,
//    �ſ찭�ѹ���
//}

public class cs2_test : MonoBehaviour
{
    public event EventHandler<LottoEventArgs> OnLotto;
    Text t;

    private string[] itemList = new string[]
    {
        "���",
        "�峭����",
        "������ġ",
         "�峭����ġ",
        "�����۵���",
        "�峭������",
         "��ö",
        "��",
        "��",
         "�ſ찭�ѹ���",
    };

    public void TakeLotto(int value)
    {
        //���� ���� ���� �������� ������ �̺�Ʈ �Ű������� ������, �ڵ鷯 ȣ����� ������ �����մϴ�.
        OnLotto?.Invoke(this, new LottoEventArgs(value));

        Debug.Log($"<color=red>�÷��̾ {itemList[value]}�� �̾Ҵ�! <- {value}</color>");

        if (value == itemList.Length - 1)
        {
            t.text = $"�÷��̾ {itemList[value]}�� �̾Ҵ�! <- {value}";
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        t = GameObject.Find("Canvas").transform.GetChild(0).GetComponent<Text>();

        

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            TakeLotto(UnityEngine.Random.Range(0, 10));
        }
    }
}
