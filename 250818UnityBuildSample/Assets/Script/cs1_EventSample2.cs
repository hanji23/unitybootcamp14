using System;
using UnityEngine;

//cs1_EventSample�� ������Ʈ�� �پ��ִ� ��ü�� �������ְڽ��ϴ�
public class cs1_EventSample2 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //�ٸ� Ŭ�������� �̺�Ʈ�� �����ϴ� ���

        //Ŭ���� ����
        cs1_EventSample event_sample = GetComponent<cs1_EventSample>();
        
        //Ŭ������ ���� �̺�Ʈ�� �߰�
        event_sample.OnSpaceEnter += OnSpaceButton;
    }

    private void OnSpaceButton(object sender, EventArgs e)
    {
        Debug.Log("<color=blue>Sample2���� ����� ���</color>");
    }
}
