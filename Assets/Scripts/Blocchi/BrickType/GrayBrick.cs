using UnityEngine;

public class GrayBrick : Brick              //Willy
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
        dropIndex = Random.Range(1, 4);
        if (dropIndex == 1)
            Instantiate(energyBall, transform.position, transform.localRotation);
    }

}

