using UnityEngine;

// ������ ��� ���¿��� Update, OnEnable, OnDisable�� ������ �����Ҽ� �ֽ��ϴ�.
//Play�� ������ �ʾƵ� Editor ������ update � ������ ��ɵ��� �����غ��� �ֽ��ϴ�
//[ExecuteInEditMode]

public class EditMenuSample : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //�����Ϳ����� �����غ��� �ڵ�
        if (!Application.isPlaying)
        {
            Vector3 pos = transform.position;
            pos.y = 0;
            transform.position = pos;

            Debug.Log("Editor Test...(�� ��ũ��Ʈ�� �� ������Ʈ�� y���� 0���� �����˴ϴ�)");
        }
    }
}
