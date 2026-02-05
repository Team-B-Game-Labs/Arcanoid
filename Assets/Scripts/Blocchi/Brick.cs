using System;
using UnityEngine;

public class Brick : MonoBehaviour
{
    enum BrickType
    {
        Gray,
        White,
        Green,
        Blue,
        Rose,
        Black,
        Brown,
        Burgundy

    }

    public static event Action OnBrickDestroyed;

    [SerializeField] BrickType types;


    [SerializeField] protected int health = 1;


    [SerializeField] protected Color brikColor = Color.white;

    private int texturIndex = 0;

    [SerializeField] Texture[] brokenTexture = new Texture[1];
    Material material;

    private void Start()
    {
        material = GetComponent<Renderer>().material;
        material.mainTexture = null;

        //Linea codice per swippare
        //material.mainTexture = brokenTexture[textureIndexx]
        //texture indez++
    }


    protected void Effect()
    {

    }

    protected void EventAction_OnBrickDestroyed()
    {
        OnBrickDestroyed?.Invoke();
    }
}
