﻿using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PrepareRoomManager : MonoBehaviourPunCallbacks{
    public static PrepareRoomManager instance;
    private string playerPrefName;
    public Transform[] spawnPoint; 
    public GameObject startButton;
    public static int joinOrder;

    void Start(){
        instance=this;
        playerPrefName=PlayerPrefs.GetString("character");
        joinOrder=PhotonNetwork.CurrentRoom.PlayerCount;
        GameObject playerGO=PhotonNetwork.Instantiate(playerPrefName,spawnPoint[PrepareRoomManager.joinOrder-1].position,spawnPoint[PrepareRoomManager.joinOrder-1].rotation,0);
        //playerGO.transform.localScale=new Vector3(10,10,10);
        startButton.SetActive(true);
    }
    // 玩家離開遊戲室時, 把他帶回到Lobby
    public override void OnLeftRoom(){
        SceneManager.LoadScene(0);
    } 
    public void LeaveRoom(){
        PhotonNetwork.LeaveRoom();
    }

    // void LoadArena(){
    //     PhotonNetwork.LoadLevel("GameRoom1");
    // }
    
    public override void OnPlayerEnteredRoom(Player other){
        Debug.Log(other.NickName+"進入遊戲室");
        Debug.Log("玩家數為"+PhotonNetwork.CurrentRoom.PlayerCount);
        if(PhotonNetwork.IsMasterClient && PhotonNetwork.CurrentRoom.PlayerCount==4){
            startButton.SetActive(true);
        }
        // if (PhotonNetwork.IsMasterClient)
        // {
        //     Debug.LogFormat("我是 Master Client 嗎? {0}",PhotonNetwork.IsMasterClient);
        //     LoadArena();
        // }
    }
    //動態偵測玩家進入或離開(可能不會用到)
    public override void OnPlayerLeftRoom(Player other){
        Debug.Log(other.NickName+"離開遊戲室");
        // if (PhotonNetwork.IsMasterClient){
        //     Debug.LogFormat("我是 Master Client 嗎? {0}",PhotonNetwork.IsMasterClient);
        //     LoadArena();
        // }
    }
    public void LoadGameScene(){
        PhotonNetwork.LoadLevel("GameRoom");
    }
}

