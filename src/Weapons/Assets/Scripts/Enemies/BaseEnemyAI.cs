using System.Collections;
using UnityEngine;

public class BaseEnemyAI : MonoBehaviour
{
    public float MinSpeed = 5.0f;
    public float MaxSpeed = 20.0f;

    public float timeMoveMin = 1.0f;
    public float timeMoveMax = 2.0f;

    private EnemyState MyState;

    // The values that control the actual movement
    private int DirectionToMove;
    private float SpeedToMove;
    private float TimeToMove;

    private enum EnemyState
    {
        Idle,
        Moving
    }

    // Use this for initialization
    void Start()
    {
        MyState = EnemyState.Idle;
    }

    // Update is called once per frame
    void Update()
    {
        if (MyState == EnemyState.Idle)
        {
            TimeToMove = Random.Range(timeMoveMin, timeMoveMax);
            SpeedToMove = Random.Range(MinSpeed, MaxSpeed);

            var directionRandom = Random.value;
            if (directionRandom > 0.5)
            {
                DirectionToMove = 1;
            }
            else
            {
                DirectionToMove = -1;
            }

            StartCoroutine(StartedMoving(TimeToMove));
        }
        else
        {
            var ammountToMove = Time.deltaTime * DirectionToMove * SpeedToMove;
            transform.Translate(Vector3.right*ammountToMove);
        }
    }

    IEnumerator StartedMoving(float time)
    {
        MyState = EnemyState.Moving;

        yield return new WaitForSeconds(time);

        MyState = EnemyState.Idle;
    }
}
