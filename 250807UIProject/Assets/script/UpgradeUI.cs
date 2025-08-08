using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class UpgradeUI : MonoBehaviour
{
    public Button button01;
    public  Text message;
    public Text icon_text;

    public UnitStat playerstat;
    public UnitInventory playerinven;

    string[] item_table;

    //배열이 그 값을 가진 채로 생성 됩니다.
    //자료형[] 배열형 = new 자료형[] { 값1, 값2, 값3 };
    private string[] materials = new string[]
    {
        "100 골드",
        "100 골드 + 루비",
        "200 골드 + 사파이어 + 마력석",
        "최대 강화 완료"
    };

    private string[] useitem = new string[]
    {
        "루비",
        "사파이어",
        "마력석"
    };

    public int usegold = 0;
    public int useruby = 0;
    public int usesapa = 0;
    public int usempstone = 0;

    //private int upgrade = 0;

    //max_level을 사용할 경우 배열의 길이 -1값을 가지게 됩니다
    //private int max_level => materials.Length -1;
    //배열에는 인덱스라는 개념이 조재합니다.
    //ex)materials가 하나의 묶음이고, 거기서 2번째 데이터는 materials[1]입니다. (카운트를 0부터 셈)

    private void Start()
    {
        playerstat = playerstat.GetComponent<UnitStat>();
        playerinven = playerinven.GetComponent<UnitInventory>();

        playerstat.max_level = materials.Length - 1;
        button01.onClick.AddListener(OnUpgrageBtnClick);

        //AddListener는 유니티의 UI의 이벤트 기능을 연결해주는 코드
        //전달할 수 있는 값의 형태가 정해져 있어서 그 형태대로 설계해줘야합니다.
        //다른 형태로 쓰는 경우(매개변수가 다른 경우)라면 delegate를 활용합니다
        //특징) 이 기능을 통해 이벤트에 기능을 전달한다면 유니티 인스펙터에서 연결된 걸 확인 할수 없습니다.
        //장점 : 직접 등록하지않아서 잘못 넣을 확률이 낮아집니다.

        UpdateUI();
        //시작시 UI에 대한 렌더링 설정
    }

    //버튼 클릭시 호출할 메소드 설계
    private void OnUpgrageBtnClick()
    {
        if(playerstat.upgrade < playerstat.max_level)
        {
             usegold = 0;
             useruby = 0;
             usesapa = 0;
             usempstone = 0;

            item_table = materials[playerstat.upgrade].Split(" + ");

            string[] item_table2;
            item_table2 = materials[playerstat.upgrade].Split(" ");
            
            foreach (string item in item_table2)
            {
                if (item == item_table2[1])
                {
                    usegold = int.Parse(item_table2[0]);
                }
            }
            foreach (string item in item_table)
            {
                //Debug.Log(item);
                for (int i = 0; i < item_table.Length; i++)
                {
                    Debug.Log(item + " " + i + " " + item_table[i]);
                    if (item == useitem[i])
                    {
                        switch (item)
                        {
                            case "루비":
                                useruby = 1;
                                break;
                            case "사파이어":
                                usesapa = 1;
                                break;
                            case "마력석":
                                usempstone = 1;
                                break;
                        }
                    }
                }
            }
           
            if (playerinven.gold - usegold < 0 || playerinven.ruby - useruby < 0 || playerinven.sapa - usesapa < 0 || playerinven.mpstone - usempstone < 0 )
            {
                Debug.Log("실패!");
                message.text = $"{materials[playerstat.upgrade].ToString()}  \n재료가 부족합니다";
            }
            else
            {
                playerinven.gold -= usegold;
                playerinven.ruby -= useruby;
                playerinven.sapa -= usesapa;
                playerinven.mpstone -= usempstone;

                playerstat.upgrade++;
                UpdateUI();
            }
           
        }
    }

    private void UpdateUI()
    {
        icon_text.text = $"Wizard + {playerstat.upgrade}";
        message.text = materials[playerstat.upgrade].ToString();
    }
}
