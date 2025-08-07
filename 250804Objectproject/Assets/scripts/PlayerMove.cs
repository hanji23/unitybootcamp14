using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Rigidbody))]
public class PlayerMove : MonoBehaviour
{
    public int hp = 5;
    public float speed;
    public float jp;
    public LayerMask ground;
    public Text text;

    private Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        text.text = $"hp : {hp}";
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");

        //���� ����
        Vector3 dir = new Vector3(x, 0, y);

        //�̵��ӵ� ����
        Vector3 velocity = dir * speed /* Time.deltaTime*/;

        rb.linearVelocity = new Vector3(velocity.x, rb.linearVelocity.y, velocity.z);

        if (Input.GetKeyDown(KeyCode.X) && IsGounded())
        {
            rb.AddForce(Vector3.up * jp, ForceMode.Impulse);
            //ForceMode.Impulse : �������� ��
            //ForceMode.Force : �������� ��
        }
    }

    private bool IsGounded()
    {
        //�Ʒ� �������� 1��ŭ ���̸� ���� ���̾� üũ
        return Physics.Raycast(transform.position, Vector3.down, 1.0f, ground);
    }

    private void OnTriggerEnter(Collider other)
    {
        //�ε��� ����� Enemy �±׸� ������ �ִ� ������Ʈ�� ���
        if (other.tag == "Enemy")
        {
            hp -= 1;
            text.text = $"hp : {hp}";
            if (hp <= 0)
                Debug.Log("����!");
            Destroy(other.gameObject);
        }

    }
}
