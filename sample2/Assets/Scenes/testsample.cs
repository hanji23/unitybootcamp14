using UnityEngine;
using UnityEngine.UI;

public class testsample : MonoBehaviour
{
    Text text1, text2, text3, text4, text5;
    
    int tryitem = 10; // ��ȭȮ�� ȭ�鿡�� *10 �輭 ������
    int trycount = 0;//�õ� Ƚ�� 10����
    int result = 0; // ���� Ƚ��
    int atk = 50; // �⺻ ���ݷ� 50 
    int atk_plus = 0; // ��ȭ ���� �� + 5


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        text1 = transform.Find("name").GetComponent<Text>();
        text2 = transform.Find("atk").GetComponent<Text>();
        text3 = transform.Find("count").GetComponent<Text>();
        text4 = transform.Find("good").GetComponent<Text>();
        text5 = transform.Find("result").GetComponent<Text>();

        text1.text = $"�� (+{result})";
        text2.text = $"���ݷ� : {atk} (+{atk_plus})";
        text3.text = $"��ȭ ��ġ {trycount} / 10";
        text4.text = $"���� Ȯ�� : {tryitem * 10}%";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))//�����̽�
        {

            if (trycount < 10)
            {
                int i = Random.Range(1, 11);

                if (i <= result)
                {
                    text5.text = $"����!";
                }
                else
                {
                    result++;
                    atk_plus += 5;
                    tryitem--;
                    text5.text = $"����!";
                }

                trycount++;

                text1.text = $"�� (+{result})";
                text2.text = $"���ݷ� : {atk} (+{atk_plus})";
                text3.text = $"��ȭ ��ġ {trycount} / 10";
                text4.text = $"���� Ȯ�� : {tryitem * 10}%";
            }
            else
            {
                text5.text = $"��ȭ ��! ���͸� ���� ���ο� ���� ��ȭ�Ͻʽÿ�!";
            }
        }
        if (Input.GetKeyDown(KeyCode.Return))//����
        {
             tryitem = 10; // ��ȭȮ�� ȭ�鿡�� *10 �輭 ������
             trycount = 0;//�õ� Ƚ�� 10����
             result = 0; // ���� Ƚ��
             atk = 50; // �⺻ ���ݷ� 50 
             atk_plus = 0; // ��ȭ ���� �� + 5

            text1.text = $"�� (+{result})";
            text2.text = $"���ݷ� : {atk} (+{atk_plus})";
            text3.text = $"��ȭ ��ġ {trycount} / 10";
            text4.text = $"���� Ȯ�� : {tryitem * 10}%";
            text5.text = "";
        }
        //Random.Range(1,0);

    }
}
