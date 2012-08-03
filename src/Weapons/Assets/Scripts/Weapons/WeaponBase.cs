using UnityEngine;

/// <summary>
/// The base weapon abstract weapon system  class.
/// </summary>
public abstract class WeaponBase : ScriptableObject
{
    /// <summary>
    ///  Inherited from the concrete Weapon types.
    /// </summary>
    /// <param name="ammo">The ammo we are firing that could affect the rate of fire.</param>
    /// <param name="origin">The origin we are firing from. (Player Ship)</param>
    public abstract void Fire(GameObject ammo, GameObject origin);
}
