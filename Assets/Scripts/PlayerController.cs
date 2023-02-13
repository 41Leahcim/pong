using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Serialize the upKey and downKey variables to set them for each paddle separately
    [SerializeField] private KeyCode upKey;
    [SerializeField] private KeyCode downKey;

    // Set the speed for the paddles
    private float speed = 4;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // Move the paddle up, if the user presses the up-key for this paddle
        if(Input.GetKey(upKey) && transform.position.y + transform.localScale.y / 2 < 5){
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }

        // Move the paddle down, if the user presses the down-key for this paddle
        if(Input.GetKey(downKey) && transform.position.y - transform.localScale.y / 2 > -5){
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
    }
}
