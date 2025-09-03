using UnityEngine;

public class Ball : MonoBehaviour
{
    public GameManager manager;

    float ball_speed = 10;

    Vector3 velocity;
    Rigidbody2D rigidbody;

    void Start()
    {
    rigidbody = GetComponent<Rigidbody2D>();         
    }

    public void StartBallMovement() {
        float angle = Random.Range(0, 360);
        Vector3 direction = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0);

        rigidbody.linearVelocity = direction * ball_speed;
    }

    void Update()
    {
        velocity = rigidbody.linearVelocity;
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        string collision_tag = collision.collider.tag;
        if (collision_tag == "Wall") {
            ContactPoint2D[] points = collision.contacts;

            Vector3 new_direction = Vector3.Reflect(velocity, points[0].normal);

            rigidbody.linearVelocity = new_direction;
        }

        else if (collision_tag == "out.player" || collision_tag == "out.bot" ) {
            transform.position = new Vector3(0, 0, 0);
            rigidbody.linearVelocity = new Vector3(0, 0, 0);
            manager.is_started = false;

            if (collision_tag == "out.bot") {
                manager.my_score++;
            }
            else {
                manager.bot_score++;
            }
        }
    }
}
