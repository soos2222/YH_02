using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameRoom_Mgr : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void BacktoLobbyBtn()
    {
        SceneManager.UnloadScene("scGameRoom");
        SceneManager.LoadSceneAsync("scLobby", LoadSceneMode.Additive);       
    }

	public void StageSelect_01_Btn()
	{
        SceneManager.UnloadScene("scMainUI");
        SceneManager.UnloadScene("scGameRoom");
        SceneManager.LoadScene("scStage01");
		//Destroy (GameObject.Find ("Canvas"));
		//Destroy(GameObject.Find("Main Camera"));
	}
}
