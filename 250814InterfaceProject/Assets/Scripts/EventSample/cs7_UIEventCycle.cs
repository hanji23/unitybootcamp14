using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;

public class cs7_UIEventCycle : MonoBehaviour,
    IPointerEnterHandler, IPointerExitHandler,
    IPointerDownHandler, IPointerUpHandler, IPointerClickHandler,     //������ ����

    IBeginDragHandler, IDragHandler, IEndDragHandler,                  // �巡�� ����

    ISelectHandler, IDeselectHandler, ISubmitHandler, ICancelHandler, // ���� ���

    IScrollHandler,                                                   //��ũ��
    IUpdateSelectedHandler,                                           // ���� ���¿����� �� �����ӿ� ���� �۾�
    IMoveHandler                                                      //Ű���峪 ���̽�ƽ ����
{
    //�ʵ�
    private int eventCount = 0;
    private float lastEventTime = 0.0f;

    //�̺�Ʈ ó���� �Լ�
    //BaseEventData�� �̺�Ʈ �ý��� ���� ���Ǵ� �̺�Ʈ �����Ϳ� ���� ���� Ŭ����
    private void Handle(string eventName, BaseEventData eventData)
    {
        eventCount++;//ī��Ʈ ����
        float now = Time.time;//�ð�üũ
        float delta = now - lastEventTime; //������ �̺�Ʈ���� �ð� ������ ����մϴ�
        lastEventTime = now;

        string pos = ""; // ���� ���� PointerEventData�� ��� ��ǥ�� ���� ���ó��


        //C# ���� ��Ī
        // 1. eventData is PointerEventData -> ��ü�� PointerEventData���� Ȯ��
        // 2. ������ PointerData�� ��ȯ �ؼ� ���������� �����Ѵ�
        if (eventData is PointerEventData pointerData)
        {
            pos = $"pos : {pointerData.position}";
        }

        StringBuilder sb = new StringBuilder();

        sb.Append($"eventCount : <color=yellow> {eventCount} </color>, ");//�̺�Ʈ Ƚ��
        sb.Append($"eventName : <b> {eventName} </b>, "); // �̺�Ʈ��
        sb.Append($"<color=cyan> {pos} </color>, "); // ��ǥ
        sb.Append($"delta : <color=blue> {delta:F3} </color>"); // �̺�Ʈ�ð�
        //���� ǥ�� ����
        // F3 : Fixed-ponit(�Ҽ��� ����) ���·� �Ҽ��� ���� 3�ڸ� ���� ǥ���Ͻÿ�
        // N2 : number�� ���� ���� 1,234.57
        // D5 : Decimal(����)�� ���� ���� 01234
        // P1 : �ۼ�Ʈ�� ���� ��� (�� * 100 ���� %�� ���δ�) {0.34 : P1} -> 34%

        Debug.Log(sb.ToString());
    }
    private void OnEnable()
    {
        eventCount = 0;
        lastEventTime = Time.time;
    }

    //�ش� �̺�Ʈ�� �߻��Ҷ����� handle�� ����˴ϴ�
    //���������� ��ȯŸ�� �Լ���(�Ű�����) => ���డ��;

    //ex)��
    public void OnBeginDrag(PointerEventData eventData) => Handle("OnBeginDrag", eventData);

    public void OnCancel(BaseEventData eventData) => Handle("OnCancel", eventData);

    public void OnDeselect(BaseEventData eventData) => Handle("OnDeselect", eventData);

    public void OnDrag(PointerEventData eventData) => Handle("OnDrag", eventData);

    public void OnEndDrag(PointerEventData eventData) => Handle("OnEndDrag", eventData);

    public void OnMove(AxisEventData eventData) => Handle("OnMove", eventData);

    public void OnPointerClick(PointerEventData eventData) => Handle("OnPointerClick", eventData);

    public void OnPointerDown(PointerEventData eventData) => Handle("OnPointerDown", eventData);

    public void OnPointerEnter(PointerEventData eventData) => Handle("OnPointerEnter", eventData);

    public void OnPointerExit(PointerEventData eventData) => Handle("OnPointerExit", eventData);

    public void OnPointerUp(PointerEventData eventData) => Handle("OnPointerUp", eventData);

    public void OnScroll(PointerEventData eventData) => Handle("OnScroll", eventData);

    public void OnSelect(BaseEventData eventData) => Handle("OnSelect", eventData);

    public void OnSubmit(BaseEventData eventData) => Handle("OnSubmit", eventData);

    public void OnUpdateSelected(BaseEventData eventData) => Handle("OnUpdateSelected", eventData);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}