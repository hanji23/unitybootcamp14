using UnityEngine;

//마우스 충돌시 대화 시작 기능(카메라에 연결)
public class DialogRaycaster : MonoBehaviour
{
    private Camera cam;
    public float distance = 10.0f;
    public LayerMask layerMask;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, distance, layerMask))
            {
                var trigger = hit.collider.GetComponent<Dtrigger>();

                if(trigger != null)
                {
                    trigger.OnDTriggerEnter();
                }
            }
        }    
    }
}
