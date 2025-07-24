using UnityEngine;

public class boxrotate : MonoBehaviour
{
    public Vector3 pos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(pos * Time.deltaTime);
        //Time.deltaTime은 이전 프레임부터 현재 프레임까지 걸린 시간
        //update에서의 보정값으로 활용

        //transform.Rotate(pos);
        //해당 좌표만큼 게임 오브젝트를 회전
    }
}
