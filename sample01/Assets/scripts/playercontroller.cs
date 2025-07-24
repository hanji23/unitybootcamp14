using UnityEngine;

public class playercontroller : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        speed = 1000;
        rb = GetComponent<Rigidbody>();
        //GetComponent<T>(); -> ���� ������Ʈ�� �پ��ִ� ������Ʈ�� �������� ��� 
        // T �̸� =  GetComponent<T>(); T : type

        Debug.Log("������ �Ϸ�Ǿ����ϴ�.");
    }

    // Update is called once per frame
    void Update()
    {
        //speed += 1;
        //Debug.Log($"�ӵ��� 1�����մϴ�. ���� �ӵ���{speed}�Դϴ�.");

        //�����̵�
        float h = Input.GetAxis("Horizontal");
        //�����̵�
        float v = Input.GetAxis("Vertical");
        //�̵���ǥ(����) ����
        Vector3 movement = new Vector3(h, 0, v);

        rb.AddForce(movement * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (/*other.gameObject.tag == "itembox"*/other.gameObject.CompareTag("itembox"))
        {
            other.gameObject.SetActive(false);
            Debug.Log("������ ȹ��!");
            speed += 100;
        }

        if (other.gameObject.CompareTag("obstacle"))
        {
            other.gameObject.SetActive(false);
            Debug.Log("�ӵ� 100 ����!");
            speed -= 100;
        }
    }
}
