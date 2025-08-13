using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cs8_2start2button : MonoBehaviour
{
    public cs10_so so;
    public GameObject g;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playerload(int i)
    {
        so.i = i;
        switch (i)
        {
            case 1:
                string path1 = Path.Combine(Application.persistentDataPath, "player1.json");
                check(path1);
                break;
            case 2:
                string path2 = Path.Combine(Application.persistentDataPath, "player2.json");
                check(path2);
                break;
            case 3:
                string path3 = Path.Combine(Application.persistentDataPath, "player3.json");
                check(path3);
                break;
        }
    }

    void check(string path)
    {
        if (File.Exists(path))
        {
            SceneManager.LoadScene("NextScene");
        }
        else
        {
            g.SetActive(true);
        }
    }
}
