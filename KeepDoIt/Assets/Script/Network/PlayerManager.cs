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
 

    void Start()
    {
       
        
        playerNameText.text=this.photonView.Owner.NickName;
    }
}
