using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GM : MonoBehaviour
{
    #region Variables
    [SerializeField]
    GameObject ball;

    [SerializeField]
    Text scoreText;

    [SerializeField]
    public float playerPoints = 0f;

    public static GM instance = null;
    #endregion

    // Use this for initialization
    void Awake ()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

    }

    void Update()
    {

    }

    public void PickupPoint()
    {
        //coinPickup.Play();
        
        //Debug.Log(playerPoints);
        scoreText.GetComponent<PulseScript>().Pulse();
        
        scoreText.text = "Score: " + playerPoints;
    }

    public void Victory()
    {

    }
}
