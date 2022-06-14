using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private Text text;

    private int value = 0;

    private float time = 0;

    private bool isCounting = false;

    // Start is called before the first frame update
    private void Awake()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (isCounting)
        {
            time += Time.deltaTime;
            if (time >= 1)
            {
                time = 0;
                value += 1;
                text.text = value + "";
            }
        }
    }

    public void StartCounting()
    {
        value = 0;
        text.text = value + "";
        isCounting = true;
    }

    public void StopCounting()
    {
        isCounting = false;
    }

    public void AddGemScore()
    {
        value += 5;
        text.text = value + "";
    }

    public int GetValue()
    {
        return value;
    }
}