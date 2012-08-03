using UnityEngine;

/// <summary>
/// The weapon system is used to manage Current Weapons and Ammo Types.
/// Its the entry point to fire the current weapon.
/// </summary>
public class WeaponSystem : MonoBehaviour
{
    #region Properties

    // The current  active Weapon
    public WeaponBase CurrentWeapon;

    // The current loaded ammo type
    public GameObject LoadedAmmo;

    #endregion

    #region Methods

    void Start()
    {
        // Set the current weapon to the Simple Projectile Shooter
        CurrentWeapon = ScriptableObject.CreateInstance(typeof(ProjectileShooter)) as WeaponBase;
    }

    void Update()
    {
        // See if user has switched weapons
        HandleWeaponSwitch();
        
        // Handle fire user input
        if (Input.GetKeyDown("space"))
        {
            // Call the Current Weapon Fire method with the loaded ammo and the 
            // game object to which the weapon system is atached to ( player ship )
            CurrentWeapon.Fire(LoadedAmmo,gameObject);       
        }
    }

    private void HandleWeaponSwitch()
    {
        // Switch Weapons
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            CurrentWeapon = ScriptableObject.CreateInstance(typeof(ProjectileShooter)) as WeaponBase;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            CurrentWeapon = ScriptableObject.CreateInstance(typeof(DoubleProjectileShooter)) as WeaponBase;
        }
    }

    #endregion
}
