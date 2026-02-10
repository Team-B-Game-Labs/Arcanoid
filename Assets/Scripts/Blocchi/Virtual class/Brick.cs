using System;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Brick : MonoBehaviour, IBrick
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
    enum ScoreSet
    {

        [InspectorName("50")] S50 = 50,
        [InspectorName("70")] S70 = 70,
        [InspectorName("100")] S100 = 100,
        [InspectorName("150")] S150 = 150,
        [InspectorName("400")] S400 = 400

    }

    [SerializeField] ScoreSet scoreSet;

    public int ScoreValue => (int)scoreSet;


    public static event Action OnBrickDestroyed;


    [SerializeField] BrickType types;


    [SerializeField] protected int health = 1;


    [SerializeField] protected Color brikColor = Color.white;

    protected int currentHealth;

    private int texturIndex = 0;
    

    [SerializeField] Texture[] brokenTexture = new Texture[1];
    Material material;

    public virtual void Start()
    {
        currentHealth = health;

        GetComponent<Renderer>().material.color = brikColor;
        material.mainTexture = null;

        

        //Linea codice per swippare
        //material.mainTexture = brokenTexture[textureIndexx]
        //texture indez++
    }


    public virtual void Effect()
    {

    }

    protected void EventAction_OnBrickDestroyed()
    {
        OnBrickDestroyed?.Invoke();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        //Cambio Materia/Texture in base al danno
    }

    public void Destroy()
    {
        EventAction_OnBrickDestroyed();
        Effect();
        GetComponent<GameObject>().SetActive(false);
    }
}
