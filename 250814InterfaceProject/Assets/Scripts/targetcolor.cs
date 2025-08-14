using UnityEngine;

public class targetcolor : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void colorstart()
    {
        Invoke("returncolor", 0.5f);
    }

    void returncolor()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }
}
