using UnityEngine;


public class cs4_BuildProfileSample : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
#if CUSTOM_DEBUG_MODE
        Debug.Log("����� ��� ���� ���� ���� ����Դϴ�!");
#elif CUSTOM_RELEASE_MODE //���� ������ �����Ѵٸ� �ش� ��ġ�� ����� ��Ȱ��ȭ ����
        Debug.Log("������ ��� ���� ���� ���� ����Դϴ�!");
#endif
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
