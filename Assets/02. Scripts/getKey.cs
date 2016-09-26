using UnityEngine;
using System.Collections;

public class getKey : MonoBehaviour {
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.tag=="Yeti" || other.transform.tag == "Girl")
        {
            GameObject.Find("Stage").GetComponent<Stage_Mgr>().maxKey--;
            //키 획득 애니메이션 추가
            Destroy(gameObject);
        }
    }
}
