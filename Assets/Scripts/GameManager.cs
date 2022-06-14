using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Player player;

    [SerializeField]
    private Score score;

    [SerializeField]
    private Text highScoreTxt;

    [SerializeField]
    private Text clickInstruction;

    private EnemyManager enemyManager;

    private int highScoreValue;

    private bool isPlaying = false;

    private void Awake()
    {
        enemyManager = GetComponent<EnemyManager>();
    }

    // Start is called before the first frame update
    private void Start()
    {
        SoundManager.Instance.playBgm();
        highScoreValue = PlayerPrefs.HasKey("score") ? PlayerPrefs.GetInt("score") : 0;
        highScoreTxt.text = "HS: " + highScoreValue;
    }

    private void Update()
    {
        if (!isPlaying && Input.GetMouseButton(0))
        {
            isPlaying = true;
            player.StartFadeIn();
            clickInstruction.text = "";
            enemyManager.ActivateEnemies();
        }
    }

    public void SaveScore()
    {
        if (highScoreValue < score.GetValue())
        {
            highScoreValue = score.GetValue();
            PlayerPrefs.SetInt("score", highScoreValue);
            PlayerPrefs.Save();
        }
    }

    public void RestartScene()
    {
        SceneManager.LoadScene("Main");
    }
}