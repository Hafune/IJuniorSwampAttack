using UnityEngine;

public class Shotgun : Weapon
{
    public override void Shoot(Transform shootPoint)
    {
        Instantiate(Bullet, shootPoint.position, Quaternion.identity);
        Instantiate(Bullet, shootPoint.position, Quaternion.identity).ChangeDirectionByAngle(15f);
        Instantiate(Bullet, shootPoint.position, Quaternion.identity).ChangeDirectionByAngle(-15f);
    }
}