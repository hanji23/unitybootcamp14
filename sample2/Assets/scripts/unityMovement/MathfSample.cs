using UnityEngine;
//�߿� Ŭ���� Mathf
//����Ƽ���� ���� �������� �����Ǵ� ����Ƽ Ŭ����
//���� ���߿��� ���ɼ� �ִ� ���� ���꿡 ���� �����޼ҵ� �� ����� �����մϴ�

//ex)���� �޼ҵ� : static Ű����� ������ �ش� �޼ҵ�� Ŭ������, �޼ҵ��()���� ����� �����մϴ�. Mathf.Abs(-5);

public class MathfSample : MonoBehaviour
{
    //�⺻������ ���Ǵ� �޼ҵ�
    float abs = -5;
    float ceil = 4.1f;
    float floor = 4.6f;
    float round = 4.5f;
    float clamp;
    float clamp01;
    float pow = 2;
    float sqrt = 4;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log($"Mathf.Abs(abs) <- {abs}");      //����(absolute number)
        Debug.Log($"Mathf.Ceil(ceil) <- {ceil}");    //�ø�(�Ҽ����� ������� �ø�ó��)
        Debug.Log($"Mathf.Floor(floor) <- {floor}");  //����(�Ҽ����� ������� ����ó��)
        Debug.Log($"Mathf.Round(round) <- {round}");  //�ݿø�(����Ƽ���� 5���ϸ� ������ 6�̻��̸� �ø�ó��)
        //�ڿ� ToInt�� �ٿ� ������ �ٲٱ� ���� ex)RoundToInt

        Debug.Log($"Mathf.Clamp(7, 0, 4) <- 7, 0, 4");//���� ���� ���� �� = 7, �ּ� = 0, �ִ� = 4, ���               -> 4, ��, �ּ�, �ִ� ������ ���� �Է��մϴ�
        Debug.Log($"Mathf.Clamp01(5) <- 5");    //���� ���� ���� �� = 5, �ּҿ� �ִ밡 ���� 0�� 1�� �ڵ� ������ -> ����� �ּڰ� 0 �Ǵ� �ִ� 1�� ó��
        //�ۼ�Ʈ ������ ���� ó���Ҷ� ���� ���Ǵ� �ڵ�
        //�ּ� �ִ� ������ ���� 0�� 1�� �����˴ϴ�
        //Clamp vs Clamp01
        //Clamp     => ü��, ����, �ӵ� ���� �ɷ�ġ ���信���� ��������
        //Clamp01   => ����(�ۼ�Ʈ), ���� ��(t), ���İ�(����)

        Debug.Log($"{Mathf.Pow(pow, 2)} <- {pow}���� ");       //��, ������(����)�� ���� �޾Ƽ� �ش���� �ŵ� ������ ���( pow^2, pow��)
        Debug.Log($"{Mathf.Pow(pow, 0.5f)} <- {pow} ������");  //Mathf.Sqrt()�� ����ϴ°ͺ��� ������ �ſ� ����
        Debug.Log($"{Mathf.Pow(pow, -2)} " +          //2�� -2���� -> 1/4
            $"������ ������ ��� ���� ���� ���·� ���");   
        Debug.Log($"{Mathf.Sqrt(sqrt)} <- {sqrt}");    //���� ���� �޾� �ش� ���� �������� ���
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
