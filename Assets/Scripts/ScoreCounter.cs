using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TMPro.TMP_Text))]
public class ScoreCounter : MonoBehaviour
{
    // Display the score, set from unity
    private TMPro.TMP_Text scoreText;

    // Store the score for each user
    private int score = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        scoreText = gameObject.GetComponent<TMPro.TMP_Text>();
    }

    public void IncrementScore(){
        score++;
        scoreText.SetText(score.ToString());
    }
}
