using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class cs8_4Endbutton : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(GameExit);
    }

    // Update is called once per frame
    void Update()
    {
        
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
