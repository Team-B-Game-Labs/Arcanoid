using UnityEngine;

public class BrickRose : Brick
{
    [SerializeField] GameObject Buff_Invincible;

    public override void Effect()
    {
        base.Effect();
        Instantiate(Buff_Invincible);
    }
}
