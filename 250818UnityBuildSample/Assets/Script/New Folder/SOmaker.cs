using UnityEngine;

//�����Ϳ��� �ش� ������Ʈ ���� ����
[CreateAssetMenu(fileName = "����", menuName = "Item/����")]
public class SOmaker : ScriptableObject
{
    public int level = 0;

    public string[] Q = { "1 + 1 = ?" , "2 + 2 = ?", "3 + 3 = ?", "4 + 4 = ?", "5 + 5 = ?" };

    public int[] A = { 2, 4, 6, 8, 10 };

}
