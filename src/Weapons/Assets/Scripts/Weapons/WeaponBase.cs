using UnityEngine;

/// <summary>
/// The base weapon abstract weapon system  class.
/// </summary>
public abstract class WeaponBase : MonoBehaviour
{
    #region Weapon Base Properties

    /// <summary>
    /// The base weapon speed rate in seconds.
    /// </summary>
    public float RateOfFire = 1.0f;

    /// <summary>
    /// The modifier for the ammo damage.
    /// </summary>
    public float AmmoDamageModifier = 1.0f;

    /// <summary>
    /// The modifier for the ammo speed
    /// </summary>
    public float AmmoSpeedModifier = 1.0f;

    #endregion

    #region Abstract  Methods

    /// <summary>
    ///  Inherited from the concrete Weapon types.
    /// </summary>
    /// <param name="ammo">The ammo we are firing that could affect the rate of fire.</param>
    /// <param name="origin">The origin we are firing from. (Player Ship)</param>
    public abstract void Fire(GameObject ammo, GameObject origin);

    /// <summary>
    /// The method that is responsible to modifying the ammo based on the ammo modifiers after
    /// the ammo is instantiated.
    /// </summary>
    /// <param name="ammo"></param>
    protected void ModifyAmmo(GameObject ammo)
    {
        var baseAmmo = (AmmoBase)ammo.GetComponent(typeof(AmmoBase));
        
        baseAmmo.Damage = baseAmmo.Damage * AmmoDamageModifier;
        baseAmmo.Speed = baseAmmo.Speed * AmmoSpeedModifier;
    }

    #endregion
}
