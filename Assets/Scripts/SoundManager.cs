using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource bgm;

    [SerializeField]
    private AudioSource enemyAlert;

    [SerializeField]
    private AudioSource pickUp;

    [SerializeField]
    private AudioSource gameOver;

    public static SoundManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this);
        }
    }

    public void playBgm()
    {
        bgm.Play();
    }

    public void playEnemyAlert()
    {
        enemyAlert.Play();
    }

    public void playPickup()
    {
        pickUp.Play();
    }

    public void playGameOver()
    {
        gameOver.Play();
    }
}