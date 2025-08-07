using UnityEngine;
using TMPro;

public class TextMeshProSample : MonoBehaviour
{
    //TMP를 사용하는 UI 컴포넌트
    public TextMeshProUGUI textUI;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //리치 텍스트(HTNL 태그 같은 느낌) 제공
        textUI.text = "<size=150%>안녕</size><s>취~소</s>";
    }

    public void SetText(bool wanning)
    {
        if (wanning)
        {
            textUI.text = "<color=red><b>경고!</b></color>";
        }
        else
        {
            textUI.text = "<color=green>안녕</color>";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
