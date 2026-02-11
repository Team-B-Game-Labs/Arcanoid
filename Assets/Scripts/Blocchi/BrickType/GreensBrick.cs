using UnityEngine;

public class GreensBrick : Brick
{
    private int randomDrop;
    public override void Effect()
    {
        base.Effect();
        randomDrop = Random.Range(0, DropItem.Length + 1);
        if (randomDrop > -1)
        {
            Instantiate(DropItem[randomDrop]);
        }
    }
}
