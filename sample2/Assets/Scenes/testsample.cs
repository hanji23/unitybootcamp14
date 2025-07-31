using UnityEngine;
using UnityEngine.UI;

public class testsample : MonoBehaviour
{
    Text text1, text2, text3, text4, text5;
    
    int tryitem = 10; // 강화확률 화면에선 *10 배서 보여줌
    int trycount = 0;//시도 횟수 10까지
    int result = 0; // 성공 횟수
    int atk = 50; // 기본 공격력 50 
    int atk_plus = 0; // 강화 성공 시 + 5


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        text1 = transform.Find("name").GetComponent<Text>();
        text2 = transform.Find("atk").GetComponent<Text>();
        text3 = transform.Find("count").GetComponent<Text>();
        text4 = transform.Find("good").GetComponent<Text>();
        text5 = transform.Find("result").GetComponent<Text>();

        text1.text = $"검 (+{result})";
        text2.text = $"공격력 : {atk} (+{atk_plus})";
        text3.text = $"강화 수치 {trycount} / 10";
        text4.text = $"성공 확률 : {tryitem * 10}%";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))//스페이스
        {

            if (trycount < 10)
            {
                int i = Random.Range(1, 11);

                if (i <= result)
                {
                    text5.text = $"실패!";
                }
                else
                {
                    result++;
                    atk_plus += 5;
                    tryitem--;
                    text5.text = $"성공!";
                }

                trycount++;

                text1.text = $"검 (+{result})";
                text2.text = $"공격력 : {atk} (+{atk_plus})";
                text3.text = $"강화 수치 {trycount} / 10";
                text4.text = $"성공 확률 : {tryitem * 10}%";
            }
            else
            {
                text5.text = $"강화 끝! 엔터를 눌러 새로운 검을 강화하십시오!";
            }
        }
        if (Input.GetKeyDown(KeyCode.Return))//엔터
        {
             tryitem = 10; // 강화확률 화면에선 *10 배서 보여줌
             trycount = 0;//시도 횟수 10까지
             result = 0; // 성공 횟수
             atk = 50; // 기본 공격력 50 
             atk_plus = 0; // 강화 성공 시 + 5

            text1.text = $"검 (+{result})";
            text2.text = $"공격력 : {atk} (+{atk_plus})";
            text3.text = $"강화 수치 {trycount} / 10";
            text4.text = $"성공 확률 : {tryitem * 10}%";
            text5.text = "";
        }
        //Random.Range(1,0);

    }
}
