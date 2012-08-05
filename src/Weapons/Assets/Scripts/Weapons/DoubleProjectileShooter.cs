using UnityEngine;

/// <summary>
/// Weapon type based on weapon based that fires two projectiles from the front of the ship
/// </summary>
public class DoubleProjectileShooter : WeaponBase
{
    public DoubleProjectileShooter()
    {
        RateOfFire = 2.0f;
    }

    public override void Fire(GameObject ammo, GameObject origin)
    {
        // Create the two projectiles on the front of the ship, on two sides, based on the origin object(ship).
        var round1 = (GameObject)Instantiate(ammo, new Vector3()
        {
            x = origin.transform.position.x - (origin.transform.localScale.x / 4),
            y = origin.transform.position.y + (origin.transform.localScale.y / 2),
            z = origin.transform.position.z
        }, Quaternion.identity);
        
        ModifyAmmo(round1);

        var round2 = (GameObject)Instantiate(ammo, new Vector3()
        {
            x = origin.transform.position.x + (origin.transform.localScale.x / 4),
            y = origin.transform.position.y + (origin.transform.localScale.y / 2),
            z = origin.transform.position.z
        }, Quaternion.identity);
        
        ModifyAmmo(round2);
    }
}

