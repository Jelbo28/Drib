using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{

    [SerializeField]
    float dampTime = 0.15f;

    Vector3 velocity = Vector3.zero;
    float cameraY;

    [SerializeField]
    Transform player;

    void Update()
    {
        
        if (player)
        {
            Vector3 point = gameObject.GetComponent<Camera>().WorldToViewportPoint(player.position);
            if (player.position.y < 0.5f)
            {
                cameraY = point.y;
            }
            else
            {
                cameraY = 0.5f;
            }
            Vector3 delta = player.position - gameObject.GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f, cameraY, point.z));
            Vector3 destination = transform.position + delta;
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
        }
    }
}