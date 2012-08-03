using UnityEngine;

/// <summary>
/// The Ammo base script atached to Ammo prefabs, that currenly only handles ammo movement.
/// </summary>
public class AmmoBase:MonoBehaviour
{
    // The damage the ammo will do to objects it hits
    public float Damage;

    // The speed the ammo moves with 
    public float Speed;

    // The Rate of fire modifier for the Weapon it is fired from.
    public float RateOfFireModifier = 1.0f;

    void Update()
    {
        // Calculate the movement based on delta time  and move the ammo upwards
        var ammountToMove = Time.deltaTime*Speed;
        transform.Translate(Vector3.up * ammountToMove,Space.World);
    }
}

