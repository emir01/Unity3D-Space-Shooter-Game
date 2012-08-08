using UnityEngine;

[RequireComponent(typeof(BaseEnemy))]
public class GuiEnemyHP : MonoBehaviour
{
    #region Fields

    private BaseEnemy thisEnemy;
    private int StartingHP = 0;

    #endregion

    #region Properties

    #endregion

    #region Functions and Methods

    void Start()
    {
        thisEnemy = gameObject.GetComponent<BaseEnemy>();
        StartingHP = thisEnemy.BaseHealth;
    }

    void Update()
    {
        // calculate the text position
    }

    void OnGUI()
    {
        GUI.Label(new Rect(20, Screen.height - 30, 200, 20), "Enemy : "+ thisEnemy.BaseHealth + "/" + StartingHP);
    }

    #endregion
}
