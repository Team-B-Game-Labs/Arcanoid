using UnityEngine;

public class BrickBordeaux : Brick
{
    [SerializeField] GameObject bullet;

    public override void Effect()
    {
        base.Effect();
        Instantiate(bullet);
    }
   
}
