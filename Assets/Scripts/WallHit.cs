using UnityEngine;
using System.Collections;

public class WallHit : MonoBehaviour
{
	[SerializeField]
	Vector2 knockbackForce;


	void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
			coll.gameObject.GetComponentInParent<LevelScroll> ().enabled = false;
			coll.gameObject.GetComponent<Bounce> ().enabled = false;
			Time.timeScale = 0.01f;
			coll.gameObject.GetComponent<Rigidbody2D> ().AddForce (knockbackForce);
            Debug.Log("Hit");
        }
    }
}
