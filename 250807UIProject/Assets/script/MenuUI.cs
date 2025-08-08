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
        EditorApplication.isPlaying = false; //������ ȯ�� ( EditorApplication.Exit(0)�� �����͸� ���� ������)
#else
        Application.Quit(); //���� ȯ��
#endif
    }

    private void RuleView()
    {
        RuleUI.SetActive(true);
    }

    private void GameStart()
    {
        //�� �̵�
        //���ǻ��� :  ���� ����Ƽ �����Ϳ��� ��ϵǾ� �־�� �մϴ�.
        SceneManager.LoadScene("SampleScene");
    }
}
