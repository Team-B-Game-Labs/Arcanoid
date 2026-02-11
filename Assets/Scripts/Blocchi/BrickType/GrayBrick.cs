using UnityEngine;

public class GrayBrick : Brick
{
    private GameObject energyBall;

    public override void Start()
    {
        base.Start();
        energyBall = DropItem[1];
    }
    public override void Effect()
    {
        base.Effect();
        dropIndex = Random.Range(1, 4);
        if (dropIndex == 1)
            Instantiate(energyBall);
    }

}

