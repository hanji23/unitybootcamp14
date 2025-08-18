using UnityEngine;
using System;

// 1. eventArgs�� ����� Ŀ���� Ŭ���� �����
public class DamageEventArgs : EventArgs
{
    //������ ���� ���� ���� (������Ƽ�� �۾��ϸ�, get ��ɸ� �ַ� Ȱ��ȭ �մϴ�.)
    public int Value { get; } //Value�� ���� ���ٸ� ����

    public string EventName { get; }

    //EventArgs�� ���� ������ ����ϸ� ���� �����˴ϴ�(������)
    public DamageEventArgs(int value, string eventName)
    {
        Value = value;
        EventName = eventName;
    }
}

public class cs1_EventSample4 : MonoBehaviour
{
    public event EventHandler<DamageEventArgs> OnDamaged; // �������� �޾������� ���� �̺�Ʈ �ڵ鷯

    public void TakeDamage(int value, string eventName)
    {
        //���� ���� ���� �������� ������ �̺�Ʈ �Ű������� ������, �ڵ鷯 ȣ����� ������ �����մϴ�.
        OnDamaged?.Invoke(this, new DamageEventArgs(value, eventName));

        Debug.Log($"<color=red>[{eventName}] �÷��̾ {value} �������� �޾Ҵ�!</color>");
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TakeDamage(UnityEngine.Random.Range(10, 201), "���� ����");
        }
    }
}
