using UnityEngine;

public class BackgroundGames : MonoBehaviour
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


        rend.material.mainTextureOffset = new Vector2(offset, offset - Random.Range(1, 2));
    }
}
