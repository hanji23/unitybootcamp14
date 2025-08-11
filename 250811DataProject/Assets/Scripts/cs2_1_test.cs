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
        //일반적으로 게임에서 남은 시간은 남은 초를 기준으로 올림해서 보여줌

        if (checktime <= 0 && Time.timeScale != 0)
        {

            i1.gameObject.SetActive(true);

            Time.timeScale = 0;

            timetext.text = $"game over!";

            if (score > PlayerPrefs.GetInt("score", 0))
            {
                scoretext.text = $"\n score : {score} \n 기록 경신! \n 이전 최고기록 : {PlayerPrefs.GetInt("score", 0)}";
                PlayerPrefs.SetInt("score", score);
            }
            else
            {
                scoretext.text = $"\n score : {score} \n 이전 최고기록 : {PlayerPrefs.GetInt("score", 0)}";
            }
        }

        //Ray ray = new Ray(위치, 방향);

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
            EditorApplication.isPlaying = false; //에디터 환경 ( EditorApplication.Exit(0)는 에디터를 완전 종료함)
#else
            Application.Quit(); //게임 환경
#endif 
        }

    }

    public void resetbutton()
    {
        if (Time.timeScale == 0)
        {
            PlayerPrefs.DeleteAll();
            scoretext.text = $"기록 초기화!";
        } 
    }
}
