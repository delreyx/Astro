using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LivesCounter : MonoBehaviour

int Lives;

    void Start()
    {
        UpdateUI();
    }

    void UpdateUI()
    {
        GameObject.Find("LivesCounter").GetComponent<Text>().text = "Lives : " + Lives;
    }

    void OnCollisionEnter2D(Collision2D coll)

    {
        string tag = coll.collider.gameObject.tag;


        if (tag == "avoid_me")
        {
         
            Lives = PlayerPrefs.GetInt("Lives");
            Lives--;
            PlayerPrefs.SetInt("Lives", Lives);

             if (Lives > 0)
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

