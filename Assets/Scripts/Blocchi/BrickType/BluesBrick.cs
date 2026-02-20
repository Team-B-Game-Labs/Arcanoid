using UnityEngine;

public class BluesBrick : Brick             //Willy
{
    
    private int randomDrop;

   
    public override void Effect()
    {
        base.Effect();
        randomDrop = Random.Range(0, DropItem.Length);
        if (randomDrop > -1)
        {
            Instantiate(DropItem[randomDrop], transform.position, transform.localRotation);
        }
    }
}
