using UnityEngine;
using System.Collections;

public class VictoryCollider : MonoBehaviour
{
    [SerializeField]
    GameObject Aflag;

    [SerializeField]
    GameObject Cflag;

	void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            GM.instance.Victory();
            VictoryAnimation();
        }
    }

    void VictoryAnimation()
    {
        iTween.MoveTo(Aflag, iTween.Hash("position", new Vector3(Aflag.transform.position.x, Aflag.transform.position.y - 7.2f, Aflag.transform.position.z), "easetype", iTween.EaseType.linear, "time", 1.5f));
        iTween.MoveTo(Cflag, iTween.Hash("position", new Vector3(Cflag.transform.position.x, Cflag.transform.position.y - 7.2f, Cflag.transform.position.z), "easetype", iTween.EaseType.linear, "time", 1.5f));
        //Debug.Log("GOANIMATION");
        iTween.MoveTo(Cflag, iTween.Hash("position", new Vector3(Cflag.transform.position.x, Cflag.transform.position.y, Cflag.transform.position.z), "easetype", iTween.EaseType.linear, "time", 1.5f, "delay", 1.5f));
    }
}
