using UnityEngine;
using UnityEngine.UI;

//키를 입력하면 텍스트에 특정 메세지가 나오도록 하는 코드

public class LegacyExample : MonoBehaviour
{
    public Text text;

    private void Start()
    {
        text = GetComponentInChildren<Text>();
        //GetComponentInChildren<T>();
        //현 오브젝트의 자식을 연결
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))//스페이스
        //{
        //    text.text = "스페이스 누름";
        //}
        //if (Input.GetKeyDown(KeyCode.Return))//엔터
        //{
        //    text.text = "엔터 누름";
        //}

        //if (Input.GetKeyDown(KeyCode.Escape))//esc
        //{
        //    text.text = "";
        //}

        //↓

        //배열과 같은 묶음으로 관리되는 데이터를 순차적으로 조사하는 코드
        //foreach(데이터 변수명 in 묶음)
        //{
        //  
        //}

        //keycode 형태의 데이터 전체를 조사합니다
        foreach (KeyCode key in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(key))
            {
                switch (key)
                {
                    case KeyCode.Space:
                        text.text = "스페이스 누름";
                        break;
                    case KeyCode.Return:
                        text.text = "엔터 누름";
                        break;
                    case KeyCode.Escape:
                        text.text = "";
                        break;
                }
            }
        }
    }
}
