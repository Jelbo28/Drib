using UnityEngine;
using System.Collections;

public class Bounce : MonoBehaviour
{

    #region Variables
    [SerializeField]
    PhysicsMaterial2D rolly;
    [SerializeField]
    PhysicsMaterial2D bouncy;
    [SerializeField]
    GameObject audioController;
    bool firstVelocityStored = false;
    bool reset = false;
    bool wasntBouncing = false;

    Vector2 initialVelocity;
    Vector2 originalVelocity;

    int jumpMultiplier = 1;
    int currentJumpMultiplier = 1;
    int timesPressed = 0;

    bool rolling = false;
    bool bounce = true;

    float jumpVelocity;
    float gravityLevel = 1f;
    #endregion

    void Update()
    {
        TempController();
        ModeController();
        Debug.Log("CurrentV, " + initialVelocity);
    }

    void RollMode()
    {
        wasntBouncing = true;
        gameObject.GetComponent<CircleCollider2D>().sharedMaterial = rolly;
        gameObject.GetComponent<Bounce>().enabled = false;
        iTween.RotateBy(gameObject, iTween.Hash("z", -1f, "easetype", "linear", "looptype", iTween.LoopType.loop));
        rolling = true;
    }

    void BounceMode()
    {
        gameObject.GetComponent<Rigidbody2D>().gravityScale = gravityLevel;
        if (wasntBouncing == true)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 40));
        }
        if (Input.GetButtonDown("Jump"))
        {
            timesPressed++;
            if (timesPressed < 2)
            {
                jumpMultiplier++;
                jumpVelocity = 1 * jumpMultiplier;
                Debug.Log("Jump, " + jumpVelocity);
                if (jumpVelocity > 1)
                {
                    gravityLevel = gravityLevel * jumpVelocity /* * 0.5f*/;
                }
            }
        }
    }

    void ModeController()
    {
        if (bounce == true)
        {
            BounceMode();
        }
        if (rolling == true)
        {
            RollMode();
        }
    }

    void TempController()
    {
        if (Input.GetKeyDown("r"))
        {
            rolling = true;
            bounce = false;
        }
        if (Input.GetKeyDown("b"))
        {
            rolling = false;
            bounce = true;
        }
    }


    void OnCollisionEnter2D(Collision2D coll)
    {
        if (bounce == true)
        {
            gravityLevel = 1;
            if (coll.gameObject.tag == "Floor")
            {
                audioController.GetComponent<Audio>().BallBeat(jumpVelocity);
                if (!firstVelocityStored)
                {
                    //Debug.Log("poop");
                    initialVelocity = gameObject.GetComponent<Rigidbody2D>().velocity;
                    originalVelocity = initialVelocity;
                    Debug.Log("velocityO, " + originalVelocity);
                    firstVelocityStored = true;
                }
                if (jumpMultiplier == currentJumpMultiplier)
                {
                    //Debug.Log("It");
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
            if (!reset)
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
}
