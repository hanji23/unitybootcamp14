using UnityEngine;
//카메라 기준으로 마우스 클릭 위치에 레이케스트 처리

public class CameraRaycastSample : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Ray ray = new Ray(위치, 방향);

        if (Input.GetMouseButton(0))
        {
            //카메라에서 사용할 레이를 따로 설정
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("색 변경 : 노란색");
                hit.collider.GetComponent<Renderer>().material.color = Color.yellow;
                //충돌체 오브젝트에 대한 정보
                var hitObject = hit.collider.gameObject;

                int change_layer = LayerMask.NameToLayer("Yellow");

                //레이어가 유효한 값일 경우
                if (change_layer != -1)
                {
                    hitObject.layer = change_layer;
                }
            }
        }
    }
}