using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;

    [SerializeField]
    private GameOverManager gameOverManager;

    [SerializeField]
    private Score score;

    [SerializeField]
    private Gem gem;

    [SerializeField]
    private ParticleSystem particle;

    private SpriteRenderer spriteRenderer;
    private FollowMouse followMouse;
    private FadeIn fadeIn;

    private List<Vector2> positions = new List<Vector2>();

    private bool isStarting = false;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        followMouse = GetComponent<FollowMouse>();
        fadeIn = GetComponent<FadeIn>();
    }

    private void Start()
    {
        Color color = spriteRenderer.color;
        color.a = 0;
        spriteRenderer.color = color;
    }

    // Update is called once per frame
    private void Update()
    {
        if (isStarting)
        {
            positions.Add(transform.position);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (followMouse.GetIsMoving())
        {
            if (collision.gameObject.tag == "Gem")
            {
                SoundManager.Instance.playPickup();
                gem.ShowCollidePlayerEffect();
                score.AddGemScore();
            }
            else if (collision.gameObject.tag == "Enemy")
            {
                SoundManager.Instance.playGameOver();
                ShowDeath();
                StartCoroutine(waitForDeath());
            }
        }
    }

    public void StartFadeIn()
    {
        fadeIn.StartFadeIn(StartMoving);
    }

    public void ShowDeath()
    {
        Color color = spriteRenderer.color;
        color.a = 0;
        spriteRenderer.color = color;

        particle.Play();
        followMouse.StopMoving();
    }

    public List<Vector2> GetPositions()
    {
        return positions;
    }

    private void StartMoving()
    {
        isStarting = true;
        followMouse.StartMoving();
        score.StartCounting();
        gem.StartMoving();
    }

    private IEnumerator waitForDeath()
    {
        float normalizedTime = 0;
        while (normalizedTime <= 1f)
        {
            normalizedTime += Time.deltaTime / 2;
            yield return null;
        }
        gameOverManager.Show();
        score.StopCounting();
        gameManager.SaveScore();
    }
}