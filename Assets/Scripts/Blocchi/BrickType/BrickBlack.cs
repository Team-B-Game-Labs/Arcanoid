using UnityEngine;

public class BrickBlack : Brick 
{
    [SerializeField] GameObject Debuff_3xBall;

    public override void Effect()
    {
        base.Effect();
        Instantiate(Debuff_3xBall);
    }
}
