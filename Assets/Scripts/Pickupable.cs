using UnityEngine;
using System.Collections;

public class Pickupable : MonoBehaviour
{
    [SerializeField]
    GameObject audioController;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Debug.Log("Coin");
            audioController.GetComponent<Audio>().CoinBlip();
            switch (this.tag)
            {
                case "BluePoof":
                    GM.instance.playerPoints += 1f;
                    GM.instance.PickupPoint();
                    //Debug.Log("Coin");
                    break;
            }
        }
        Destroy(gameObject);
    }
}
