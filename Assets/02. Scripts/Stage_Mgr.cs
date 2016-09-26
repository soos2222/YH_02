using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D;
using UnityEngine.UI;

public class Stage_Mgr : MonoBehaviour
{
    enum PlayMode
    {
        Both,
        only1P,
        only2P
    }

    int Player = (int)PlayMode.Both;

    public GameObject _SModeButton;
    public GameObject _1PModeButton;
    public GameObject _2PModeButton;
    public GameObject Girl;
    public GameObject Yeti;
    public Text AttackButtonText;
    private Vector3 temp;
    public int maxKey = 1;

    public void Update()
    {
        
        Freeze();

        AttackButtonText.GetComponent<Text>().text = "Attack";

        float X = Mathf.Abs(Girl.transform.position.x - Yeti.transform.position.x);
        float Y = Mathf.Abs(Girl.transform.position.y - Yeti.transform.position.y);

        if (X < 2 && Y < 0.5) // 둘 차이가 많이 안날 때만 join 가능
        {

            if (Player == 1 && Girl.GetComponent<Platformer2DUserControl>().joinable)
            {
                AttackButtonText.GetComponent<Text>().text = "Join";
                if (Girl.GetComponent<Platformer2DUserControl>().m_Attack)
                    Join();

            }
            if (Player == 2 && Yeti.GetComponent<Platformer2DUserControl>().joinable)
            {
                AttackButtonText.GetComponent<Text>().text = "Join";
                if (Yeti.GetComponent<Platformer2DUserControl>().m_Attack)
                    Join();
            }
        }
    }

    public void S_Clicked() //분리 버튼을 눌렀을 때 자동으로 1P
    {
        _SModeButton.SetActive(false);
        _1PModeButton.SetActive(false);
        _2PModeButton.SetActive(true);
        Player = (int)PlayMode.only1P;
        Girl.GetComponent<Platformer2DUserControl>().enabled = true;
        Yeti.GetComponent<Platformer2DUserControl>().enabled = false;
        temp = Yeti.transform.position;
    }
    public void only1P_Clicked()    //1P 버튼을 눌렀을 때
    {
        _1PModeButton.SetActive(false);
        _2PModeButton.SetActive(true);
        Player = (int)PlayMode.only1P;
        Girl.GetComponent<Platformer2DUserControl>().enabled = true;
        Yeti.GetComponent<Platformer2DUserControl>().enabled = false;
        temp = Yeti.transform.position;
    }
    public void only2P_Clicked()    //2P 버튼을 눌렀을 때
    {
        _1PModeButton.SetActive(true);
        _2PModeButton.SetActive(false);
        Player = (int)PlayMode.only2P;
        Girl.GetComponent<Platformer2DUserControl>().enabled = false;
        Yeti.GetComponent<Platformer2DUserControl>().enabled = true;
        temp = Girl.transform.position;

    }
    public void Join()
    {
        _SModeButton.SetActive(true);
        _1PModeButton.SetActive(false);
        _2PModeButton.SetActive(false);
        Player = (int)PlayMode.Both;
        Girl.GetComponent<Platformer2DUserControl>().enabled = true;
        Yeti.GetComponent<Platformer2DUserControl>().enabled = true;


        Yeti.transform.position = new Vector2(Girl.transform.position.x - (float)2, Girl.transform.position.y);
    }
    public int getPlayer()
    {
        return Player;
    }
    public void Freeze()
    {
        if (Player == 1)
        {
            Yeti.transform.position = temp;
        }
        if (Player == 2)
        {
            Girl.transform.position = temp;
        }
    }
}
