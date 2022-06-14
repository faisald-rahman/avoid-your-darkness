using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;

    [SerializeField]
    private Score score;

    [SerializeField]
    private Text scoreTxt;

    [SerializeField]
    private Button playBtn;

    private Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    // Start is called before the first frame update
    private void Start()
    {
        Hide();

        playBtn.onClick.AddListener(gameManager.RestartScene);
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void Show()
    {
        Color color = image.color;
        color.a = 0.5f;
        image.color = color;

        scoreTxt.text = score.GetValue() + "";
    }

    public void Hide()
    {
        Color color = image.color;
        color.a = 0;
        image.color = color;
    }
}