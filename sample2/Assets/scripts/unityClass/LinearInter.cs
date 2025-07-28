using UnityEngine;

public class LinearInter : MonoBehaviour
{
    //Vector3.Lerp(start, end, t);
    //start -> end 까지 t에 따라 선형 보간 합니다.
    // -> 해당 방향으로 일정 간격 천천히 이동하는 코드
    //t의 범위는 (0 ~ 1)이고 float

    public Transform target;
    public float speed = 1.0f;

    private Vector3 start_position;
    private float t = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        start_position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (t < 1.0f)
        {
            t += Time.deltaTime * speed;
            transform.position = Vector3.Lerp(start_position, target.position, t);
        }
    }
}