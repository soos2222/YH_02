using UnityEngine;
using System.Collections;

public class touchDoor : MonoBehaviour
{
    bool Entered1 = false;
    bool Entered2 = false;

    void Update()
    {
        if (GameObject.Find("Stage").GetComponent<Stage_Mgr>().maxKey == 0)
        {
            if (Entered1 && Entered2)
            {
                Debug.Log("종료");
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Yeti")
            Entered1 = true;

        if (other.transform.tag == "Girl")
            Entered2 = true;
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform.tag == "Yeti")
            Entered1 = false;

        if (other.transform.tag == "Girl")
            Entered2 = false;
    }

}
