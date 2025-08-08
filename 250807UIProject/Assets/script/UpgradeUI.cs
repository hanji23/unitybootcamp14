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

    //�迭�� �� ���� ���� ä�� ���� �˴ϴ�.
    //�ڷ���[] �迭�� = new �ڷ���[] { ��1, ��2, ��3 };
    private string[] materials = new string[]
    {
        "100 ���",
        "100 ��� + ���",
        "200 ��� + �����̾� + ���¼�",
        "�ִ� ��ȭ �Ϸ�"
    };

    private string[] useitem = new string[]
    {
        "���",
        "�����̾�",
        "���¼�"
    };

    public int usegold = 0;
    public int useruby = 0;
    public int usesapa = 0;
    public int usempstone = 0;

    //private int upgrade = 0;

    //max_level�� ����� ��� �迭�� ���� -1���� ������ �˴ϴ�
    //private int max_level => materials.Length -1;
    //�迭���� �ε������ ������ �����մϴ�.
    //ex)materials�� �ϳ��� �����̰�, �ű⼭ 2��° �����ʹ� materials[1]�Դϴ�. (ī��Ʈ�� 0���� ��)

    private void Start()
    {
        playerstat = playerstat.GetComponent<UnitStat>();
        playerinven = playerinven.GetComponent<UnitInventory>();

        playerstat.max_level = materials.Length - 1;
        button01.onClick.AddListener(OnUpgrageBtnClick);

        //AddListener�� ����Ƽ�� UI�� �̺�Ʈ ����� �������ִ� �ڵ�
        //������ �� �ִ� ���� ���°� ������ �־ �� ���´�� ����������մϴ�.
        //�ٸ� ���·� ���� ���(�Ű������� �ٸ� ���)��� delegate�� Ȱ���մϴ�
        //Ư¡) �� ����� ���� �̺�Ʈ�� ����� �����Ѵٸ� ����Ƽ �ν����Ϳ��� ����� �� Ȯ�� �Ҽ� �����ϴ�.
        //���� : ���� ��������ʾƼ� �߸� ���� Ȯ���� �������ϴ�.

        UpdateUI();
        //���۽� UI�� ���� ������ ����
    }

    //��ư Ŭ���� ȣ���� �޼ҵ� ����
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
                            case "���":
                                useruby = 1;
                                break;
                            case "�����̾�":
                                usesapa = 1;
                                break;
                            case "���¼�":
                                usempstone = 1;
                                break;
                        }
                    }
                }
            }
           
            if (playerinven.gold - usegold < 0 || playerinven.ruby - useruby < 0 || playerinven.sapa - usesapa < 0 || playerinven.mpstone - usempstone < 0 )
            {
                Debug.Log("����!");
                message.text = $"{materials[playerstat.upgrade].ToString()}  \n��ᰡ �����մϴ�";
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
