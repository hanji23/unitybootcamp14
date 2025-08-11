using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class cs2_1_test : MonoBehaviour
{
    float checktime;
    int time;
    int score;

    public Text timetext, scoretext;
    public Image i1;

    private Camera cam;
    public LayerMask layerMask;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = Camera.main;

        restart();
    }

    // Update is called once per frame
    void Update()
    {
        checktime -= Time.deltaTime;
        time = Mathf.CeilToInt(checktime);
        timetext.text = $"time : {time}";
        //�Ϲ������� ���ӿ��� ���� �ð��� ���� �ʸ� �������� �ø��ؼ� ������

        if (checktime <= 0 && Time.timeScale != 0)
        {

            i1.gameObject.SetActive(true);

            Time.timeScale = 0;

            timetext.text = $"game over!";

            if (score > PlayerPrefs.GetInt("score", 0))
            {
                scoretext.text = $"\n score : {score} \n ��� ���! \n ���� �ְ��� : {PlayerPrefs.GetInt("score", 0)}";
                PlayerPrefs.SetInt("score", score);
            }
            else
            {
                scoretext.text = $"\n score : {score} \n ���� �ְ��� : {PlayerPrefs.GetInt("score", 0)}";
            }
        }

        //Ray ray = new Ray(��ġ, ����);

        if (Input.GetMouseButtonDown(0) && time > 0)
        {
            //Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            //if (Physics.Raycast(ray, out RaycastHit hit, 20, layerMask))
            //{
            //    score++;
            //    scoretext.text = $"score : {score}";
            //}

            Vector2 ray = cam.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray, Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject.layer == LayerMask.NameToLayer("enemy"))
            {
                score++;
                scoretext.text = $"score : {score}";
            }

        }
    }

    public void restart()
    {
        if (Time.timeScale == 0)
        {
            i1.gameObject.SetActive(false);

            checktime = 60;
            score = 0;

            timetext.text = $"time : {time}";
            scoretext.text = $"score : {score}";

            Time.timeScale = 1;
        }

    }

    public void endgame()
    {
        if (Time.timeScale == 0)
        {
#if UNITY_EDITOR
            EditorApplication.isPlaying = false; //������ ȯ�� ( EditorApplication.Exit(0)�� �����͸� ���� ������)
#else
            Application.Quit(); //���� ȯ��
#endif 
        }

    }

    public void resetbutton()
    {
        if (Time.timeScale == 0)
        {
            PlayerPrefs.DeleteAll();
            scoretext.text = $"��� �ʱ�ȭ!";
        } 
    }
}
