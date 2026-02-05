using System;
using UnityEngine;

public class BlockGray : MonoBehaviour, IBlock
{
    
    private int points = 50;
    private int health = 1;
    public int currentHealth;

    public static event Action OnBrickDestroyed;

    private void Start()
    {
        currentHealth = health;
    }

    public void Destroy()
    {
        OnBrickDestroyed?.Invoke();
        gameObject.SetActive(false);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }

    public void Effect()
    {
        return;
    }

    
}
