using System; // Serializable
using System.Collections;  // IEnumerator
using System.Collections.Generic; //Queue
using System.Text; // StringBuilder
using TMPro; //TextMeshProUGUI(TMP_Text)
using UnityEngine;
using UnityEngine.EventSystems;

[Serializable]
public class Dialog
{
    public string character; // 캐릭터
    public string content;//대화 텍스트

    //오른쪽 버튼 -> 빠른작업 및 리펙토링 -> 멤버에서 생성자 생성
    //클래스 생성 시 호출되는 메소드(생성자)
    public Dialog(string character, string content)
    {
        //this는 클래스 자신을 의미합니다.
        //여기서 this는 클래스가 가진 값과 매개변수와 이름이 같아서 구분하기 위한 용도
        this.character = character;
        this.content = content;
    }
}

//매니저 코드(Manager)
// 특정 기능이나 시스템을 중앙에서 관리하는 스크립트 또는 객체
// 대규모의 게임, UI 데이터 공유등에서 사용되는 핵심 역할
//목적) 오브젝트나 시스템들을 한곳에서 관리하는 용도
// 각 오브젝트가 개별적으로 로직을 처리하는 것이 아닌 매니저에 해당 기능을 위임합니다
// 다른 씬에서도 재사용이 가능한 용도로 설계됩니다 (씬간의 데이터를 유지)

//대표적인 예시
// 1. GameManager : 게임 시작, 종료, 정지, 씬 전환 등을 관리
// 2. UIManager : UI 창에 대한 열고 닫음
// 3. SceneManager : 유니티에서 제공해주는 이 기능은 씬에 대한 로딩 , 전환등을 관리합니다


public class DialogManager : MonoBehaviour
{
    //매니저의 설계방식(Singleton)
    //프로그램 전체에서 단 하나의 인스턴스만 존재하도록 보장하는 설계방식
    #region MonoSingleton (MonoBehaviour에서 사용가능)

    // 1) 자기자신에 대한 인스턴스를 가진자 (전역)
    public static DialogManager Instance { get; private set; } //프로퍼티
    //instance는 값을 얻어올수 있습니다.(접근가능) 수정은 할 수 없습니다.

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this; // 해당 인스턴스는 자기 자신입니다.
            DontDestroyOnLoad(gameObject);//DDOL은 해당 위치에 있는 오브젝트가 씬이 넘어가도 파괴되지 않게 따로 관리되는 씬의 영역
        }
        else
        {
            Destroy(gameObject);
        }
    }

    #endregion

    public TextMeshProUGUI message; //TextMeshProUGUI 전반을 사용
    public TMP_Text character_name; //TextMeshProUGUI 중 text만 사용
    public GameObject panel;
    public float typing_speed;

    //큐(Queue)
    //선입선출 구조로 설계 되어있는 자료구조 (First - In First- Out) FIFO
    // 먼저 넣어준 데이터가 먼저 제거되는 방식 (대화, 대기열 등의 기능을 구현할때 우선적으로 고려되는 자료구조)
    //특징)
    // Enqueue(값) : 데이터 추가
    // Dequeue() : 가장먼저 들어온값 제거
    // Peek() : 현재 가장 먼저 들어와있는 값 확인 가능
    // Count() : 현재 큐에 등록된 요소의 갯수

    // 예시
    // Queue<string> queue = new Queue<string>(); //큐생성
    // queue.Enqueue("오늘의 추천 메뉴"); // 값 추가
    // queue.Enqueue("바나나맛 우유"); 
    // string data = queue.Dequeue();
    // 처음 들어온 "오늘의 추천 메뉴"이 return 되고 큐 내부에서 삭제됩니다.

    private Queue<Dialog> queue = new Queue<Dialog>();
    private Coroutine typing;
    private bool isTyping = false;
    private Dialog current; // 현재의 대화내용


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //이벤트 시스템에 전달된 값이 존재하고, 그 값이 UI위에서 눌러진 상황이라면?
            if(EventSystem.current != null && EventSystem.current.IsPointerOverGameObject())
            {
                //작업종료
                return;
            }

            //스페이스를 눌러 정상적으로 작업중인 경우(대화매니저가 있고, 대화중인 경우)
            if (isTyping)// 타이핑 중이라면 
            {
                CompleteLine(); //라인을 실행 시킵니다.
            }
            else
            {
                NextLine(); // 다음 라인으로 이동 합니다.
            }
        }
    }

    /// <summary>
    /// List<T>나 Queue<T> 처럼 열거 형태의 데이터를 다 매개 변수로 받을수 있습니다.
    /// </summary>
    /// <param name="lines">대화 데이터에 대한 열거형 묶음 데이터</param>
    public void StartLine(IEnumerable<Dialog> lines)
    {
        queue.Clear();
        foreach (/*Dialog*/var line in lines) 
        {
            queue.Enqueue(line);
        }
        panel.SetActive(true);
        NextLine();
    }

    private void NextLine()
    {
        //작업할 내용이 더 이상 없다면
        if(queue.Count == 0)
        {
            DialogExit(); //대화의 종료
            return;
        }

        //큐에 저장된 값을 하나 얻어옵니다
        current = queue.Dequeue();
        //현재 대화기준 캐릭터 이름으로 변경
        character_name.text = current.character; 

        if (typing != null)
        {
            StopCoroutine(typing);
        }

        //현재 대화 데이터의 콘텐츠(대화 내용)을 기준으로 대화 타이핑을 시작합니다.
        typing = StartCoroutine(TypingDialogue(current.content));
    }

    private void DialogExit()
    {
        panel.SetActive(false);//패널 종료
    }


    private void CompleteLine()
    {
        if(typing != null)
        {
            StopCoroutine(typing);
        }

        message.text = current.content;
        isTyping = false;
    }

    private IEnumerator TypingDialogue(string line)
    {
        isTyping = true; // 타이핑 진행 중임을 알림

        //System.Text.StringBuilder 클래스는 문자열을 효율적으로 다룰 수 있게 도와주는 클래스입니다 (C#책 310~321 참고)
        // 사용목적
        // C#의 string은 한번 생성되면 수정이 불가능합니다 (immutable object)
        //문자열의 경우 + 연산이 진행되면 새로운 문자열을 생성하는 구조

        //StringBuilder의 경우는 내부에 있는 버퍼의 의해 문자열을 누적해서 수정할 수 있습니다.
        // 기능
        // 1. 문자열 결합 Append()
        // 2. 문자열 + 줄바꿈 AppendLine()
        // 3. 원하는 위치에 문자열 삽입 Insert()
        // 4, 인덱스 기준으로 문자열 삭제하기 Remove()
        // 5. 특정 문자를  다른 값으로 교체하기 Replace()
        // 6. 문자열 전체 제거 Clear()
        // 7. 결과물로 변환 ToStrnig()

        //성능에 대한 비교 string에서의 + 연산 과정 vs StringBuilder
        //작업량이 많을 경우 Builder가 유리
        //작업량이 적을 경우 string + 가 유리
        //GC 발생여부 Builder가 더 적게 발생합니다
        //실시간 조작여부 : Builder가 최적화 단계에서 더 유리합니다

        StringBuilder stringBuiler = new StringBuilder(line.Length);

        message.text = ""; //내용 비우기

        //string(문자열)은 문자(char)의 배열
        foreach(char c in line)
        {
            //message.text += c;
            stringBuiler.Append(c);
            message.text = stringBuiler.ToString();
            yield return new WaitForSeconds(typing_speed);
        }
        isTyping = false;
    }
}