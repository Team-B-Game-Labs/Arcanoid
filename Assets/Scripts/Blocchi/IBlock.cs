using UnityEngine;
using System;

public interface IBlock
{
    public static event Action OnBrickDestroyed;
    public void TakeDamage(int damage);

    public void Destroy();

    public void Effect();

    
}
