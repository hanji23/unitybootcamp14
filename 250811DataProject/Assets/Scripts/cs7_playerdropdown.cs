using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cs7_playerdropdown : MonoBehaviour
{
    public Dropdown dropdown;
    public Text t1, t2, t3, t4;
    charaterList list;

    private List<string> options = new List<string> { "얘는A", "쟤는B", "걔는C", "밥" };

    public class charaterData
    {
        public string charater_class;
        public int hp;
        public int atk;
        public int def;
    }

    [Serializable]
    public class charaterList
    {
        public charaterData[] charaters;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dropdown.ClearOptions();// 드롭다운의 option 명단을 제거하는 코드
        dropdown.AddOptions(options);
        list = new charaterList()
        {
            charaters = new charaterData[]
            {
                //new 생성자명() {필드명 = 값, 필드명 = 값2, ...} 해당 형태의 값을 가진 클래스 객체가 생성됩니다.
                new charaterData () { charater_class = "전사", hp = 100, atk =75, def = 25 },
                new charaterData () { charater_class = "기사", hp = 50, atk = 150, def = 50 },
                new charaterData () { charater_class = "탱커", hp = 75, atk = 25, def = 100 },
                new charaterData () { charater_class = "궁수", hp = 25, atk = 200, def = 0 }
            }
        };
        dropdown.onValueChanged.AddListener(onDropdownValueChanged);
        onDropdownValueChanged(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void onDropdownValueChanged(int idx)
    {
        Debug.Log($"현재 선택된 메뉴는 {dropdown.options[idx].text} 입니다");

        if (options != null && options.Count > 0)
        {
            t1.text = $"class : {list.charaters[idx].charater_class}";
            t2.text = $"hp : {list.charaters[idx].hp}";
            t3.text = $"atk : {list.charaters[idx].atk}";
            t4.text = $"def : {list.charaters[idx].def}";
        }
    }
}
