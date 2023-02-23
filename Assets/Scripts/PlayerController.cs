using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Set the speed for the paddles
    private float speed = 4;
    private float direction = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // Move the paddle
        transform.Translate(Vector3.up * speed * direction * Time.deltaTime);
    }

    void OnMove(InputValue value){
        direction = value.Get<float>();
    }
}
