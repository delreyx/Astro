using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    TextMeshProUGUI label;
    // Start is called before the first frame update
    void Start()
    {
        label = GetComponent<TextMeshProUGUI>();
        label.SetText(Score.score.ToString());
    }

    
}
