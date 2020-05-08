using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    public GameObject particle;
    // speed of the ball for the game.
    [SerializeField]    // even if it is private it will show up in the editor so that we can edit it.
    private float speed;

    // if the screen is not touched the ball will not move at the start.
    bool started;

    // gameOver
    bool gameOver;

    // with rb we can change all the properties of the ball.
    Rigidbody rb;

    void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start() {
        started = false;
        gameOver = false;
    }

    // Update is called once per frame
    void Update() {
        if(!started) {
            if(Input.GetMouseButtonDown(0)) {
                rb.velocity = new Vector3(speed, 0, 0);
                started = true;

                // fetch `GameStart` from the GameManager.cs file
                // it will handle all the UI elements
                GameManager.instance.GameStart();
            }
        }

        // visual of the ray
        //Debug.DrawRay(transform.position, Vector3.down, Color.gray);

        // raycasting creates a ray pointing downwards,
        // it will return true if it is colliding with any other GameObject and if not is will be false
        if(!Physics.Raycast(transform.position, Vector3.down, 1f)) {
            gameOver = true;
            // gameOver the ball will fall down.
            rb.velocity = new Vector3(0, -30f, 0);

            // make the camera stop following the ball asa the balls drops down.
            Camera.main.GetComponent<FollowCamera>().gameOver = true;

            // fetch `GameOver()` from the GameManager.cs file
            // it will handle all the UI elements
            GameManager.instance.GameOver();
        }

        if (Input.GetMouseButtonDown(0) && !gameOver) {
            ChangeDirection();
        }
    }

    void ChangeDirection() {
        if (rb.velocity.z > 0) {
            rb.velocity = new Vector3(speed, 0, 0);
        } else if(rb.velocity.x > 0)
        {
            rb.velocity = new Vector3(0, 0, speed);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Diamond")
        {
            // the particle effect will get insitated as soon as the ball touches/crosses the diamond(cube).
            GameObject particleObject = Instantiate(particle, other.gameObject.transform.position, Quaternion.identity) as GameObject;

            Destroy(other.gameObject);
            Destroy(particleObject, 1f);
        }
    }







}
