using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
//드롭다운의 구성 요소
//1. template : 드롭다운이 펼쳐졌을때 보이는 리스트 항목
//2. Caption / Item Text : 현재 선택된 항목 / 리스트 항목 각각에 대한 텍스트
//  tmp를 쓰는 경우, 한글 사용을 위해 Label과 item Label에서 사용중인 폰트를 수정해 주셔야 사용할수 있습니다.
//3. Option : 드롭 다운에 표시될 항목에 대한 리스트 인스펙터를 통해 직접 등록이 가능합니다
//  등록하면 바로 리스트에 적용됩니다
//4. ON Value Changed : 사용자가 항목을 선택했을때 호출되는 이벤트 인스펙터를 통해 직접 등록할 수 있습니다.
//  드롭다운값에 대한 변경 발생시 호출 됩니다
public class DropdownSample : MonoBehaviour
{
    public TMP_Dropdown dropdown;

    public List<playerUI> P;

    //options에 등록할 값은 문자열

    //리스트에 값을 넣고 생성하는 방법
    //리스트<T> 리스트명 = new 리스트명<T>{요소, 요소, 요소 ...}
    //private List<string> options = new List<string> { "A", "B", "C" ,"D"};

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //dropdown.ClearOptions();// 드롭다운의 option 명단을 제거하는 코드
        //dropdown.AddOptions(options); // 준비된 명단에 대한 추가하는 기능

        //dropdown.onValueChanged.AddListener(onDropdownValueChanged);
        //이벤트 등록시 요구하는 함수의 형태대로 작성이 됬다면 함수의 이름을 넣어 사용할 수 있게 됩니다
    }

    //  C# System.Int32  ->  int
    //     System.Int64  -> long
    //     System.UInt32 -> uint (부호가 없는 32비트 정수)

    void onDropdownValueChanged(int idx)
    {
        Debug.Log($"현재 선택된 메뉴는 {dropdown.options[idx].text} 입니다");

        //if (options != null && options.Count > 0)
        //{
            playerclassUI.Instance.playerUIUpdate1();
            //클래스명.Instance.메소드명()과 같이 클래스의 값을 바로 사용할 수 있습니다
            //따로 값을 GetCompnonent나 public등으로 등록해서 사용할 필요가 없어 편합니다
        //}
    }
}
