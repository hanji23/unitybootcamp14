using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jp;
    public LayerMask ground;
    
    private Rigidbody rb;

    //private bool isGrounded;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Ű �Է�
        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");
        
        //���� ����
        Vector3 dir = new Vector3 (x, 0, y);
        
        //�̵��ӵ� ����
        Vector3 velocity = dir * speed /* Time.deltaTime*/;

        rb.linearVelocity = new Vector3(velocity.x, rb.linearVelocity.y, velocity.z);

        //rb.linearVelocity = velocity;
        //������ �ٵ��� �Ӽ�
        //linearVelocity = ���� �ӵ�(��ü�� ���� �󿡼� �̵��ϴ� �ӵ�)
        //angularVelocity = �� �ӵ�(��ü�� ȸ���ϴ� �ӵ�)

        //���� ��� �߰�
        if (Input.GetKeyDown(KeyCode.Space) && IsGounded())
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
}
