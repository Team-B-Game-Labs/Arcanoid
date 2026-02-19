using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    public float scrollSpeed = 0.5f;
    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    { 
        float offset = Time.time * scrollSpeed;


        rend.material.mainTextureOffset = new Vector2(offset, offset-0.03f);
    }
}


