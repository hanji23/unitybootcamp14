using System.IO;
using UnityEngine;

public class cs8_3Resetbutton : MonoBehaviour
{
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
        string path1 = Path.Combine(Application.persistentDataPath, "player1.json");
        if (File.Exists(path1))
        {
            File.Delete(path1);
        }

        string path2 = Path.Combine(Application.persistentDataPath, "player2.json");
        if (File.Exists(path2))
        {
            File.Delete(path2);
        }

        string path3 = Path.Combine(Application.persistentDataPath, "player3.json");
        if (File.Exists(path3))
        {
            File.Delete(path3);
        }

    }
}
