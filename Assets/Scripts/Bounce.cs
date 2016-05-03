using UnityEngine;
using System.Collections;

public class Bounce : MonoBehaviour {

    #region Variables
    bool firstVelocityStored = false;
    bool reset = false;

    Vector2 initialVelocity;
    Vector2 originalVelocity;

    int jumpMultiplier = 1;
    int currentJumpMultiplier = 1;
    int timesPressed = 0;

    float jumpVelocity = 0f;
    #endregion

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            timesPressed++;
            if (timesPressed < 2)
            {
                jumpMultiplier++;
                jumpVelocity = 1 * jumpMultiplier;
                Debug.Log("jump, " + jumpVelocity);
            }
        }
    }


    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Floor")
        {
            if (!firstVelocityStored)
            {
                Debug.Log("poop");
                initialVelocity = gameObject.GetComponent<Rigidbody2D>().velocity;
                originalVelocity = initialVelocity;
                Debug.Log("velocityO, " + originalVelocity);
                firstVelocityStored = true;
            }
            if (jumpMultiplier == currentJumpMultiplier)
            {
                Debug.Log("It");
                reset = true;
                jumpMultiplier = 1;
            }
            else
            {
                currentJumpMultiplier = jumpMultiplier;
                reset = false;
            }
            timesPressed = 0;
        }
        if(!reset)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, initialVelocity.y - jumpVelocity);
            Debug.Log(initialVelocity);
            Debug.Log(gameObject.GetComponent<Rigidbody2D>().velocity);
        }
        else
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, originalVelocity.y);
            jumpVelocity = 0;
        }

    }
}
