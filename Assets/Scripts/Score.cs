using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public static int score = 0;
    private static int lastScoreBoss = 0;
    public static int scoreBoss = 0;
    public GameObject BossLevel;

    public TextMeshProUGUI scoreText;

    private Animator backgroundAnimation;
    private float cycleOffset;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        lastScoreBoss = 0;
        scoreBoss = 0;
        scoreText.text = "Score: " + score.ToString();
        backgroundAnimation = GetComponent<Animator>();

        // Disable the BossLevel object at the start
        BossLevel.SetActive(false);
    }

    public void IncrementScore()
    {
        lastScoreBoss = scoreBoss;
        score++;
        scoreBoss = score / 50;
        scoreText.text = "Score: " + score.ToString();
        backgroundAnimation.SetFloat("Transition", ((float)score) / 400f);

        if (score % 50 == 0 && scoreBoss > lastScoreBoss)
        {
            for (int i = 0; i < scoreBoss; i++)
            {
                SpawnBoss();
                
            }
        }
    }

    private void SpawnBoss()
    {
        if (score > 0)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");

            if (player != null)
            {
                Vector3 spawnPosition = player.transform.position;
                Instantiate(BossLevel, spawnPosition, Quaternion.identity);
                
            }
        }
    }
}