using NUnit.Framework.Internal;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public Text bestText;
    public Text destroyText;
    public Text endText;

    public static ScoreManager Instance = null;

    public int destroy;

    public text1_SOMaker so;

    public UnityEvent OnClear;
    public UnityAction OnClearAction;

    //SO를 선택한 이유 - 최고점수는 외부에서 수정할수 있게하면 안된다 생각하여(점수조작의 가능성) SO를 선택함

    // 싱글톤 형태의 코드
    // 1) 자기와 같은 형태의 전역 인스턴스를 선언합니다.
    //  ㄴ public static 클래스명 Instance;
    //  >> 외부에서는 ScoreManager.Instance 라고 검색이 가능해지며 Instance는 클래스에 대한 결과물(인스턴스)이기에
    //  클래스명.변수명, 클래스명.함수()를 사용할 수 있게 됩니다.
    //결과적으로 외부에서 직접 연결하지않고 기능을 사용하기 위함

    // 2) 프로그램 내에서 유일한 데이터로 설계한다.
    //      보통 게임의 시스템을 관리하는 매니저 코드들은 싱글톤으로 설계됩니다.

    private int score;
    private int best;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        OnClear.AddListener(ClearGame);
        best = so.bestScore;
        destroy = 0;
        SetScoreText(score);
        SetbestText(best);
    }

    public void SetScore(int value)
    {
        score += value; // 전달받은 값만큼 점수증가
        destroy++;
        SetScoreText(score);
        destroyText.text = $"{destroy} : 격추";

        if (score > best)
        {
            best = score;
            so.bestScore = best;
            SetbestText(best);
        }

        if (destroy == 20)
        {
            OnClear?.Invoke();
        }
    }

    private void SetScoreText(int score) => scoreText.text = $"Score : {score}";
    private void SetbestText(int best) => bestText.text = $"Best : {so.bestScore}";

    public int GetScore() => score;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ClearGame()
    {
        //Time.timeScale = 0;
        endText.gameObject.SetActive(true);
        endText.text = "클리어!";
    }

}
