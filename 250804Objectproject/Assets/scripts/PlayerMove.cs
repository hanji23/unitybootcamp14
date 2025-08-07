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

        //방향 설계
        Vector3 dir = new Vector3(x, 0, y);

        //이동속도 설정
        Vector3 velocity = dir * speed /* Time.deltaTime*/;

        rb.linearVelocity = new Vector3(velocity.x, rb.linearVelocity.y, velocity.z);

        if (Input.GetKeyDown(KeyCode.X) && IsGounded())
        {
            rb.AddForce(Vector3.up * jp, ForceMode.Impulse);
            //ForceMode.Impulse : 순간적인 힘
            //ForceMode.Force : 지속적인 힘
        }
    }

    private bool IsGounded()
    {
        //아래 방향으러 1만큼 레이를 쏴서 레이어 체크
        return Physics.Raycast(transform.position, Vector3.down, 1.0f, ground);
    }

    private void OnTriggerEnter(Collider other)
    {
        //부딪힌 대상이 Enemy 태그를 가지고 있는 오브젝트일 경우
        if (other.tag == "Enemy")
        {
            hp -= 1;
            text.text = $"hp : {hp}";
            if (hp <= 0)
                Debug.Log("죽음!");
            Destroy(other.gameObject);
        }

    }
}
