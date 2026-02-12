using UnityEngine;
using System;

public class EnergyBall : Drops
{
    public static event Action OnTakeEnergyBall;

    public override void Collect()
    {
        OnTakeEnergyBall?.Invoke();
    }
}
