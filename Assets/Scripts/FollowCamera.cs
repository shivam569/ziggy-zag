using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour {

    public GameObject ball;
    // distance btw the camera and the ball
    Vector3 offset;
    // for camera movement
    public float lerpRate;
    public bool gameOver;

    // Start is called before the first frame update
    void Start() {
        offset = ball.transform.position - transform.position;
        gameOver = false;
    }

    // Update is called once per frame
    void Update() {
        if(!gameOver) {
            FollowTheBall();
        }
    }

    void FollowTheBall() {
        // we need to store position into Vector3 because we can't modify it directly
        Vector3 pos = transform.position;
        Vector3 targetPosition = ball.transform.position - offset;
        // keeps the frame movement smooth
        pos = Vector3.Lerp(pos, targetPosition, lerpRate * Time.deltaTime);
        transform.position = pos;
    }
}
