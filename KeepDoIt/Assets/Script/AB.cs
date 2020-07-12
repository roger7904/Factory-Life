using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class AB : MonoBehaviour
{
    public Text t1;
    public Text t2;
    public Text t3;
    public Text t4;
    private string name1;
    private string name2;
    private string name3;
    private string name4;
    private PhotonView PV;
    // Start is called before the first frame update
    void Start(){
        PV=GetComponent<PhotonView>();
    }
    void Update(){
        
        Debug.Log(PlayerPrefs.GetString("playerName"));
        if(PrepareRoomManager.joinOrder==1){
            PV.RPC("name1RPC", RpcTarget.AllBuffered,PlayerPrefs.GetString("playerName"));
        }else if(PrepareRoomManager.joinOrder==2){
            PV.RPC("name2RPC", RpcTarget.AllBuffered,PlayerPrefs.GetString("playerName"));
        }else if(PrepareRoomManager.joinOrder==3){
            PV.RPC("name3RPC", RpcTarget.AllBuffered,PlayerPrefs.GetString("playerName"));
        }else if(PrepareRoomManager.joinOrder==4){
            PV.RPC("name4RPC", RpcTarget.AllBuffered,PlayerPrefs.GetString("playerName"));
        }
        t1.text=name1;
        t2.text=name2;
        t3.text=name3;
        t4.text=name4;
    }
    
    [PunRPC]
    void name1RPC(string name){
        name1=name;
    }

    [PunRPC]
    void name2RPC(string name){
        name2=name;
    }

    [PunRPC]
    void name3RPC(string name){
        name3=name;
    }

    [PunRPC]
    void name4RPC(string name){
        name4=name;
    }
}
