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

    //SO�� ������ ���� - �ְ������� �ܺο��� �����Ҽ� �ְ��ϸ� �ȵȴ� �����Ͽ�(���������� ���ɼ�) SO�� ������

    // �̱��� ������ �ڵ�
    // 1) �ڱ�� ���� ������ ���� �ν��Ͻ��� �����մϴ�.
    //  �� public static Ŭ������ Instance;
    //  >> �ܺο����� ScoreManager.Instance ��� �˻��� ���������� Instance�� Ŭ������ ���� �����(�ν��Ͻ�)�̱⿡
    //  Ŭ������.������, Ŭ������.�Լ�()�� ����� �� �ְ� �˴ϴ�.
    //��������� �ܺο��� ���� ���������ʰ� ����� ����ϱ� ����

    // 2) ���α׷� ������ ������ �����ͷ� �����Ѵ�.
    //      ���� ������ �ý����� �����ϴ� �Ŵ��� �ڵ���� �̱������� ����˴ϴ�.

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
        score += value; // ���޹��� ����ŭ ��������
        destroy++;
        SetScoreText(score);
        destroyText.text = $"{destroy} : ����";

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
        endText.text = "Ŭ����!";
    }

}
