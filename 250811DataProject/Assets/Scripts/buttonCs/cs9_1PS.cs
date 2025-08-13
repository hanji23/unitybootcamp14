using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class cs9_1PS : MonoBehaviour
{
    public Text t1, t2, t3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void OnEnable()
    {
        

        string path1 = Path.Combine(Application.persistentDataPath, "player1.json");
        if (File.Exists(path1))
        {
            string json = File.ReadAllText(path1);
            cs6_pmtest1.PlayerList loaded = JsonUtility.FromJson<cs6_pmtest1.PlayerList>(json);

            t1.text = 
                $"�̸� : {loaded.players[0].player_name} \n ���� : {loaded.players[0].player_class} \n" +
                $" ü�� : {loaded.players[0].hp} \n ���ݷ� : {loaded.players[0].atk} \n ���� : {loaded.players[0].def}";
        }
        else
        {
            t1.text = "���̺� ����";
        }

            string path2 = Path.Combine(Application.persistentDataPath, "player2.json");
        if (File.Exists(path2))
        {
            string json = File.ReadAllText(path2);
            cs6_pmtest1.PlayerList loaded = JsonUtility.FromJson<cs6_pmtest1.PlayerList>(json);

            t2.text =
                $"�̸� : {loaded.players[0].player_name} \n ���� : {loaded.players[0].player_class} \n" +
                $" ü�� : {loaded.players[0].hp} \n ���ݷ� : {loaded.players[0].atk} \n ���� : {loaded.players[0].def}";
        }
        else
        {
            t2.text = "���̺� ����";
        }

        string path3 = Path.Combine(Application.persistentDataPath, "player3.json");
        if (File.Exists(path3))
        {
            string json = File.ReadAllText(path3);
            cs6_pmtest1.PlayerList loaded = JsonUtility.FromJson<cs6_pmtest1.PlayerList>(json);

            t3.text =
                $"�̸� : {loaded.players[0].player_name} \n ���� : {loaded.players[0].player_class} \n" +
                $" ü�� : {loaded.players[0].hp} \n ���ݷ� : {loaded.players[0].atk} \n ���� : {loaded.players[0].def}";
        }
        else
        {
            t3.text = "���̺� ����";
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
