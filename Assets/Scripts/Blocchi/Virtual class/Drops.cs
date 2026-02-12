using UnityEngine;
using System;
using Unity.VisualScripting;

public abstract class Drops : MonoBehaviour, ICollectable
{
    enum TypeDrops
    {
        EnergyBall = 0,
        Buff_Invincible = 1,
        Buff_BulletShot = 2,
        Debuff_3xBall = 3

    }

    public static event Action<int> OnCollect;

    [SerializeField] TypeDrops typeDrops;

    private int dropNumber => (int)typeDrops;

    public virtual void Collect()
    {
        OnCollect?.Invoke(dropNumber);
    }

    public void Destroy()
    {
        throw new NotImplementedException();
    }
}
