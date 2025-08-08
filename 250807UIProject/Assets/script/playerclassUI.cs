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
    #region MonoSingleton (MonoBehaviour에서 사용가능)

    // 1) 자기자신에 대한 인스턴스를 가진자 (전역)
    public static playerclassUI Instance { get; private set; } //프로퍼티
    //instance는 값을 얻어올수 있습니다.(접근가능) 수정은 할 수 없습니다.

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this; // 해당 인스턴스는 자기 자신입니다.
            DontDestroyOnLoad(gameObject);//DDOL은 해당 위치에 있는 오브젝트가 씬이 넘어가도 파괴되지 않게 따로 관리되는 씬의 영역
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
        text.text = "버튼을 누름";

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
