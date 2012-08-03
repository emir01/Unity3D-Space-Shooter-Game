using UnityEngine;

/// <summary>
///  Simple horizontal level 2D controller script.
/// </summary>
public class Controller : MonoBehaviour
{
    #region Properties
    
    // Controls the speed of the normal player movement
    public float playerSpeed = 10;
    
    // The extra speed factor when pressing the boost speed key ( left shift ) 
    public float speedBoost = 2;

    #endregion

    void Update()
    {
        var moveAmmount = playerSpeed * Time.deltaTime;

        // Add to moveAmmount if left shift is pressed
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveAmmount = moveAmmount*speedBoost;
        }

        // translate the current player/transform
        transform.Translate(Vector3.right * Input.GetAxisRaw("Horizontal") * moveAmmount, Space.World);    
    }
}
