using UnityEngine;
//삼각함수 
//유니티에서 제공해주는 삼각함수는 주로 회전, 카메라 제어, 곡선, 움직임에 대한 표현으로 사용됩니다.
//특징) 단위를 라디안으로 사용합니다. 1라디안 = 약 57도

public class Tfunction : MonoBehaviour
{
    //요약
    //Sin(Radian) : 주어진 좌표의 y좌표 (세로방향)
    //Cos(Radian) : 주어진 좌표의 x좌표 (가로방향)
    //Tan(Radian) : 주어진 좌표의 기울기 ( Y / X )

    //원형회전
    public void CircleRotate()
    {
        float angle = Time.time * 90f;
        float radian = angle * Mathf.Deg2Rad; // 도에 해당값을 곱해주면 라디안으로 변환됩니다.
        
        // var - 자동 타입 뒤에 적힌 타입에 따라 자동으로 적용
        var x = Mathf.Cos(radian) * 5.0f; 
        var y = Mathf.Sin(radian) * 5.0f;

        transform.position = new Vector3(x, y, 0);
    }

    //time.time : 프레임이 시작한 순간부터의 시간
    //Time.deltatime : 프레임이 시작하고 끝나는 시간

    public void Wave()
    {
        var offset = Mathf.Sin(Time.time * 2.0f) * 0.5f;
        transform.position = pos + Vector3.up *offset;
    }

    public void Butterfly()
    {
        float t = Time.time * 2;
        float x = Mathf.Sin(t) * 2;
        float y = Mathf.Sin(t * 2f) * 2 * 2;

        transform.position = new Vector3(x, y, 0);
    }

    Vector3 pos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pos = transform.position; // 시작할때 오브젝트 위치 매핑   
    }

    // Update is called once per frame
    void Update()
    {
        //마우스 왼쪽클릭 유지동안 CircleRotate 호출
        if (Input.GetMouseButton(0))
        {
            CircleRotate();
        }
        if (Input.GetMouseButton(1))
        {
            Wave();
        }
        if (Input.GetMouseButton(2))
        {
            Butterfly();
        }
    }
}
