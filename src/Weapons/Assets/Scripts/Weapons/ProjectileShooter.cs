using UnityEngine;

/// <summary>
/// Simple projectile shooter that only fires one projectile at a time
/// </summary>
public class ProjectileShooter : WeaponBase
{
    public ProjectileShooter()
    {
        // Set projectile shooter properties here
        WeaponBaseSpeed = 0.5f;
    }
    
    public override void Fire(GameObject ammo, GameObject origin)
    {
        // Create the projectile on the front center of the ship based on the origin object(ship).

        var firedAmmo = Instantiate(ammo, new Vector3()
                              {
                                  x = origin.transform.position.x,
                                  y = origin.transform.position.y + (origin.transform.localScale.y / 2),
                                  z = origin.transform.position.z
                              }, Quaternion.identity);
    }
}
