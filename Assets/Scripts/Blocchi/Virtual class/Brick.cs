 using System;
using UnityEngine;

public abstract class Brick : MonoBehaviour, IBrick
{
    enum BrickType
    {
        Gray,
        White,
        Green,
        Blue,
        Black,

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

    public static event Action<int> OnSetScorePoint;


    [SerializeField] BrickType types;


    [SerializeField] protected int health = 1;
    


    [SerializeField] protected Color brikColor = Color.white;

    [SerializeField] protected int currentHealth;

    private int texturIndex;

    protected int dropIndex;

    [SerializeField]protected GameObject[] DropItem = new GameObject[1];
    

    [SerializeField] Material[] brokenTexture;

    MeshRenderer material;

    public virtual void Awake()
    {
        ///*GetComponent<Renderer>().material.color*/ = brikColor;
        material = GetComponent<MeshRenderer>();
    }

    public virtual void Start()
    {
        currentHealth = health;

        texturIndex = 0;
        
        material.material = brokenTexture[0];

        
    }


    public virtual void Effect()
    {
        OnSetScorePoint?.Invoke(ScoreValue);
    }

    protected void EventAction_OnBrickDestroyed()
    {
        OnBrickDestroyed?.Invoke();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            BrickDestroy();
        }

        if (texturIndex == 0)
        {
            texturIndex++;
        }
        else if (texturIndex == 1)
        {
            texturIndex++;
        }
        else if (texturIndex == 2) { texturIndex++; }


        material.material = brokenTexture[texturIndex];
        
        
        
    }

    public void BrickDestroy()
    {
        EventAction_OnBrickDestroyed();
        Effect();
        Destroy(gameObject);
        Debug.Log("blocco distrutto");
    }

    
}
