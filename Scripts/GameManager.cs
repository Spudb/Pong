using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject bot;
    public GameObject ball;

    Vector3 bot_target_position;

    public TextMeshProUGUI my_score_txt;
    public TextMeshProUGUI bot_score_txt;

    public int my_score;
    public int bot_score;

    int default_score = 0;



    public bool is_started = false;

    public float speed = 6f;
    public float error = 2;
    void Start()
    {
        my_score = default_score;
        bot_score = default_score;
  
    }

    void Update()
    {
        my_score_txt.text = my_score.ToString();
        bot_score_txt.text = bot_score.ToString();
     
        float moveInput = Input.GetAxis("Vertical");

        if (moveInput != 0)
        {
            Debug.Log("Move input detected: " + moveInput);
            Vector3 movement = new Vector3(0, speed * moveInput * Time.deltaTime, 0);
            player.transform.Translate(movement);
            Debug.Log("Player position: " + player.transform.position);

            if (is_started == false) {
                is_started = true;
                ball.GetComponent<Ball>().StartBallMovement();
            }
        }

    if (ball.GetComponent<Rigidbody2D>().linearVelocity.x < 0) {
        bot_target_position = ball.transform.position + new Vector3(0, Random.Range(-error, error), 0);

        if (bot_target_position.y > bot.transform.position.y) {
            bot.transform.position += new Vector3(0, speed * Time.deltaTime, 0);
        }
        else {
            bot.transform.position -= new Vector3(0, speed * Time.deltaTime, 0);
             }
    }

    }
}
