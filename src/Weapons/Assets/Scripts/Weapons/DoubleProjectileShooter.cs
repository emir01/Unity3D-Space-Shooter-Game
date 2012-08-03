using UnityEngine;

/// <summary>
/// Weapon type based on weapon based that fires two projectiles from the front of the ship
/// </summary>
public class DoubleProjectileShooter : WeaponBase
{
    public override void Fire(GameObject ammo, GameObject origin)
    {
        // Create the two projectiles on the front of the ship, on two sides, based on the origin object(ship).

        Instantiate(ammo, new Vector3()
        {
            x = origin.transform.position.x - (origin.transform.localScale.x / 4),
            y = origin.transform.position.y + (origin.transform.localScale.y / 2),
            z = origin.transform.position.z
        }, Quaternion.identity);

        Instantiate(ammo, new Vector3()
        {
            x = origin.transform.position.x + (origin.transform.localScale.x / 4),
            y = origin.transform.position.y + (origin.transform.localScale.y / 2),
            z = origin.transform.position.z
        }, Quaternion.identity);
    }
}

