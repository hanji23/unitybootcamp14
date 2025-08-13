using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class cs8_1startbutton : MonoBehaviour
{
    public Image i1, i2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ButtonCheck(int i)
    {
        switch (i)
        {
            case 1:
                string path1 = Path.Combine(Application.persistentDataPath, "player1.json");
                sel(path1);
                break;
            case 2:
                string path2 = Path.Combine(Application.persistentDataPath, "player2.json");
                sel(path2);
                break;
            case 3:
                string path3 = Path.Combine(Application.persistentDataPath, "player3.json");
                sel(path3);
                break;
        }
    }

    void sel(string path)
    {
        if (File.Exists(path))
        {
            i2.gameObject.SetActive(true);
        }
        else
        {
            Debug.LogWarning("해당 경로에 json파일이 없습니다.");
            i1.gameObject.SetActive(true);
        }
    }
}
