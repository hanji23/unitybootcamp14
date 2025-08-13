using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class cs8_button : MonoBehaviour
{
    public Text t1, t2, t3, t4, t5;

    public cs10_so so;

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
        string path1 = Path.Combine(Application.persistentDataPath, $"player{so.i}.json");
        if (File.Exists(path1))
        {
            //���� �ؽ�Ʈ�� ���� �о ������ �����ͷ� �����մϴ�.
            string json = File.ReadAllText(path1);

            cs6_pmtest1.PlayerList loaded = JsonUtility.FromJson<cs6_pmtest1.PlayerList>(json);

            //Debug.Log($"����Ʈ ���� : {loaded.quests[0].quest_name}");

            t1.text = $"�̸� \n {loaded.players[0].player_name}";
            t2.text = $"���� \n {loaded.players[0].player_class}";
            t3.text = $"ü�� \n {loaded.players[0].hp}";
            t4.text = $"���ݷ� \n {loaded.players[0].atk}";
            t5.text = $"���� \n {loaded.players[0].def}";
        }
    }

    public void backButton()
    {
        SceneManager.LoadScene("StartScene");
    }
}
