using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
//��Ӵٿ��� ���� ���
//1. template : ��Ӵٿ��� ���������� ���̴� ����Ʈ �׸�
//2. Caption / Item Text : ���� ���õ� �׸� / ����Ʈ �׸� ������ ���� �ؽ�Ʈ
//  tmp�� ���� ���, �ѱ� ����� ���� Label�� item Label���� ������� ��Ʈ�� ������ �ּž� ����Ҽ� �ֽ��ϴ�.
//3. Option : ��� �ٿ ǥ�õ� �׸� ���� ����Ʈ �ν����͸� ���� ���� ����� �����մϴ�
//  ����ϸ� �ٷ� ����Ʈ�� ����˴ϴ�
//4. ON Value Changed : ����ڰ� �׸��� ���������� ȣ��Ǵ� �̺�Ʈ �ν����͸� ���� ���� ����� �� �ֽ��ϴ�.
//  ��Ӵٿ�� ���� ���� �߻��� ȣ�� �˴ϴ�
public class DropdownSample : MonoBehaviour
{
    public TMP_Dropdown dropdown;

    public List<playerUI> P;

    //options�� ����� ���� ���ڿ�

    //����Ʈ�� ���� �ְ� �����ϴ� ���
    //����Ʈ<T> ����Ʈ�� = new ����Ʈ��<T>{���, ���, ��� ...}
    //private List<string> options = new List<string> { "A", "B", "C" ,"D"};

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //dropdown.ClearOptions();// ��Ӵٿ��� option ����� �����ϴ� �ڵ�
        //dropdown.AddOptions(options); // �غ�� ��ܿ� ���� �߰��ϴ� ���

        //dropdown.onValueChanged.AddListener(onDropdownValueChanged);
        //�̺�Ʈ ��Ͻ� �䱸�ϴ� �Լ��� ���´�� �ۼ��� ��ٸ� �Լ��� �̸��� �־� ����� �� �ְ� �˴ϴ�
    }

    //  C# System.Int32  ->  int
    //     System.Int64  -> long
    //     System.UInt32 -> uint (��ȣ�� ���� 32��Ʈ ����)

    void onDropdownValueChanged(int idx)
    {
        Debug.Log($"���� ���õ� �޴��� {dropdown.options[idx].text} �Դϴ�");

        //if (options != null && options.Count > 0)
        //{
            playerclassUI.Instance.playerUIUpdate1();
            //Ŭ������.Instance.�޼ҵ��()�� ���� Ŭ������ ���� �ٷ� ����� �� �ֽ��ϴ�
            //���� ���� GetCompnonent�� public������ ����ؼ� ����� �ʿ䰡 ���� ���մϴ�
        //}
    }
}
