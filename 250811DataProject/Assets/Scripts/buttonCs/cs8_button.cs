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
            //파일 텍스트를 전부 읽어서 문자형 데이터로 변경합니다.
            string json = File.ReadAllText(path1);

            cs6_pmtest1.PlayerList loaded = JsonUtility.FromJson<cs6_pmtest1.PlayerList>(json);

            //Debug.Log($"퀘스트 수락 : {loaded.quests[0].quest_name}");

            t1.text = $"이름 \n {loaded.players[0].player_name}";
            t2.text = $"직업 \n {loaded.players[0].player_class}";
            t3.text = $"체력 \n {loaded.players[0].hp}";
            t4.text = $"공격력 \n {loaded.players[0].atk}";
            t5.text = $"방어력 \n {loaded.players[0].def}";
        }
    }

    public void backButton()
    {
        SceneManager.LoadScene("StartScene");
    }
}
