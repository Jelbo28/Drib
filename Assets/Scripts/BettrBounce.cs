using UnityEngine;
using System.Collections;

public class BettrBounce : MonoBehaviour
{
    [SerializeField]
    GameObject audioController;

    int timesPressed = 0;
    int jumpMultiplier = 1;
    float jumpVelocity = 1;
    bool reset = false;
    int currentJumpMultiplier = 1;


    void Update()
    {
        BounceMode();
    }

    void BounceMode()
    {
        if (Input.GetButtonDown("Jump"))
        {
            timesPressed++;
            if (timesPressed < 2)
            {
                jumpMultiplier++;
                jumpVelocity = 1 * jumpMultiplier;
                Debug.Log("pie, " + jumpVelocity);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Floor")
        {
            audioController.GetComponent<Audio>().BallBeat(jumpVelocity);
            if (timesPressed < 1)
            {
                gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * 300);
                jumpMultiplier = 1;
                jumpVelocity = 1;
                Debug.Log("Beep");
            }
            else
            {
                gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * (100 + (jumpVelocity * 100)));
                timesPressed = 0;
                Debug.Log("Boop");
            }
        }
    }
}
