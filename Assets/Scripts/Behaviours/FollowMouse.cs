using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    public float maxMoveSpeed = 10;
    public float smoothTime = 0.3f;
    private Vector2 currentVelocity;

    [SerializeField]
    private float borderLeft = 0;

    [SerializeField]
    private float borderRight = 0;

    [SerializeField]
    private float borderTop = 0;

    [SerializeField]
    private float borderBottom = 0;

    private bool isMoving = false;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if (isMoving)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (mousePosition.x < borderLeft) mousePosition.x = borderLeft;
            else if (mousePosition.x > borderRight) mousePosition.x = borderRight;

            if (mousePosition.y > borderTop) mousePosition.y = borderTop;
            else if (mousePosition.y < borderBottom) mousePosition.y = borderBottom;
            transform.position = Vector2.SmoothDamp(transform.position, mousePosition, ref currentVelocity, smoothTime, maxMoveSpeed);
        }
    }

    public void StartMoving()
    {
        isMoving = true;
    }

    public void StopMoving()
    {
        isMoving = false;
    }

    public bool GetIsMoving()
    {
        return isMoving;
    }
}