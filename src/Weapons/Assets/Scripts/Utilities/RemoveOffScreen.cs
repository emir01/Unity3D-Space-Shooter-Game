
using UnityEngine;

/// <summary>
/// Utility scripts that removes game objects that go off screen.
/// </summary>
public class RemoveOffScreen : MonoBehaviour
{
    void Update()
    {
        // get screen dimensions
        var screenHeight = Camera.mainCamera.GetScreenHeight();
        var screenWidth = Camera.mainCamera.GetScreenWidth();

        // get the translation for the coordinates from the screen to the world coordinates
        var upperLeft = Camera.mainCamera.ScreenToWorldPoint(new Vector3(0, screenHeight, 0));
        var downRight = Camera.mainCamera.ScreenToWorldPoint(new Vector3(screenWidth, 0, 0));

        // get the object half dimension values used in calcualtions
        // to make sure the object is totally of screen before removing.
        var halfWidth = transform.localScale.x / 2;
        var halfHeight = transform.localScale.y / 2;

        // If the game object leaves either by going out of the top or left borders
        if (transform.position.y > upperLeft.y + halfHeight || transform.position.x < upperLeft.x - halfWidth)
        {
            Destroy(gameObject);
        }

        // If the game object leaves either by going out of the bottom or right borders
        if (transform.position.y < downRight.y - halfHeight || transform.position.x > downRight.x + halfWidth)
        {
            Destroy(gameObject);
        }
    }
}

