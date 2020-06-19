using System.Collections;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameRoomManager : MonoBehaviourPunCallbacks{
    public static GameRoomManager instance;
    public Transform[] spawnPoint;
    private PhotonView PV;  
    public Text timeText;
    private float timef;
    public GameObject prompt;
    public GameObject joy;
    public GameObject cast;
    private bool isend;
    public GameObject b_win;
    public GameObject g_win;
    public GameObject b_lose;
    public GameObject g_lose;
    public GameObject win;
    public GameObject lose;
    public GameObject ca;
    public Text nameText;
 
    public GameObject canvas;
    public GameObject b1;
    public GameObject b2;
    public GameObject b3;
    public GameObject b4;
    public GameObject b5;
    public GameObject b6;
    public GameObject b7;



    private string playerPrefName;
    void Start(){
        isend=false;
        prompt.SetActive(false);
        timef=300f;
        PV=GetComponent<PhotonView>();
        instance=this;
        playerPrefName=PlayerPrefs.GetString("character");
        GameObject playerGO=PhotonNetwork.Instantiate(playerPrefName,spawnPoint[PrepareRoomManager.joinOrder-1].position,spawnPoint[PrepareRoomManager.joinOrder-1].rotation,0);
        
        nameText.text=PlayerPrefs.GetString("playerName");
    }

    void Update(){
        
        if(isend){
            return;
        }
        if(timef<=0f){
            isend=true;
            if(CastbtnControl.teamApoint>CastbtnControl.teamBpoint){
                if(PrepareRoomManager.joinOrder==1 || PrepareRoomManager.joinOrder==2){
                    if(PlayerPrefs.GetString("character")=="boy"){
                        GameObject winGO=Instantiate(b_win,new Vector3(ca.transform.position.x,ca.transform.position.y-2.5f,0),ca.transform.rotation);
                        GameObject winimg=Instantiate(win,new Vector3(ca.transform.position.x,ca.transform.position.y+2f,0),ca.transform.rotation);
                        GameObject name=Instantiate(canvas,new Vector3(ca.transform.position.x,ca.transform.position.y,0),ca.transform.rotation);

                    }else{
                        GameObject winGO=Instantiate(g_win,new Vector3(ca.transform.position.x,ca.transform.position.y-2.5f,0),ca.transform.rotation);
                        GameObject winimg=Instantiate(win,new Vector3(ca.transform.position.x,ca.transform.position.y+2f,0),ca.transform.rotation);
                    }
                }else{
                    if(PlayerPrefs.GetString("character")=="boy"){
                        GameObject winGO=Instantiate(b_lose,new Vector3(ca.transform.position.x,ca.transform.position.y-2.5f,0),ca.transform.rotation);
                        GameObject loseimg=Instantiate(lose,new Vector3(ca.transform.position.x,ca.transform.position.y+2f,0),ca.transform.rotation);
                    }else{
                        GameObject winGO=Instantiate(g_lose,new Vector3(ca.transform.position.x,ca.transform.position.y-2.5f,0),ca.transform.rotation);
                        GameObject loseimg=Instantiate(lose,new Vector3(ca.transform.position.x,ca.transform.position.y+2f,0),ca.transform.rotation);
                    }
                }
            }else{
                if(PrepareRoomManager.joinOrder==1 || PrepareRoomManager.joinOrder==2){
                    if(PlayerPrefs.GetString("character")=="boy"){
                        GameObject winGO=Instantiate(b_lose,new Vector3(ca.transform.position.x,ca.transform.position.y-2.5f,0),ca.transform.rotation);
                        GameObject winimg=Instantiate(lose,new Vector3(ca.transform.position.x,ca.transform.position.y+2f,0),ca.transform.rotation);
                    }else{
                        GameObject winGO=Instantiate(g_lose,new Vector3(ca.transform.position.x,ca.transform.position.y-2.5f,0),ca.transform.rotation);
                        GameObject winimg=Instantiate(lose,new Vector3(ca.transform.position.x,ca.transform.position.y+2f,0),ca.transform.rotation);
                    }
                }else{
                    if(PlayerPrefs.GetString("character")=="boy"){
                        GameObject winGO=Instantiate(b_win,new Vector3(ca.transform.position.x,ca.transform.position.y-2.5f,0),ca.transform.rotation);
                        GameObject loseimg=Instantiate(win,new Vector3(ca.transform.position.x,ca.transform.position.y+2f,0),ca.transform.rotation);
                    }else{
                        GameObject winGO=Instantiate(g_win,new Vector3(ca.transform.position.x,ca.transform.position.y-1.5f,0),ca.transform.rotation);
                        GameObject loseimg=Instantiate(win,new Vector3(ca.transform.position.x,ca.transform.position.y+2f,0),ca.transform.rotation);
                    }
                }
                StartCoroutine (delay());
                joy.SetActive(false);
                cast.SetActive(false);
                
            }
        }
        if (PhotonNetwork.IsMasterClient){
            timef-=Time.deltaTime;
            PV.RPC("timeRPC", RpcTarget.OthersBuffered,timef);
        }
        //timeText.text=""+Mathf.RoundToInt(timef).ToString();
        timef = Mathf.Clamp(timef, 0f, Mathf.Infinity);

        timeText.text = string.Format("{0:00.00}", timef);
    }
    [PunRPC]
    void timeRPC(float t){
        timef=t;
    }
    IEnumerator delay()
    {
        yield return new WaitForSeconds (3f);
        PhotonNetwork.LeaveRoom();
    }
    
    public void runfun(){
        PlayerControl.run=true;
        StartCoroutine (delayrun());
    }
    IEnumerator delayrun()
    {
        yield return new WaitForSeconds (1f);
        PlayerControl.run=false;
    }
    // 玩家離開遊戲室時, 把他帶回到Lobby
    public override void OnLeftRoom(){
        SceneManager.LoadScene("TestHomepage");
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

    public void open(){
        prompt.SetActive(true);
        joy.SetActive(false);
        cast.SetActive(false);
    }

    public void close(){
        prompt.SetActive(false);
        joy.SetActive(true);
        cast.SetActive(true);
    }

    public void voidb1(){
        b1.SetActive(true);
        b2.SetActive(false);
        b3.SetActive(false);
        b4.SetActive(false);
        b5.SetActive(false);
        b6.SetActive(false);
        b7.SetActive(false);
    }
    public void voidb2(){
        b1.SetActive(false);
        b2.SetActive(true);
        b3.SetActive(false);
        b4.SetActive(false);
        b5.SetActive(false);
        b6.SetActive(false);
        b7.SetActive(false);
    }
    public void voidb3(){
        b1.SetActive(false);
        b2.SetActive(false);
        b3.SetActive(true);
        b4.SetActive(false);
        b5.SetActive(false);
        b6.SetActive(false);
        b7.SetActive(false);
    }
    public void voidb4(){
        b1.SetActive(false);
        b2.SetActive(false);
        b3.SetActive(false);
        b4.SetActive(true);
        b5.SetActive(false);
        b6.SetActive(false);
        b7.SetActive(false);
    }
    public void voidb5(){
        b1.SetActive(false);
        b2.SetActive(false);
        b3.SetActive(false);
        b4.SetActive(false);
        b5.SetActive(true);
        b6.SetActive(false);
        b7.SetActive(false);
    }
    public void voidb6(){
        b1.SetActive(false);
        b2.SetActive(false);
        b3.SetActive(false);
        b4.SetActive(false);
        b5.SetActive(false);
        b6.SetActive(true);
        b7.SetActive(false);
    }
    public void voidb7(){
        b1.SetActive(false);
        b2.SetActive(false);
        b3.SetActive(false);
        b4.SetActive(false);
        b5.SetActive(false);
        b6.SetActive(false);
        b7.SetActive(true);
    }
}

