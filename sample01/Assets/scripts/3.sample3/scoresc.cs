using UnityEngine;
using UnityEngine.UI;

public class scoresc : MonoBehaviour
{
    public Text t;
    float time = 0f;
    public int timeint = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        timeint = (int)time;
        t.text = string.Format($"score : {timeint }");
    }
}
