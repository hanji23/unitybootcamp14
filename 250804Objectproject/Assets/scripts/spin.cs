using UnityEngine;

public class spin : MonoBehaviour
{
    public Transform pivot;
    public float speed = 1000f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pivot = transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Z))
            transform.RotateAround(pivot.position, Vector3.forward, speed /* * Time.deltaTime*/);
    }
}
