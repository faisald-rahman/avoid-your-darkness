using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float delay = 1;

    private Player player;

    private FollowRecordedPlayerMovement followRecordedPlayerMovement;
    private FadeIn fadeIn;

    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider2D;
    private TrailRenderer trailRenderer;

    // Start is called before the first frame update
    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        followRecordedPlayerMovement = GetComponent<FollowRecordedPlayerMovement>();
        fadeIn = GetComponent<FadeIn>();

        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        trailRenderer = GetComponent<TrailRenderer>();
    }

    private void Start()
    {
        boxCollider2D.enabled = false;
        trailRenderer.emitting = false;

        followRecordedPlayerMovement.SetRecorededMovement(player.GetPositions());

        Color color = spriteRenderer.color;
        color.a = 0;
        spriteRenderer.color = color;
    }

    public void StartDelay()
    {
        StartCoroutine(waitForDelay());
    }

    private void StartMoving()
    {
        boxCollider2D.enabled = true;
        followRecordedPlayerMovement.StartMoving();
        trailRenderer.emitting = true;
    }

    private IEnumerator waitForDelay()
    {
        float normalizedTime = 0;
        while (normalizedTime <= 1f)
        {
            normalizedTime += Time.deltaTime / delay;
            yield return null;
        }

        fadeIn.StartFadeIn(StartMoving);
        SoundManager.Instance.playEnemyAlert();
    }
}