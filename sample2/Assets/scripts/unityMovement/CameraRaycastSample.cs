using UnityEngine;
//ī�޶� �������� ���콺 Ŭ�� ��ġ�� �����ɽ�Ʈ ó��

public class CameraRaycastSample : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Ray ray = new Ray(��ġ, ����);

        if (Input.GetMouseButton(0))
        {
            //ī�޶󿡼� ����� ���̸� ���� ����
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("�� ���� : �����");
                hit.collider.GetComponent<Renderer>().material.color = Color.yellow;
                //�浹ü ������Ʈ�� ���� ����
                var hitObject = hit.collider.gameObject;

                int change_layer = LayerMask.NameToLayer("Yellow");

                //���̾ ��ȿ�� ���� ���
                if (change_layer != -1)
                {
                    hitObject.layer = change_layer;
                }
            }
        }
    }
}