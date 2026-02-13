using UnityEngine;

public class WhiteBrick : Brick
{
    private GameObject energyBall;

    public override void Start()
    {
        base.Start();
        energyBall = DropItem[0];
    }
    public override void Effect()
    {
        base.Effect();
        Instantiate(energyBall, transform.position, transform.localRotation);
    }
}
