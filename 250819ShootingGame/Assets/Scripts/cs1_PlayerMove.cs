using UnityEngine;

public class cs1_PlayerMove : MonoBehaviour
{
    public float speed = 5;
    float h, v;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3 (h, v, 0);

        transform.position += dir * speed * Time.deltaTime;
    }
}
