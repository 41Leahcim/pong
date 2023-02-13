using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    // Stores the speed for the ball, serialize to change it easily
    [SerializeField] private Vector3 speed;

    // Display the score, set from unity
    [SerializeField] private TMPro.TMP_Text scoreText1;
    [SerializeField] private TMPro.TMP_Text scoreText2;

    // The speedMultiplier gives extra speed to the ball
    [SerializeField] private float speedMultiplier = 1;

    // Store the score for each user
    private int score1 = 0;
    private int score2 = 0;

    // The position and speed at the beginning, to easily reset when the ball goes off-screen
    private Vector3 startPosition;
    private Vector3 startSpeed;

    // Start is called before the first frame update
    void Start()
    {
        // Set the start position and start speed to the current position and speed
        startPosition = transform.position;
        startSpeed = speed;
    }

    void ProcessWinner(ref int score, ref TMPro.TMP_Text scoreText){
        // Reset the position and set the speed to the inverse of the start speed
        transform.position = startPosition;
        speed = -startSpeed;

        // Set the startspeed to the new speed and set the the speedmultiplier back to 1
        startSpeed = speed;
        speedMultiplier = 1;

        // Increase and display the score of player 2
        score++;
        scoreText.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        // Move the ball
        transform.position += speed * Time.deltaTime * speedMultiplier;
        
        // Bounce the ball of the top and lower edges of the screen
        if(transform.position.y > 5 - transform.localScale.y / 2 ||
           transform.position.y < -5 + transform.localScale.y / 2){
            speed.y = -speed.y;
        }

        // If the ball goes off the left edge of the screen, player 2 wins
        if(transform.position.x < -11 - transform.localScale.x){
            ProcessWinner(ref score2, ref scoreText2);
        }

        // If the ball goes off the right edge of the screen, player 1 wins
        if(transform.position.x > 11 + transform.localScale.x){
            ProcessWinner(ref score1, ref scoreText1);
        }
    }

    // Called when a paddle hits the ball
    void OnTriggerEnter2D(Collider2D other){
        // Invert the speed on the x-axis
        speed.x = -speed.x;

        // Calculate and set the speed on the y-axis depending on the hit distance from the center
        speed.y = (transform.position.y - other.transform.position.y);

        // Calculate the speed multiplier based on the y-speed with a minimum of 0.5
        speedMultiplier *= Mathf.Abs(speed.y) + 0.5f;
    }
}
