using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPosition : MonoBehaviour
{
    [SerializeField]
    private float borderLeft = 0;

    [SerializeField]
    private float borderRight = 0;

    [SerializeField]
    private float borderTop = 0;

    [SerializeField]
    private float borderBottom = 0;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void SetPosition()
    {
        transform.position = new Vector2(Random.Range(borderLeft, borderRight), Random.Range(borderTop, borderBottom)); ;
    }
}