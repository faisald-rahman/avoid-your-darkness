using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FadeIn : MonoBehaviour
{
    [SerializeField]
    private float speed = 1;

    private SpriteRenderer spriteRenderer;

    private Color color;

    private bool isFadeIn = false;

    private UnityAction onComplete;

    // Start is called before the first frame update
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (isFadeIn)
        {
            color.a += speed * Time.deltaTime;
            if (color.a > 1)
            {
                color.a = 1;
                isFadeIn = false;
                onComplete();
            }
            spriteRenderer.color = color;
        }
    }

    public void StartFadeIn(UnityAction onComplete)
    {
        isFadeIn = true;
        color = spriteRenderer.color;
        color.a = 0;
        spriteRenderer.color = color;
        this.onComplete = onComplete;
    }

    public void Stop()
    {
        isFadeIn = false;
    }
}