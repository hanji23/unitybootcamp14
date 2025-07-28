using UnityEngine;

public class vectortest1 : MonoBehaviour
{
    // 게임오브젝트의 transform을 통해 vector 값 구하기
    public Transform A_cube;
    public Transform B_cube;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //현재 큐브의 위치를 벡터로 설정
        Vector3 posA = A_cube.position;
        Vector3 posB = B_cube.position;

        //두 벡터의 차 -> 방향 벡터
        Vector3 BtoA = posB - posA;
        Vector3 AtoB = posA - posB;

        //거리 측정
        //Distance의 수학적 로직
        // a = (ax, ay, az), b = (bx, by, bz) 라고 할때
        // 두 벡터 사이의 거리는 각 축에 대한 차의 제곱의 합에 대한 루트 값
        // -> √{(bx - ax)^2 + (by - ay)^2 + (bz - az)^2}

        // 유니티의 Mathf 클래스를 기반으로 바꾸면?
        Vector3 dif = posB - posA;
        float distance = Mathf.Sqrt(dif.x * dif.x + dif.y * dif.y + dif.z * dif.z);
        Debug.Log("Mathf : " + distance);

        // 벡터 Distance 이용
        distance = Vector3.Distance(posA, posB);
        Debug.Log("Distance" + distance);


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
