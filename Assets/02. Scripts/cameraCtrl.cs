using UnityEngine;
using System.Collections;

public class cameraCtrl : MonoBehaviour {

    public Transform m_TargetTransform1;
    public Transform m_TargetTransform2;
    public Vector2 m_LimitMinPos;
    public Vector2 m_LimitMaxPos;

    void Awake()
    {

    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        int Player = GameObject.Find("Stage").GetComponent<Stage_Mgr>().getPlayer();

        if (Player == 0 || Player == 1)
        {
            float posX = Mathf.Lerp(transform.position.x, m_TargetTransform1.position.x, 1 * Time.deltaTime);
            float posY = Mathf.Lerp(transform.position.y, m_TargetTransform1.position.y, 1 * Time.deltaTime);

            posX = Mathf.Clamp(posX, m_LimitMinPos.x, m_LimitMaxPos.x);
            posY = Mathf.Clamp(posY, m_LimitMinPos.y, m_LimitMaxPos.y);

            transform.position = new Vector3(posX, posY, -10.0f);
        }
        else if (Player == 2)
        {
            float posX = Mathf.Lerp(transform.position.x, m_TargetTransform2.position.x, 1 * Time.deltaTime);
            float posY = Mathf.Lerp(transform.position.y, m_TargetTransform2.position.y, 1 * Time.deltaTime);

            posX = Mathf.Clamp(posX, m_LimitMinPos.x, m_LimitMaxPos.x);
            posY = Mathf.Clamp(posY, m_LimitMinPos.y, m_LimitMaxPos.y);

            transform.position = new Vector3(posX, posY, -10.0f);
        }

    }

}
