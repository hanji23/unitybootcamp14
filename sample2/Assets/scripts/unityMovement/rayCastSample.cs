using UnityEngine;
//RayCast : 시작위치에서 특정 방향으로 광선을 쐇을때 부딪히는 오브젝트가 있는지를 판단합니다.
//1)특정 오브젝트를 충돌범위에서 제외하는 작업가능
//2)특정 오브젝트에 대한 충돌판정을 확인하는 용도

public class rayCastSample : MonoBehaviour
{
    RaycastHit hit; // 충돌방지용 변수
    int ignorlayer;
    int layerMask;

    //ref -> 변수를 참조 전달, 변수가 메소드 안에서 변경 될수 있음을 알리는 용도
    //out -> 변수를 참조 전달, 변수 전달 전에 변수에 대한 초기화를 진행 할 필요가 없음
    //Physics.RayCast(Vector3 origin, Vector3 direction, out RayCastHit hitInfo, float maxDiswtance, int LayerMask);
    //origin 방향에서 direction 방향으로 maxDiswtance 길이의 광선을 발사합니다
    //hitInfo는 충돌체에 대한 정보를 의미, 충돌체 정보가 필요 없으면 제외 가능(오버로드)

    const float lenghth = 20f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //레이어 마스크 설정
        //1. 충돌 시키고 싶지않은 레이어에 대한 변수 설정
        ignorlayer = LayerMask.NameToLayer("red");// 충돌 시키고 싶지 않은 레이어
        //2. ~(1 << LayerMask.NameToLayer("red")) 해당 레이어 이외의 값
        layerMask = ~(1 << ignorlayer);

        //ex) 만약 red레이어와 blue 레이어를 둘다 제외하고 싶은 경우
        //int ignorlayers = (1 << LayerMask.NameToLayer("red")) | (1 << LayerMask.NameToLayer("blue"));
        //int layerMasks = ~ignorlayer;

        //한번에 여러개의 레이캐스트 충돌 처리
        //충돌체 설정(묶음)
        RaycastHit[] hits;
        hits = Physics.RaycastAll(transform.position, transform.forward, lenghth, layerMask);
        //RaycastAll : 한방향으로 쏜 레이가 충돌한 충돌체를 배열로 return

        //반복문으로 콜라이더 체크
        for (int i = 0; i < hits.Length; i++)
        {
            Debug.Log("레이저 발사! 충돌 물체 : " + hits[i].collider.name);
            //hits배열의 i번째 값의 충돌체가 가진 게임 오브젝트를 비활성화 합니다.
            hits[i].collider.gameObject.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        //마우스 왼쪽 버튼 클릭시 레이 발사
        //if (Input.GetMouseButtonDown(0))
        //{
        //if (Physics.Raycast(transform.position, transform.forward, out hit, lenghth, layerMask))
        //{
        //    Debug.Log("레이저 발사! 충돌 물체 : " + hit.collider.name);
        //    hit.collider.gameObject.SetActive(false);
        //}

        //레이어마스크는 비트 마스크이며, 각 비트는 하나의 레이어를 의미합니다. ~에 의해 작성된 ~(1<<n)은 해당 레이어를 제외한 모든 레이어를 의미합니다

        //오브젝트의 위치에서 정면으로 length만큼의 길이에 해당하는 디버깅 광선을 쏘는 코드
        //주로 레이캐스트 작업에서 레이가 안보이기 때문에 보여주는 용도로 사용합니다.
        Debug.DrawRay(transform.position, transform.forward * lenghth, Color.red);
        //}
    }
}
