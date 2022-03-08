using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2d;
    [SerializeField] float torqueAmount = 1f;
    [SerializeField] float boostSpeed = 30f;
    [SerializeField] float baseSpeed = 20f;
    [SerializeField] GameObject playerTop;
    SurfaceEffector2D surfaceEffector2D;

    float jumpAccum = 0f;
    [SerializeField] float jumpStep = 0.01f;
    [SerializeField] float jumpMax = 5f;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
        surfaceEffector2D.speed = baseSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (FindObjectOfType<CrashDetector>().isAlive) {
            RotatePlayer();
            RespondToBoost();
            //RespondToJump();
        }
    }

    void RotatePlayer (){
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddTorque(torqueAmount);
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddTorque(-torqueAmount);
        }
    }

    void RespondToBoost() {
        //if we push up speed up, if not remain
        if (Input.GetKeyDown(KeyCode.DownArrow)) {
            surfaceEffector2D.speed = boostSpeed;
            playerTop.transform.Rotate(0, 0, -15f);
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow)) {
            surfaceEffector2D.speed = baseSpeed;
            playerTop.transform.Rotate(0, 0, 15f);
        }
    }

    void RespondToJump() {
        //if we push up speed up, if not remain
        if (Input.GetKey(KeyCode.UpArrow) && jumpAccum < jumpMax) {
            jumpAccum += jumpStep;
            transform.Translate(0, jumpStep, 0);
        }
        //Key released
        if (Input.GetKeyUp(KeyCode.UpArrow)) {
            //Avoid jumping again
            jumpAccum = 5;
        }
    }
}
