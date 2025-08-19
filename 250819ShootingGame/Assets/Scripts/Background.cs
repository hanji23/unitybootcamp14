using UnityEngine;

public class Background : MonoBehaviour
{
    public Material material;
    public Texture2D[] texture;

    public float scrollSpeed = 0.25f;

    int i = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        material.SetTexture("_BaseMap", texture[i]);
        material.mainTextureOffset = new Vector2(0, -0.425f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 dir = Vector2.up;
        material.mainTextureOffset += dir * scrollSpeed * Time.deltaTime;

        if (material.mainTextureOffset.y >= 0.7f)
        {
            

            

            if (i > texture.Length - 1)
            {
                i = 0;
                material.SetTexture("_BaseMap", texture[i]);

            }
            else
            {
                i++;
                material.SetTexture("_BaseMap", texture[i]);
            }
            material.mainTextureOffset = new Vector2(0, -0.425f);
        }
    }
}
