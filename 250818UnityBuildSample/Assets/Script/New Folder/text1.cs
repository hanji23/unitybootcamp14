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
        //�� �̵�
        //���ǻ��� :  ���� ����Ƽ �����Ϳ��� ��ϵǾ� �־�� �մϴ�.
        so.level++;
        SceneManager.LoadScene($"game{so.level}Scene");
        
    }

    private void GameExit()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false; //������ ȯ�� ( EditorApplication.Exit(0)�� �����͸� ���� ������)
#else
        Application.Quit(); //���� ȯ��
#endif
    }
}
