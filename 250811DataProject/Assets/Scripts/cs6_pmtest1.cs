using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class cs6_pmtest1 : MonoBehaviour
{
    string path1;
    string path2;
    string path3;

    public Dropdown dropdown;
    public Text t1, t2, t3, t4;

    [Serializable]
    public class PlayerData
    {
        public string player_name;
        public string player_class;
        public int hp;
        public int atk;
        public int def;
    }

    [Serializable]
    public class PlayerList
    {
        public PlayerData[] players;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void playerload()
    {
        if (File.Exists(path1))
        {
            //파일 텍스트를 전부 읽어서 문자형 데이터로 변경합니다.
            string json2 = File.ReadAllText(path1);

            PlayerList loaded = JsonUtility.FromJson<PlayerList>(json2);

        }
    }

    public void playerCreate()
    {
        string[] table1 = t1.text.Split(" : ");
        string[] table2 = t2.text.Split(" : ");
        string[] table3 = t3.text.Split(" : ");
        string[] table4 = t4.text.Split(" : ");

        PlayerList list = new PlayerList()
        {
            players = new PlayerData[]
    {
                //new 생성자명() {필드명 = 값, 필드명 = 값2, ...} 해당 형태의 값을 가진 클래스 객체가 생성됩니다.
                new PlayerData () { player_name = dropdown.options[dropdown.value].text, player_class = table1[1], hp = int.Parse(table2[1]), atk = int.Parse(table3[1]), def =int.Parse(table4[1])}
    }
        };

        string json = JsonUtility.ToJson(list, true);
        string path = Path.Combine(Application.persistentDataPath, "player1.json");
        File.WriteAllText(path, json);
        Debug.Log("플레이어 생성!");
    }
}
