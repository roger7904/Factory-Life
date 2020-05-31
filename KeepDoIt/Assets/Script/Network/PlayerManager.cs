using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class PlayerManager : MonoBehaviourPunCallbacks
{
    public float health = 1f;
    //[SerializeField]
    public Text playerNameText;
    public Text teamText;

    void Start()
    {
        if(PrepareRoomManager.joinOrder==1 || PrepareRoomManager.joinOrder==2){
            teamText.text="A";
        }else{
            teamText.text="B";
        }
        playerNameText.text=this.photonView.Owner.NickName;
    }
}
