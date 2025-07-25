using UnityEngine;

public enum TYPE3
{
    Perspective, Orthographic
}

public enum TYPE4
{
    Vertical, Horizontal
}

public class sample2 : MonoBehaviour
{
    public TYPE3 projection;
    public TYPE4 Field_of_View_Axis;
    public int Field_of_View;
    public float /*Clipping_Planes_*/Near;
    public float Far;
    public bool Physical_Camera;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
