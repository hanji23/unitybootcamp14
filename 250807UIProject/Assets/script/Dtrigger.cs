using System.Collections.Generic;
using UnityEngine;

//������Ʈ�� ������ Inspector���� ��縦 ����ϴ� ���
public class Dtrigger : MonoBehaviour
{
    public List<Dialog> scripts;

    public void OnDTriggerEnter()
    {
        if (scripts != null && scripts.Count > 0)
        {
            DialogManager.Instance.StartLine(scripts);
            //Ŭ������.Instance.�޼ҵ��()�� ���� Ŭ������ ���� �ٷ� ����� �� �ֽ��ϴ�
            //���� ���� GetCompnonent�� public������ ����ؼ� ����� �ʿ䰡 ���� ���մϴ�
        }
    }
}
