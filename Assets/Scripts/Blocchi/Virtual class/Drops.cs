using UnityEngine;

public class Drops : MonoBehaviour
{
    enum TypeDrops
    {
        EnergyBall,
        Bullet,
        TargetBullet,
        Buff_Invincible,
        Buff_BulletShot,
        Debuff_3xBall

    }

    [SerializeField] TypeDrops typeDrops;

}
