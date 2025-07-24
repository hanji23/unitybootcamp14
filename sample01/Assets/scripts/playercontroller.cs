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
        //GetComponent<T>(); -> 게임 오브젝트에 붙어있는 컴포넌트를 가져오는 기능 
        // T 이름 =  GetComponent<T>(); T : type

        Debug.Log("설정이 완료되었습니다.");
    }

    // Update is called once per frame
    void Update()
    {
        //speed += 1;
        //Debug.Log($"속도가 1증가합니다. 현재 속도는{speed}입니다.");

        //수평이동
        float h = Input.GetAxis("Horizontal");
        //수직이동
        float v = Input.GetAxis("Vertical");
        //이동좌표(벡터) 설정
        Vector3 movement = new Vector3(h, 0, v);

        rb.AddForce(movement * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (/*other.gameObject.tag == "itembox"*/other.gameObject.CompareTag("itembox"))
        {
            other.gameObject.SetActive(false);
            Debug.Log("아이템 획득!");
            speed += 100;
        }

        if (other.gameObject.CompareTag("obstacle"))
        {
            other.gameObject.SetActive(false);
            Debug.Log("속도 100 감소!");
            speed -= 100;
        }
    }
}
