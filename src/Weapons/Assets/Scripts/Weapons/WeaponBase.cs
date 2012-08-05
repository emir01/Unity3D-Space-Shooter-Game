using UnityEngine;

/// <summary>
/// The base weapon abstract weapon system  class.
/// </summary>
public abstract class WeaponBase : ScriptableObject
{
    #region Weapon Base Properties

    /// <summary>
    /// The base weapon speed rate in seconds.
    /// </summary>
    public float WeaponBaseSpeed = 1.0f;

    /// <summary>
    /// The base weapon damage modifier.
    /// </summary>
    public float WeaponBaseDamageModifier = 1.0f;

    #endregion

    #region Abstract  Methods

    /// <summary>
    ///  Inherited from the concrete Weapon types.
    /// </summary>
    /// <param name="ammo">The ammo we are firing that could affect the rate of fire.</param>
    /// <param name="origin">The origin we are firing from. (Player Ship)</param>
    public abstract void Fire(GameObject ammo, GameObject origin);

    #endregion
}
