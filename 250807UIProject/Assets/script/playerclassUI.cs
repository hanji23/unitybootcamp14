using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class playerUI
{
    public string character;
    public string option1;
    public string option2;
    public string option3;

    public playerUI(string character, string option1, string option2, string option3)
    {
        
        this.character = character;
        this.option1 = option1;
        this.option2 = option2;
        this.option3 = option3;
    }
}

public class playerclassUI : MonoBehaviour
{
    #region MonoSingleton (MonoBehaviour���� ��밡��)

    // 1) �ڱ��ڽſ� ���� �ν��Ͻ��� ������ (����)
    public static playerclassUI Instance { get; private set; } //������Ƽ
    //instance�� ���� ���ü� �ֽ��ϴ�.(���ٰ���) ������ �� �� �����ϴ�.

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this; // �ش� �ν��Ͻ��� �ڱ� �ڽ��Դϴ�.
            DontDestroyOnLoad(gameObject);//DDOL�� �ش� ��ġ�� �ִ� ������Ʈ�� ���� �Ѿ�� �ı����� �ʰ� ���� �����Ǵ� ���� ����
        }
        else
        {
            Destroy(gameObject);
        }
    }

    #endregion

    public List<TMP_Dropdown> dropdown_list;

    public TMP_Text text;

    private Queue<playerUI> queue = new Queue<playerUI>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UIreset();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playerUIUpdate1()
    {
        UIreset();
    }

    public void playerUIUpdate2()
    {
        text.text = "��ư�� ����";

        for (int i = 0; i < dropdown_list.Count; i++)
        {
            text.text = text.text + "\n" + dropdown_list[i].options[dropdown_list[i].value].text;
            
        }

    }

    void UIreset()
    {
        text.text = "";

        for (int i = 0; i < dropdown_list.Count; i++)
        {
            text.text = text.text + "\n" + dropdown_list[i].options[dropdown_list[i].value].text;
        }
    }
}
