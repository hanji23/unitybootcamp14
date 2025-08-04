using System.Collections;
using UnityEngine;

public class IEnumeratorSample_1 : MonoBehaviour
{
    class CustomCollection : IEnumerable
    {
        int[] numbers = { 6, 7, 8, 9, 10 };

        //GetEnumerator�� ���� ��ȸ������ �����͸� IEnumerator ������ ��ü�� ��ȯ
        public IEnumerator GetEnumerator()
        {
            for(int i =0; i < numbers.Length; i++)
            {
                yield return numbers[i];
            }
        }
    }

    int[] numbers = { 1, 2, 3, 4, 5 };

    void Start()
    {
        //numbers ��� �迭�� ��ȸ�Ҽ� �ִ� IEnumerator ������ �����ͷ� ��ȯ �մϴ�
        IEnumerator enumerator = numbers.GetEnumerator();

        while (enumerator.MoveNext())
        {
            Debug.Log(enumerator.Current);
        }

        CustomCollection collection = new CustomCollection(); //Ŀ���� Ŀ���� ����

        //foreach�� ��ȯ������ �����͸� ���������� �۾��Ҷ� ����ϴ� for�������� ���Ⱑ ���������ϴ�
        foreach (int number in collection)
        {
            Debug.Log(number);
        }

        foreach (var message in GetMessage())
        {
            Debug.Log(message);
        }
    }

    //yield�� C#���� �ѹ��� �ϳ� �� ���� �ѱ�� �޼ҵ尡 �Ͻ� �����Ǹ� �ļ� ������ ���������� ��ȯ�ϰ� �˴ϴ�
    //(�ݺ����� �۾�, �������� ������ ó���� ���˴ϴ�)

    //yield�� yield return, yield break�� ���˴ϴ�
    //yield return�� �޼ҵ尡 ���� ��ȯ�ϸ鼭 �� �������� �޼ҵ� ������ �Ͻ� ���� ��ŵ�ϴ�
    //ȣ���ڰ� ���� ���� �䱸 �Ҷ� ���� ����մϴ�.
    //yield break�� �޼ҵ忡���� �ݺ��� �����ϴ� �ڵ� �Դϴ�.(���� ����)

    //yield return�� ����ϴ� �޼ҵ�� IEnumerable �Ǵ� IEnumerator �������̽��� �����ϰ� �˴ϴ�
    //�÷����� �ڵ����� ��ȸ�ϴ� foreach�� ���� ���˴ϴ�

    // ���� : ���� �ʿ�� �� �� ���� ����� �̷�� ���(�޸� ȿ���� ����, ū�����͸� ó�� �Ҷ� ������ Ů�ϴ�)
    // -> ��� �����͸� �����ϴ°� �ƴ� �ʿ��� �κи� ó�� �Ҽ� �ְ� �Ǳ� ����

    //IEnumerable : �ݺ� ������ �÷����� ��Ÿ���� �������̽��Դϴ�.
    //  �� ����� ������ ũ������ �ݺ��� �� �ִ� ��ü�� �Ǹ� foreach ��� �������� Ž���� ���� �Ҽ� �ְ� �˴ϴ�.
    //  �ش� �������̽��� �����ϱ� ���ؼ��� GetEnumerator() �޼ҵ带 �����ϰ�, ����ڰ� �����ؾ��մϴ�.

    //IEnumerator : �ݺ��� �����ϴ� �������̽� �Դϴ�.
    //  �÷��ǿ��� �ϳ��� �׸��� ��ȯ�ϰ�, �� ���¸� �����ϴ� ������ �����մϴ�
    //  MoveNext()�� ���ؼ� ���� ���� ���� Current�� ���� ���簪 Ȯ�� Reset()�� ���ؼ� ���� ��� ó��

    static IEnumerable GetMessage()
    {
        Debug.Log("�޼ҵ� ����");
        yield return "��";
        Debug.Log("Ż�� �ߴٰ� ���ƿ�1");
        yield return "ȣ";
        Debug.Log("Ż�� �ߴٰ� ���ƿ�2");
        yield break; //�ݺ� ��ȯ ����

        // -- unreachable code -- (���ٺҰ� ��)
        Debug.Log("Ż�� �ߴٰ� ���ƿ�3");
        yield return "!!!";
    }
}
