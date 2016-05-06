using UnityEngine;
using System.Collections;

public class WallHit : MonoBehaviour
{

	void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            Debug.Log("Hit");
        }
    }
}
