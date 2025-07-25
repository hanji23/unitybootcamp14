using UnityEngine;

public class cameracontroller : MonoBehaviour
{

    public GameObject player;

    private Vector3 offset;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //카메라와 플레이어의 거리 차이를 offset 값으로 설정
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // update() 에서 처리할 부분을 다 처리한 후 호출되는 위치
    //카메라 작업에서 많이 사용됨(오브젝트 추적이 목적인 경우)
    private void LateUpdate()
    {
        //카메라의 위치는 플레이어와의 일정 거리를 유지 offset
        transform.position = player.transform.position + offset;
    }
}
