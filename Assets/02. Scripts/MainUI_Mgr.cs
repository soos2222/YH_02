using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainUI_Mgr : MonoBehaviour {
    private int Gem = 0;
    private int Coin = 0;
    private int maxHeart = 10;
    private int Heart = 10;
    private System.DateTime Last_Time = System.DateTime.Now;    
    //private System.TimeSpan default_ts = new System.TimeSpan(0, 20, 0);
    private System.TimeSpan default_ts = new System.TimeSpan(0, 0, 10); //Test를 위해 임시로 10초로 설정  

    public Text Text_Gem;
    public Text Text_Coin;
    public Text Text_Heart;
    public Text Text_Time;

    void Awake()
    {
        SceneManager.LoadScene("scLobby", LoadSceneMode.Additive);
    }

    void Start () {    
        //PlayerPrefs으로 저장해서 값 불러오지만 추후 데이터베이스화 또는 암호화로 변경해야한다 보안성이 없음
        if (PlayerPrefs.HasKey("PLAYER_GEM"))
            Gem = PlayerPrefs.GetInt("PLAYER_GEM");
        if (PlayerPrefs.HasKey("PLAYER_COIN"))
            Coin = PlayerPrefs.GetInt("PLAYER_COIN");
        if(PlayerPrefs.HasKey("PLAYER_HEART"))
            Heart = PlayerPrefs.GetInt("PLAYER_HEART");
        if (PlayerPrefs.HasKey("LAST_TIME"))
            Last_Time = System.Convert.ToDateTime(PlayerPrefs.GetString("LAST_TIME"));

        DispGEM(0);
        DispCoin(0);
        DispHeart(0);        
    }

    //Gem 조정 같은이유로 PlayerPrefs 수정
    //Gem 값을 디스플레이해주며 값을 조정할 수 있는함수
    public void DispGEM(int gem)
    {
        Gem += gem;
        Text_Gem.text = Gem.ToString("#,##0");

        PlayerPrefs.SetInt("PLAYER_GEM", Gem);
    }

    //Coin 조정 같은이유로 PlayerPrefs 수정
    //Coin 값을 디스플레이해주며 값을 조정할 수 있는함수
    public void DispCoin(int coin)
    {
        Coin += coin;
        Text_Coin.text = Coin.ToString("#,##0"); 

        PlayerPrefs.SetInt("PLAYER_COIN", Coin);
    }

    //Heart 조정 같은이유로 PlayerPrefs 수정
    //Heart 값을 디스플레이해주며 값을 조정할 수 있는함수
    public void DispHeart(int heart)
    {
        Heart += heart;
        
        Text_Heart.text = Heart.ToString() + " / " + maxHeart.ToString();
        
        if ((heart > 0 && Heart < maxHeart) || (heart < 0 && Heart == maxHeart-1))
        {
            PlayerPrefs.SetString("LAST_TIME", System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
            Last_Time = System.Convert.ToDateTime(PlayerPrefs.GetString("LAST_TIME"));
        }

        PlayerPrefs.SetInt("PLAYER_HEART", Heart);
    }

    void Update()
    {
        if (Heart < maxHeart) //재충전을 위해 남은시간을 보여주는 부분
        {            
            System.TimeSpan ts = default_ts - System.DateTime.Now.Subtract(Last_Time);

            Text_Time.text = ts.Minutes.ToString() + ":" + ts.Seconds.ToString();

            if (ts.CompareTo(new System.TimeSpan(0, 0, 0))<0) //재충전 시간이 되었을 경우 하트를 보충
            {
                int plus_Heart = (int)ts.TotalSeconds * -1 / 10 + 1; //Test를 위해 임시로 10초로 설정 20분 설정시 10을 1200으로 변경

                if (plus_Heart + Heart > maxHeart)
                    plus_Heart = maxHeart - Heart;
                 
                DispHeart(plus_Heart);  
            }
        }
        else
            Text_Time.text = "MAX";
    }

    //임시로 재충전을 테스트하기위한 함수로 추후 삭제, 현재 하트 옆 +에 연결
    public void temp()
    {
        if(Heart>0)
            DispHeart(-1);
    }
}
