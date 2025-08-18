using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class text1 : MonoBehaviour
{

    Button button1, button2;
    public SOmaker so;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        button1 = transform.GetChild(1).GetComponent<Button>();
        button2 = transform.GetChild(2).GetComponent<Button>();
        button1.onClick.AddListener(GameStart);
        button2.onClick.AddListener(GameExit);

        so.level = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void GameStart()
    {
        //씬 이동
        //유의사항 :  씬이 유니티 에디터에서 등록되어 있어야 합니다.
        so.level++;
        SceneManager.LoadScene($"game{so.level}Scene");
        
    }

    private void GameExit()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false; //에디터 환경 ( EditorApplication.Exit(0)는 에디터를 완전 종료함)
#else
        Application.Quit(); //게임 환경
#endif
    }
}
