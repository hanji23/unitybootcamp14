using UnityEngine;

public class cs5_1_ItemTester : MonoBehaviour
{
    public cs5_SOMaker somaker;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log(somaker.description);
    }

    public void LevelUp()
    {
        somaker.level++;
        Debug.Log("level up!");
    }
}
