using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMoveUpDown : MonoBehaviour
{
    [SerializeField]
    private float initSpeed = 1;

    [SerializeField]
    private float acceleration = 0.2f;

    [SerializeField]
    private float maxTimeMoving = 1;

    [SerializeField]
    private float borderTop = 0;

    [SerializeField]
    private float borderBottom = 0;

    private float speed = 0;
    private float timer = 0;

    private bool isMoving = false;
    private bool isMoveUp = true;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if (isMoving)
        {
            Vector2 position = transform.position;
            if (isMoveUp)
            {
                position.y += speed * Time.deltaTime;
            }
            else
            {
                position.y -= speed * Time.deltaTime;
            }

            speed += acceleration;

            if (position.y > borderTop)
            {
                position.y = borderTop;
                ReverseDirection();
            }
            else if (position.y < borderBottom)
            {
                position.y = borderBottom;
                ReverseDirection();
            }

            transform.position = position;

            timer += Time.deltaTime;
            if (timer > maxTimeMoving)
            {
                timer = 0;
                ReverseDirection();
            }
        }
    }

    private void ReverseDirection()
    {
        speed = initSpeed;
        isMoveUp = !isMoveUp;
        timer = 0;
    }

    public void StartMoving()
    {
        speed = initSpeed;
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