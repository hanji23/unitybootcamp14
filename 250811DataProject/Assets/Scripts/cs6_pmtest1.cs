using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class cs6_pmtest1 : MonoBehaviour
{
    string path1 = null;
    string path2 = null;
    string path3 = null;

    public Dropdown dropdown;
    public Text t1, t2, t3, t4;
    public Text t5, t6;

    int i;
    public cs10_so so;

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

    public static cs6_pmtest1 Instance { get; private set; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerload();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void playerload()
    {
        string path1 = Path.Combine(Application.persistentDataPath, "player1.json");
        string path2 = Path.Combine(Application.persistentDataPath, "player2.json");
        string path3 = Path.Combine(Application.persistentDataPath, "player3.json");

        if (File.Exists(path1) || File.Exists(path2) || File.Exists(path3))
        {
            t5.gameObject.SetActive(true);
            t6.gameObject.SetActive(true);
        }
        else
        {
            t5.gameObject.SetActive(false);
            t6.gameObject.SetActive(false);
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
        string path = Path.Combine(Application.persistentDataPath, $"player{i}.json");

        File.WriteAllText(path, json);
        Debug.Log($"플레이어 생성!\n{path}");
        so.i = i;

        SceneManager.LoadScene("NextScene");
    }

    public void seli(int i)
    {
        this.i = i;
    }
}
