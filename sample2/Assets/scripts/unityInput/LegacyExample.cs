using UnityEngine;
using UnityEngine.UI;

//Ű�� �Է��ϸ� �ؽ�Ʈ�� Ư�� �޼����� �������� �ϴ� �ڵ�

public class LegacyExample : MonoBehaviour
{
    public Text text;

    private void Start()
    {
        text = GetComponentInChildren<Text>();
        //GetComponentInChildren<T>();
        //�� ������Ʈ�� �ڽ��� ����
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))//�����̽�
        //{
        //    text.text = "�����̽� ����";
        //}
        //if (Input.GetKeyDown(KeyCode.Return))//����
        //{
        //    text.text = "���� ����";
        //}

        //if (Input.GetKeyDown(KeyCode.Escape))//esc
        //{
        //    text.text = "";
        //}

        //��

        //�迭�� ���� �������� �����Ǵ� �����͸� ���������� �����ϴ� �ڵ�
        //foreach(������ ������ in ����)
        //{
        //  
        //}

        //keycode ������ ������ ��ü�� �����մϴ�
        foreach (KeyCode key in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(key))
            {
                switch (key)
                {
                    case KeyCode.Space:
                        text.text = "�����̽� ����";
                        break;
                    case KeyCode.Return:
                        text.text = "���� ����";
                        break;
                    case KeyCode.Escape:
                        text.text = "";
                        break;
                }
            }
        }
    }
}
