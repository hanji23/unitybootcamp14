using UnityEngine;
using TMPro;

public class TextMeshProSample : MonoBehaviour
{
    //TMP�� ����ϴ� UI ������Ʈ
    public TextMeshProUGUI textUI;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //��ġ �ؽ�Ʈ(HTNL �±� ���� ����) ����
        textUI.text = "<size=150%>�ȳ�</size><s>��~��</s>";
    }

    public void SetText(bool wanning)
    {
        if (wanning)
        {
            textUI.text = "<color=red><b>���!</b></color>";
        }
        else
        {
            textUI.text = "<color=green>�ȳ�</color>";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
