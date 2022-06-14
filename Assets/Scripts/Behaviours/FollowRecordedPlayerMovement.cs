using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowRecordedPlayerMovement : MonoBehaviour
{
    private List<Vector2> recordedMovements = new List<Vector2>();

    private bool isMoving = false;

    private int indexMovement = 0;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if (isMoving)
        {
            transform.position = recordedMovements[indexMovement];
            indexMovement += 1;
        }
    }

    public void SetRecorededMovement(List<Vector2> movements)
    {
        recordedMovements = movements;
    }

    public void StartMoving()
    {
        isMoving = true;
        transform.position = recordedMovements[0];
    }
}