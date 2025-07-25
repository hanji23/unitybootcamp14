using UnityEngine;

public class objectcontroller : MonoBehaviour
{
    public GameObject player, score;
    float speed = 0.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("mini simple skeleton demo");
        score = GameObject.Find("score");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, -speed * Time.deltaTime, 0);

        if (transform.position.y < -2)
        {
            score.GetComponent<scoresc>().timeint += 1;
            Destroy(gameObject);
        }

        if (score.GetComponent<scoresc>().timeint > 20 && speed == 0.5f)
        {
            speed += 0.5f;
        }

        //충돌판정처리
        //원에 의한 충돌 판정 로직 사용
        Vector3 v1 = transform.position;
        Vector3 v2 = player.transform.position;

        Vector3 dir = v1 - v2;
        float d = dir.magnitude;//벡터의 크기 또는 길이를 의미 (두점 사이의 거리를 계산할때 사용)

        float obj_r1 = 0.5f;
        float obj_r2 = 1;

        //두값 사이의 거리인 d의 값이 설정한 지점들의 합 보다 크다면 충돌하지 않은 상황
        if (d < obj_r1 + obj_r2)
        {
            Destroy (gameObject);
        }
    }
}
