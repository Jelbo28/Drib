using UnityEngine;
using System.Collections;

public class Bounce : MonoBehaviour
{

    #region Variables
    [SerializeField]
    PhysicsMaterial2D rolly;
    [SerializeField]
    PhysicsMaterial2D bouncy;

    bool firstVelocityStored = false;
    bool reset = false;

    Vector2 initialVelocity;
    Vector2 originalVelocity;

    int jumpMultiplier = 1;
    int currentJumpMultiplier = 1;
    int timesPressed = 0;

    bool rolling = false;

    float jumpVelocity = 0f;
    float gravityLevel = 1f;
    #endregion

    void Update()
    {
        BounceMode();
        RollMode();
    }

    void RollMode()
    {
        if (Input.GetKeyDown("a") && rolling == false)
        {
            gameObject.GetComponent<CircleCollider2D>().sharedMaterial = rolly;
            gameObject.GetComponent<Bounce>().enabled = false;
            iTween.RotateBy(gameObject, iTween.Hash("z", -1f, "easetype", "linear", "looptype", iTween.LoopType.loop));
            rolling = true;
        }
        if (Input.GetKeyDown("a") && rolling == true)
        {
            gameObject.GetComponent<CircleCollider2D>().sharedMaterial = bouncy;
            gameObject.GetComponent<Bounce>().enabled = true;
            rolling = false;
        }
    }

    void BounceMode()
    {
        gameObject.GetComponent<Rigidbody2D>().gravityScale = gravityLevel;
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


    void OnCollisionEnter2D(Collision2D coll)
    {
        gravityLevel = 1;
        if (coll.gameObject.tag == "Floor")
        {
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
