using UnityEngine;

//에디터에서 해당 오브젝트 생성 가능
[CreateAssetMenu(fileName = "퀴즈", menuName = "Item/퀴즈")]
public class SOmaker : ScriptableObject
{
    public int level = 0;

    public string[] Q = { "1 + 1 = ?" , "2 + 2 = ?", "3 + 3 = ?", "4 + 4 = ?", "5 + 5 = ?" };

    public int[] A = { 2, 4, 6, 8, 10 };

}
