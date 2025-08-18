using System;
using UnityEngine;
using UnityEngine.UI;

public class LottoEventArgs : EventArgs
{
    //전달할 값에 대한 설계 (프로퍼티로 작업하며, get 기능만 주로 활성화 합니다.)
    public int Value { get; } //Value에 대한 접근만 가능

    //EventArgs에 대한 생성이 방생하면 값이 설정됩니다(생성자)
    public LottoEventArgs(int value)
    {
        Value = value;
    }
}
//enum itemList
//{
//    목검,
//    장난감검,
//    공구망치,
//    장난감망치,
//    나무꾼도끼,
//    장난감도끼,
//    비비탄총,
//    돌,
//    모래,
//    매우강한무기
//}

public class cs2_test : MonoBehaviour
{
    public event EventHandler<LottoEventArgs> OnLotto;
    Text t;

    private string[] itemList = new string[]
    {
        "목검",
        "장난감검",
        "공구망치",
         "장난감망치",
        "나무꾼도끼",
        "장난감도끼",
         "강철",
        "돌",
        "모래",
         "매우강한무기",
    };

    public void TakeLotto(int value)
    {
        //전달 받은 값을 기준으로 데미지 이벤트 매개변수를 생성해, 핸들러 호출시의 정보로 전달합니다.
        OnLotto?.Invoke(this, new LottoEventArgs(value));

        Debug.Log($"<color=red>플레이어가 {itemList[value]}를 뽑았다! <- {value}</color>");

        if (value == itemList.Length - 1)
        {
            t.text = $"플레이어가 {itemList[value]}를 뽑았다! <- {value}";
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        t = GameObject.Find("Canvas").transform.GetChild(0).GetComponent<Text>();

        

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            TakeLotto(UnityEngine.Random.Range(0, 10));
        }
    }
}
