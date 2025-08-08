using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    public Button buton1;
    public Button buton2;
    public Button buton3;

    public GameObject RuleUI;

    private void Start()
    {
        buton1.onClick.AddListener(GameStart);
        buton2.onClick.AddListener(RuleView);
        buton3.onClick.AddListener(GameExit);
    }

    private void GameExit()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false; //에디터 환경 ( EditorApplication.Exit(0)는 에디터를 완전 종료함)
#else
        Application.Quit(); //게임 환경
#endif
    }

    private void RuleView()
    {
        RuleUI.SetActive(true);
    }

    private void GameStart()
    {
        //씬 이동
        //유의사항 :  씬이 유니티 에디터에서 등록되어 있어야 합니다.
        SceneManager.LoadScene("SampleScene");
    }
}
