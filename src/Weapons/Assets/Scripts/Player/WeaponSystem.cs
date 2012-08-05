using System.Collections;
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

    /// <summary>
    ///  Used to control if the player can fire the weapon based on the weapon rate of fire.
    /// </summary>
    private bool canFire = true;

    /// <summary>
    /// Used to control if the player can switch weapons.
    /// </summary>
    private bool canSwitchWeapon = true;

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
        if (Input.GetKeyDown("space") && canFire)
        {
            StartCoroutine(FireWeaponSystem());
        }
    }

    private void HandleWeaponSwitch()
    {
        if (canSwitchWeapon)
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
    }

    /// <summary>
    /// The actual method that handles the shooting of the currently selected weapon 
    /// with the currently selected ammo
    /// </summary>
    /// <returns></returns>
    private IEnumerator FireWeaponSystem()
    {
        // Call the Current Weapon Fire method with the loaded ammo and the 
        // game object to which the weapon system is atached to ( player ship )
        
        // Calculate modifiers for the Weapon rate of fire : 
        var baseAmmo = (AmmoBase)LoadedAmmo.GetComponent(typeof(AmmoBase));
        
        // Get the modifiers from the weapon
        var rateOfFireModifier = baseAmmo.WeaponRateOfFireModifier;
        
        CurrentWeapon.Fire(LoadedAmmo, gameObject);
        
        canFire = false;

        var timeToNextFire = CurrentWeapon.RateOfFire / rateOfFireModifier;
        yield return new WaitForSeconds(timeToNextFire);

        canFire = true;
    }

    #endregion
}
