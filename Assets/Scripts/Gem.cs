using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem particle;

    private SpriteRenderer spriteRenderer;
    private AutoMoveUpDown autoMoveUpDown;
    private RandomPosition randomPosition;
    private FadeIn fadeIn;

    private BoxCollider2D boxCollider2D;

    // Start is called before the first frame update
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        autoMoveUpDown = GetComponent<AutoMoveUpDown>();
        randomPosition = GetComponent<RandomPosition>();
        fadeIn = GetComponent<FadeIn>();

        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    public void Start()
    {
        boxCollider2D.enabled = false;
    }

    public void StartMoving()
    {
        boxCollider2D.enabled = true;
        randomPosition.SetPosition();
        fadeIn.StartFadeIn(() => { });
        autoMoveUpDown.StartMoving();
    }

    public void ShowCollidePlayerEffect()
    {
        Color color = spriteRenderer.color;
        color.a = 0;
        spriteRenderer.color = color;

        boxCollider2D.enabled = false;

        fadeIn.Stop();
        autoMoveUpDown.StopMoving();
        particle.Play();
        StartCoroutine(waitForDelay());
    }

    private IEnumerator waitForDelay()
    {
        float normalizedTime = 0;
        while (normalizedTime <= 1f)
        {
            normalizedTime += Time.deltaTime / 2;
            yield return null;
        }
        StartMoving();
    }

    public bool GetIsMoving()
    {
        return autoMoveUpDown.GetIsMoving();
    }
}