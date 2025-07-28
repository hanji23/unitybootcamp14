using UnityEngine;

public class SphericaInter : MonoBehaviour
{
    //Leap 와 Glerp가 사용되는 경우
    //1. 단순한 위치 이동 -> Leap
    //2. 회전 및 방향 전환 -> Sleap (Vector3.Sleap, Quaternion.Slerp)
    //3. 자연스러운 카메라의 움직임 -> Sleap

    //요약 
    //Leap : 직선이동
    //체력 게이지 등이 일정하게 변화하는 경우
    //Sleap : 회전이나 각도의 개념이 필요한 경우
    //3D 회전(쿼터니언) / 벡터 간의 곡선 경로 확인 / 방향 회전이 부드럽게 대상 방향을 바라봐야 할 경우

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
            transform.position = Vector3.Slerp(start_position, target.position, t);
        }
    }
}