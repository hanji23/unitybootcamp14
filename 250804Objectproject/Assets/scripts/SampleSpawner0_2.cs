using UnityEngine;

public class SampleSpawner0_2 : MonoBehaviour
{
    // �ش� ������Ʈ�� ������ ������Ʈ�� �����ϰ� ������Ʈ�� �ο��ϱ�
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject sample = GameObject.Find("Sample");

        if (sample == null)
        {
            GameObject go = new GameObject("Sample");
            go.AddComponent<Sample_0_1>();
        }
        else
        {
            Debug.Log("�̹� �����մϴ�.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
