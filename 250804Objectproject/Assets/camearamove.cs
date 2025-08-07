using UnityEngine;

public class camearamove : MonoBehaviour
{

    public GameObject p;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        if (p != null) 
        { 
            transform.position = new Vector3(p.transform.position.x, transform.position.y, p.transform.position.z); 
        }
    }
}
