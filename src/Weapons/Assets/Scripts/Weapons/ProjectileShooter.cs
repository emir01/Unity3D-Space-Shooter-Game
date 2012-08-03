using UnityEngine;

/// <summary>
/// Simple projectile shooter that only fires one projectile at a time
/// </summary>
public class ProjectileShooter : WeaponBase
{
        public override void Fire(GameObject ammo, GameObject origin)
    {
        // Create the projectile on the front center of the ship based on the origin object(ship).

        Instantiate(ammo, new Vector3()
                              {
                                  x = origin.transform.position.x,
                                  y = origin.transform.position.y + (origin.transform.localScale.y / 2),
                                  z = origin.transform.position.z
                              }, Quaternion.identity);
    }
}
