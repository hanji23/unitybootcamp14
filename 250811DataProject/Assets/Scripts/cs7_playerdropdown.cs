using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cs7_playerdropdown : MonoBehaviour
{
    public Dropdown dropdown;
    public Text t1, t2, t3, t4;
    charaterList list;

    private List<string> options = new List<string> { "���A", "����B", "�´�C", "��" };

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
        dropdown.ClearOptions();// ��Ӵٿ��� option ����� �����ϴ� �ڵ�
        dropdown.AddOptions(options);
        list = new charaterList()
        {
            charaters = new charaterData[]
            {
                //new �����ڸ�() {�ʵ�� = ��, �ʵ�� = ��2, ...} �ش� ������ ���� ���� Ŭ���� ��ü�� �����˴ϴ�.
                new charaterData () { charater_class = "����", hp = 100, atk =75, def = 25 },
                new charaterData () { charater_class = "���", hp = 50, atk = 150, def = 50 },
                new charaterData () { charater_class = "��Ŀ", hp = 75, atk = 25, def = 100 },
                new charaterData () { charater_class = "�ü�", hp = 25, atk = 200, def = 0 }
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
        Debug.Log($"���� ���õ� �޴��� {dropdown.options[idx].text} �Դϴ�");

        if (options != null && options.Count > 0)
        {
            t1.text = $"class : {list.charaters[idx].charater_class}";
            t2.text = $"hp : {list.charaters[idx].hp}";
            t3.text = $"atk : {list.charaters[idx].atk}";
            t4.text = $"def : {list.charaters[idx].def}";
        }
    }
}
