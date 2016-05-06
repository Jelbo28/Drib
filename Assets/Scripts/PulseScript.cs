using UnityEngine;
using System.Collections;

public class PulseScript : MonoBehaviour
{
    void Update()
    {
        iTween.ScaleTo(this.gameObject, new Vector3(0.5f, 0.5f, 0f), 1f);
    }
    public void Pulse()
    {
        Debug.Log("Aram is amazing.");
        iTween.ScaleFrom(this.gameObject, new Vector3(0.6f,0.6f,0f), 1.5f);
    }
}
