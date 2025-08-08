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
    public string character; // ĳ����
    public string content;//��ȭ �ؽ�Ʈ

    //������ ��ư -> �����۾� �� �����丵 -> ������� ������ ����
    //Ŭ���� ���� �� ȣ��Ǵ� �޼ҵ�(������)
    public Dialog(string character, string content)
    {
        //this�� Ŭ���� �ڽ��� �ǹ��մϴ�.
        //���⼭ this�� Ŭ������ ���� ���� �Ű������� �̸��� ���Ƽ� �����ϱ� ���� �뵵
        this.character = character;
        this.content = content;
    }
}

//�Ŵ��� �ڵ�(Manager)
// Ư�� ����̳� �ý����� �߾ӿ��� �����ϴ� ��ũ��Ʈ �Ǵ� ��ü
// ��Ը��� ����, UI ������ ������� ���Ǵ� �ٽ� ����
//����) ������Ʈ�� �ý��۵��� �Ѱ����� �����ϴ� �뵵
// �� ������Ʈ�� ���������� ������ ó���ϴ� ���� �ƴ� �Ŵ����� �ش� ����� �����մϴ�
// �ٸ� �������� ������ ������ �뵵�� ����˴ϴ� (������ �����͸� ����)

//��ǥ���� ����
// 1. GameManager : ���� ����, ����, ����, �� ��ȯ ���� ����
// 2. UIManager : UI â�� ���� ���� ����
// 3. SceneManager : ����Ƽ���� �������ִ� �� ����� ���� ���� �ε� , ��ȯ���� �����մϴ�


public class DialogManager : MonoBehaviour
{
    //�Ŵ����� ������(Singleton)
    //���α׷� ��ü���� �� �ϳ��� �ν��Ͻ��� �����ϵ��� �����ϴ� ������
    #region MonoSingleton (MonoBehaviour���� ��밡��)

    // 1) �ڱ��ڽſ� ���� �ν��Ͻ��� ������ (����)
    public static DialogManager Instance { get; private set; } //������Ƽ
    //instance�� ���� ���ü� �ֽ��ϴ�.(���ٰ���) ������ �� �� �����ϴ�.

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this; // �ش� �ν��Ͻ��� �ڱ� �ڽ��Դϴ�.
            DontDestroyOnLoad(gameObject);//DDOL�� �ش� ��ġ�� �ִ� ������Ʈ�� ���� �Ѿ�� �ı����� �ʰ� ���� �����Ǵ� ���� ����
        }
        else
        {
            Destroy(gameObject);
        }
    }

    #endregion

    public TextMeshProUGUI message; //TextMeshProUGUI ������ ���
    public TMP_Text character_name; //TextMeshProUGUI �� text�� ���
    public GameObject panel;
    public float typing_speed;

    //ť(Queue)
    //���Լ��� ������ ���� �Ǿ��ִ� �ڷᱸ�� (First - In First- Out) FIFO
    // ���� �־��� �����Ͱ� ���� ���ŵǴ� ��� (��ȭ, ��⿭ ���� ����� �����Ҷ� �켱������ ����Ǵ� �ڷᱸ��)
    //Ư¡)
    // Enqueue(��) : ������ �߰�
    // Dequeue() : ������� ���°� ����
    // Peek() : ���� ���� ���� �����ִ� �� Ȯ�� ����
    // Count() : ���� ť�� ��ϵ� ����� ����

    // ����
    // Queue<string> queue = new Queue<string>(); //ť����
    // queue.Enqueue("������ ��õ �޴�"); // �� �߰�
    // queue.Enqueue("�ٳ����� ����"); 
    // string data = queue.Dequeue();
    // ó�� ���� "������ ��õ �޴�"�� return �ǰ� ť ���ο��� �����˴ϴ�.

    private Queue<Dialog> queue = new Queue<Dialog>();
    private Coroutine typing;
    private bool isTyping = false;
    private Dialog current; // ������ ��ȭ����


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //�̺�Ʈ �ý��ۿ� ���޵� ���� �����ϰ�, �� ���� UI������ ������ ��Ȳ�̶��?
            if(EventSystem.current != null && EventSystem.current.IsPointerOverGameObject())
            {
                //�۾�����
                return;
            }

            //�����̽��� ���� ���������� �۾����� ���(��ȭ�Ŵ����� �ְ�, ��ȭ���� ���)
            if (isTyping)// Ÿ���� ���̶�� 
            {
                CompleteLine(); //������ ���� ��ŵ�ϴ�.
            }
            else
            {
                NextLine(); // ���� �������� �̵� �մϴ�.
            }
        }
    }

    /// <summary>
    /// List<T>�� Queue<T> ó�� ���� ������ �����͸� �� �Ű� ������ ������ �ֽ��ϴ�.
    /// </summary>
    /// <param name="lines">��ȭ �����Ϳ� ���� ������ ���� ������</param>
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
        //�۾��� ������ �� �̻� ���ٸ�
        if(queue.Count == 0)
        {
            DialogExit(); //��ȭ�� ����
            return;
        }

        //ť�� ����� ���� �ϳ� ���ɴϴ�
        current = queue.Dequeue();
        //���� ��ȭ���� ĳ���� �̸����� ����
        character_name.text = current.character; 

        if (typing != null)
        {
            StopCoroutine(typing);
        }

        //���� ��ȭ �������� ������(��ȭ ����)�� �������� ��ȭ Ÿ������ �����մϴ�.
        typing = StartCoroutine(TypingDialogue(current.content));
    }

    private void DialogExit()
    {
        panel.SetActive(false);//�г� ����
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
        isTyping = true; // Ÿ���� ���� ������ �˸�

        //System.Text.StringBuilder Ŭ������ ���ڿ��� ȿ�������� �ٷ� �� �ְ� �����ִ� Ŭ�����Դϴ� (C#å 310~321 ����)
        // ������
        // C#�� string�� �ѹ� �����Ǹ� ������ �Ұ����մϴ� (immutable object)
        //���ڿ��� ��� + ������ ����Ǹ� ���ο� ���ڿ��� �����ϴ� ����

        //StringBuilder�� ���� ���ο� �ִ� ������ ���� ���ڿ��� �����ؼ� ������ �� �ֽ��ϴ�.
        // ���
        // 1. ���ڿ� ���� Append()
        // 2. ���ڿ� + �ٹٲ� AppendLine()
        // 3. ���ϴ� ��ġ�� ���ڿ� ���� Insert()
        // 4, �ε��� �������� ���ڿ� �����ϱ� Remove()
        // 5. Ư�� ���ڸ�  �ٸ� ������ ��ü�ϱ� Replace()
        // 6. ���ڿ� ��ü ���� Clear()
        // 7. ������� ��ȯ ToStrnig()

        //���ɿ� ���� �� string������ + ���� ���� vs StringBuilder
        //�۾����� ���� ��� Builder�� ����
        //�۾����� ���� ��� string + �� ����
        //GC �߻����� Builder�� �� ���� �߻��մϴ�
        //�ǽð� ���ۿ��� : Builder�� ����ȭ �ܰ迡�� �� �����մϴ�

        StringBuilder stringBuiler = new StringBuilder(line.Length);

        message.text = ""; //���� ����

        //string(���ڿ�)�� ����(char)�� �迭
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