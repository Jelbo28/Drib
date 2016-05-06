using UnityEngine;
using System.Collections;

public class LevelScroll : MonoBehaviour
{

    [SerializeField]
    float scrollSpeed = 1f;


    void Update()
    {
        transform.Translate(Vector2.right * scrollSpeed * Time.deltaTime);
    }
}
