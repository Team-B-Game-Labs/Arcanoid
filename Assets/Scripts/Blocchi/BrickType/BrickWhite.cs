using UnityEngine;

public class BrickWhite : Brick
{
    [SerializeField] GameObject energyBall;
    public override void Effect()
    {
        base.Effect();
        Instantiate(energyBall);
    }
}