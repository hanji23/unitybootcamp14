using System.Collections;
using UnityEngine;

public class CoroutineSample_2 : MonoBehaviour
{
    //������ Ÿ��
    public GameObject target;

    //��ȭ �ð�
    float duration = 5.0f;

    //�ٲٰ� ���� ��
    public Color color;

    Coroutine coroutine;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Ÿ���� ���� �Ǿ� �ִٸ�
        if(target != null)
        {
            StartCoroutine(ChangeColor());

            //StartCoroutine(�޼ҵ��()); IEnumerator ������ �޼ҵ带 �ڷ�ƾ���� �����մϴ�
            //�ڵ� �ۼ� �������� �޼ҵ尡 �����Ǿ� ������
            //�޼ҵ� ȣ���� ������ �������� Ȯ�εǱ⿡ ã�� �����ϴ� �ð��� ���ڿ����� ���� ��ϴ�

            //StartCoroutine("ChangeColor");
            //StartCoroutine("�޼ҵ��"); ���ڿ��� ���� �Ű������� ���� �ڷ�ƾ�� ȣ���� �� �ֽ��ϴ�
            //���������� �޼ҵ��� �̸��� ���ڿ��� �����ϰ�, ��Ÿ�ӿ��� ã�Ƽ� �����ϴ� ���(���÷���)
            //Ÿ�� üũ�� ���� �ʾƼ� �߸��� �̸��� ���� ��Ÿ�� ������ �߻�

            //coroutine = StartCoroutine(ChangeColor());
            //StopCoroutine(coroutine);
            //StopCoroutine("coroutine");
            //StopAllCoroutines(); (���� ���� ������Ʈ���� ��������) ��� �ڷ�ƾ�� ���� ���� 
        }
        else
        {
            Debug.LogWarning("���� Ÿ���� ��ϵ��� ���� �����Դϴ�");
        }
    }

    IEnumerator ChangeColor()
    {
        //Ÿ������ ���� ������ ������Ʈ�� ���� ���� ���ɴϴ�
        var targetRenderer = target.GetComponent<Renderer>();

        //������ Ÿ���� �������� ���� ���
        if (targetRenderer == null)
        {
            Debug.Log("�������� ������ ���߽��ϴ� null");
            //�۾��ߴ�
            yield break;
        }

        //�� ��ġ�� �ڵ�� ���������� �������� ���� ��� ����Ǵ� ��ġ

        float time = 0;
        //Ÿ���� �������� ���� ��Ƽ������ ������ ������
        var start = targetRenderer.material.color;
        var end = color;

        //�ݺ��۾�
        //�ڷ�ƾ ������ �ݺ����� �����ϸ� yield�� ���� ���������ٰ� �ٽ� ���ƿͼ� �ݺ����� �����ϰ� �˴ϴ�
        while (time < duration) // ��ȭ �ð� ��ŭ
        { 
            time += Time.deltaTime;
            var value = Mathf.PingPong(time, duration) / duration;
            //Mathf.PingPong(a, b) �־��� ���� a�� b���̿��� �ݺ��Ǵ� ���� �����մϴ�(�⺻���� �պ��)
            //�� 0���� 1������ ��ȭ���� ��� �˴ϴ�
            //����ȭ �۾��� ������ ���� : color�� 0���� 1������ ��

            targetRenderer.material.color = Color.Lerp(start, end, value);
            //���� ���� �ε巯�� ����

            yield return null;
            //yield return new WaitForSeconds(0.5f);
            Debug.Log("�������� ��!");
        }
    }

    //�ڷ�ƾ ���� ���
    //StopCoroutine(�ڷ�ƾ ��ü);
    //StopCoroutine(coroutine);
    //StopCoroutine("coroutine");
    //StopAllCoroutines(); (���� ���� ������Ʈ���� ��������) ��� �ڷ�ƾ�� ���� ���� 

    // Update is called once per frame
    void Update()
    {
        
    }
}
