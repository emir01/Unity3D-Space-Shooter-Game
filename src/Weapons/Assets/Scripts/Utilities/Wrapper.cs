using UnityEngine;

/// <summary>
/// Utility script used to horizontaly wrap game objects, leaving the 
/// screen on either right or left borders
/// </summary>
public class Wrapper : MonoBehaviour
{
    #region Properties

    // Wrap tollerance used to "enclose" the left and right edges and wrap the object sooner.
    public float wrapTolerance = 1;

    #endregion

    #region Methods
    
    void Update()
    {
        // Get the screen width
        var width = Camera.mainCamera.GetScreenWidth();

        // Get the actual world edges
        var rightEdgePosition = Camera.mainCamera.ScreenToWorldPoint(new Vector3(width, 0, 0));
        var leftEdgePosition = Camera.mainCamera.ScreenToWorldPoint(new Vector3(0, 0, 0));

        // get the object half width used in the off screen calculation
        var transformHalfWidth = transform.localScale.x/2;
        
        // if the object leaves the right edge, considering the wrap tolerance.
        if (transform.position.x > rightEdgePosition.x + (transformHalfWidth -wrapTolerance))
        {
            transform.position = new Vector3(leftEdgePosition.x - (transformHalfWidth - wrapTolerance), transform.position.y, transform.position.z);
        }

        // The object leaves the left edge, considering the tollerance
        if (transform.position.x < leftEdgePosition.x - (transformHalfWidth -wrapTolerance  ))
        {
            transform.position = new Vector3(rightEdgePosition.x + (transformHalfWidth - wrapTolerance), transform.position.y, transform.position.z);
        }
    }

    #endregion
}
