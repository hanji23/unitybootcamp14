using UnityEngine;

public class cameracontroller : MonoBehaviour
{

    public GameObject player;

    private Vector3 offset;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //ī�޶�� �÷��̾��� �Ÿ� ���̸� offset ������ ����
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // update() ���� ó���� �κ��� �� ó���� �� ȣ��Ǵ� ��ġ
    //ī�޶� �۾����� ���� ����(������Ʈ ������ ������ ���)
    private void LateUpdate()
    {
        //ī�޶��� ��ġ�� �÷��̾���� ���� �Ÿ��� ���� offset
        transform.position = player.transform.position + offset;
    }
}
