using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    // Redd: Use a constant so you only need to change this number once.
    private const int bossSpawnRate = 5;
    
    public static int score = 0;
    private static int lastScoreBoss = 0;
    public static int scoreBoss = 0;

    // Redd: You can use a read only variable to trigger the boss.
    public static bool nextTileIsBoss { get; private set; } = false;

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
        // Redd: default this to false.
        nextTileIsBoss = false;
        
        scoreText.text = "Score: " + score.ToString();
        backgroundAnimation = GetComponent<Animator>();
    }

    public void IncrementScore()
    {
        lastScoreBoss = scoreBoss;
        score++;
        // Redd: Here
        scoreBoss = score / bossSpawnRate;
        
        scoreText.text = "Score: " + score.ToString();
        backgroundAnimation.SetFloat("Transition", ((float)score) / 400f);
        
        // Redd: Small tweaks to this condition.
        if (score % bossSpawnRate == 0 && scoreBoss > lastScoreBoss)
        {
            nextTileIsBoss = true;
        }
    }

    // Redd: This will reset the boolean.
    public static void ResetBossSpawn()
    {
        nextTileIsBoss = false;
    }}