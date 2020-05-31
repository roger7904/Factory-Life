using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RegisterManager : MonoBehaviour
{
    public InputField nameInput;
    private string nameString;

    // void Awake(){
    //     // 確保所有連線的玩家均載入相同的遊戲場景
    //     PhotonNetwork.AutomaticallySyncScene = true;
    // }

    void Start()
    {
        // if (PlayerPrefs.HasKey("playerName") && PlayerPrefs.HasKey("character")){
        //     SceneManager.LoadScene("TestHomepage");
        // }
    }

    public void Register(){
        nameString=nameInput.text;
        PlayerPrefs.SetString("playerName", nameString);
        SceneManager.LoadScene("TestHomepage");
    }

    public void ChooseCharacter1(){
        PlayerPrefs.SetString("character", "boy");
    }

    public void ChooseCharacter2(){
        PlayerPrefs.SetString("character", "girl");
    }
}
