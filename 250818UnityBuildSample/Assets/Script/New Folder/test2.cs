using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class test2 : MonoBehaviour
{
    Text t;
    Button button1, button2, button3;
    Button AB1, AB2, AB3, AB4, AB5;
    public SOmaker so;
    int A;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        button1 = transform.GetChild(0).GetComponent<Button>();
        button2 = transform.GetChild(1).GetComponent<Button>();
        button3 = transform.GetChild(2).GetComponent<Button>();

        AB1 = transform.GetChild(5).GetComponent<Button>();
        AB2 = transform.GetChild(6).GetComponent<Button>();
        AB3 = transform.GetChild(7).GetComponent<Button>();
        AB4 = transform.GetChild(8).GetComponent<Button>();
        AB5 = transform.GetChild(9).GetComponent<Button>();

        t = transform.GetChild(4).GetComponent<Text>();
        button1.onClick.AddListener(title);
        button2.onClick.AddListener(next);
        button3.onClick.AddListener(title);

        A = Random.Range(0, 5);

        AB1.onClick.AddListener(QA1);
        AB2.onClick.AddListener(QA2);
        AB3.onClick.AddListener(QA3);
        AB4.onClick.AddListener(QA4);
        AB5.onClick.AddListener(QA5);

        

        t.text = $"문제 {so.level} : \n {so.Q[A]}";

        AB1.transform.GetChild(0).GetComponent<Text>().text = Random.Range(0, 10).ToString();
        AB2.transform.GetChild(0).GetComponent<Text>().text = Random.Range(0, 10).ToString();
        AB3.transform.GetChild(0).GetComponent<Text>().text = Random.Range(0, 10).ToString();
        AB4.transform.GetChild(0).GetComponent<Text>().text = Random.Range(0, 10).ToString();
        AB5.transform.GetChild(0).GetComponent<Text>().text = Random.Range(0, 10).ToString();

        switch(Random.Range(0, 5))
        {
            case 0:
                AB1.transform.GetChild(0).GetComponent<Text>().text = so.A[A].ToString();
                break;
            case 1:
                AB2.transform.GetChild(0).GetComponent<Text>().text = so.A[A].ToString();
                break;
            case 2:
                AB3.transform.GetChild(0).GetComponent<Text>().text = so.A[A].ToString();
                break;
            case 3:
                AB4.transform.GetChild(0).GetComponent<Text>().text = so.A[A].ToString();
                break;
            case 4:
                AB5.transform.GetChild(0).GetComponent<Text>().text = so.A[A].ToString();
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void next()
    {
        so.level++;
        if (so.level >= 4)
        {
            SceneManager.LoadScene($"endScene");
        }
        else
        {
            SceneManager.LoadScene($"game{so.level}Scene");
        }
            
        
    }
    private void title()
    {

        SceneManager.LoadScene("TitleScene");
    }


    public void QA1()
    {
        if (so.A[A] == int.Parse(AB1.transform.GetChild(0).GetComponent<Text>().text))
        {
            t.text += $"\n {AB1.transform.GetChild(0).GetComponent<Text>().text} \n정답!";
            button2.gameObject.SetActive(true);
        }
        else
        {
            t.text += $"\n{AB1.transform.GetChild(0).GetComponent<Text>().text}\n오답...";
        }

        AB1.gameObject.SetActive(false);
        AB2.gameObject.SetActive(false);
        AB3.gameObject.SetActive(false);
        AB4.gameObject.SetActive(false);
        AB5.gameObject.SetActive(false);
        button3.gameObject.SetActive(true);
    }
    public void QA2()
    {
        if (so.A[A] == int.Parse(AB2.transform.GetChild(0).GetComponent<Text>().text))
        {
            t.text += $"\n {AB2.transform.GetChild(0).GetComponent<Text>().text} \n정답!";
            button2.gameObject.SetActive(true);
        }
        else
        {
            t.text += $"\n{AB2.transform.GetChild(0).GetComponent<Text>().text}\n오답...";
        }

        AB1.gameObject.SetActive(false);
        AB2.gameObject.SetActive(false);
        AB3.gameObject.SetActive(false);
        AB4.gameObject.SetActive(false);
        AB5.gameObject.SetActive(false);
        button3.gameObject.SetActive(true);
    }
    public void QA3()
    {
        if (so.A[A] == int.Parse(AB3.transform.GetChild(0).GetComponent<Text>().text))
        {
            t.text += $"\n {AB3.transform.GetChild(0).GetComponent<Text>().text} \n정답!";
            button2.gameObject.SetActive(true);
        }
        else
        {
            t.text += $"\n{AB3.transform.GetChild(0).GetComponent<Text>().text}\n오답...";
        }

        AB1.gameObject.SetActive(false);
        AB2.gameObject.SetActive(false);
        AB3.gameObject.SetActive(false);
        AB4.gameObject.SetActive(false);
        AB5.gameObject.SetActive(false);
        button3.gameObject.SetActive(true);
    }
    public void QA4()
    {
        if (so.A[A] == int.Parse(AB4.transform.GetChild(0).GetComponent<Text>().text))
        {
            t.text += $"\n {AB4.transform.GetChild(0).GetComponent<Text>().text} \n정답!";
            button2.gameObject.SetActive(true);
        }
        else
        {
            t.text += $"\n{AB4.transform.GetChild(0).GetComponent<Text>().text}\n오답...";
        }

        AB1.gameObject.SetActive(false);
        AB2.gameObject.SetActive(false);
        AB3.gameObject.SetActive(false);
        AB4.gameObject.SetActive(false);
        AB5.gameObject.SetActive(false);
        button3.gameObject.SetActive(true);
    }
    public void QA5()
    {
        if (so.A[A] == int.Parse(AB5.transform.GetChild(0).GetComponent<Text>().text))
        {
            t.text += $"\n {AB5.transform.GetChild(0).GetComponent<Text>().text} \n정답!";
            button2.gameObject.SetActive(true);
        }
        else
        {
            t.text += $"\n{AB5.transform.GetChild(0).GetComponent<Text>().text}\n오답...";
        }

        AB1.gameObject.SetActive(false);
        AB2.gameObject.SetActive(false);
        AB3.gameObject.SetActive(false);
        AB4.gameObject.SetActive(false);
        AB5.gameObject.SetActive(false);
        button3.gameObject.SetActive(true);
    }
}
