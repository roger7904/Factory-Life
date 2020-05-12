using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CastbtnControl : MonoBehaviour
{
    private PhotonView PV;
    private Collider2D playerGOCollider;
    public GameObject cloth1_c;
    public GameObject cloth1_n;
    public GameObject cloth2_c;
    public GameObject cloth2_n;
    public GameObject cloth3_c;
    public GameObject cloth3_n;
    public GameObject cloth4_c;
    public GameObject cloth4_n;
    public GameObject cloth1_blue;
    public GameObject cloth1_green;
    public GameObject cloth1_red;
    public GameObject cloth2_blue;
    public GameObject cloth2_green;
    public GameObject cloth2_red;
    public GameObject cloth3_blue;
    public GameObject cloth3_green;
    public GameObject cloth3_red;
    public GameObject cloth4_blue;
    public GameObject cloth4_green;
    public GameObject cloth4_red;
    public GameObject cloth1_blue_c;
    public GameObject cloth1_green_c;
    public GameObject cloth1_red_c;
    public GameObject cloth2_blue_c;
    public GameObject cloth2_green_c;
    public GameObject cloth2_red_c;
    public GameObject cloth3_blue_c;
    public GameObject cloth3_green_c;
    public GameObject cloth3_red_c;
    public GameObject cloth4_blue_c;
    public GameObject cloth4_green_c;
    public GameObject cloth4_red_c;
    private GameObject playerGO;
    private GameObject insGO;


    void Start(){
        PV=GetComponent<PhotonView>();  
    }

    void Update(){
        playerGO = PhotonView.Find(PlayerControl.ID).gameObject;
    }
    public void cast(){
        playerGOCollider = playerGO.GetComponent<Collider2D>();
        playerGOCollider.enabled=false;
        Debug.Log("call cast function");
        
        RaycastHit2D[] hitarray=Physics2D.RaycastAll(playerGO.transform.position, PlayerControl.playerDirection,1f);

        //RaycastHit2D hit = Physics2D.Raycast(playerGO.transform.position, PlayerControl.playerDirection,1.5f);
        foreach (RaycastHit2D hit in hitarray)
        {
            if (hit.collider != null)
            {
                //Debug.Log("cast function hit "+hit.collider.name+" "+hit.collider.transform.tag);
                if(hit.collider.transform.tag=="Cloth1_take" && PlayerControl.status=="none"){
                    Debug.Log("cloth1_takefunction");
                    PlayerControl.status="cloth1";
                    PV.RPC("cloth1_takeRPC", RpcTarget.AllBuffered,PlayerControl.ID);
                }else if(hit.collider.transform.tag=="Cloth1" && PlayerControl.status=="none"){
                    Debug.Log("cloth1function");
                    PlayerControl.status="cloth1";
                    PV.RPC("cloth1RPC", RpcTarget.AllBuffered,PlayerControl.ID,hit.collider.name);
                }else if(hit.collider.transform.tag=="Cloth2_take" && PlayerControl.status=="none"){
                    Debug.Log("cloth2_takefunction");
                    PlayerControl.status="cloth2";
                    PV.RPC("cloth2_takeRPC", RpcTarget.AllBuffered,PlayerControl.ID);
                }else if(hit.collider.transform.tag=="Cloth2" && PlayerControl.status=="none"){
                    Debug.Log("cloth2function");
                    PlayerControl.status="cloth2";
                    PV.RPC("cloth2RPC", RpcTarget.AllBuffered,PlayerControl.ID,hit.collider.name);
                }else if(hit.collider.transform.tag=="Cloth3_take" && PlayerControl.status=="none"){
                    Debug.Log("cloth3_takefunction");
                    PlayerControl.status="cloth3";
                    PV.RPC("cloth3_takeRPC", RpcTarget.AllBuffered,PlayerControl.ID);
                }else if(hit.collider.transform.tag=="Cloth3" && PlayerControl.status=="none"){
                    Debug.Log("cloth3function");
                    PlayerControl.status="cloth3";
                    PV.RPC("cloth3RPC", RpcTarget.AllBuffered,PlayerControl.ID,hit.collider.name);
                }else if(hit.collider.transform.tag=="Cloth4_take" && PlayerControl.status=="none"){
                    Debug.Log("cloth4_takefunction");
                    PlayerControl.status="cloth4";
                    PV.RPC("cloth4_takeRPC", RpcTarget.AllBuffered,PlayerControl.ID);
                }else if(hit.collider.transform.tag=="Cloth4" && PlayerControl.status=="none"){
                    Debug.Log("cloth4function");
                    PlayerControl.status="cloth4";
                    PV.RPC("cloth4RPC", RpcTarget.AllBuffered,PlayerControl.ID,hit.collider.name);
                }else if(hit.collider.transform.tag=="Conveyor" && PlayerControl.status!="none"){
                        Debug.Log("conveyorfunction");
                        PlayerControl.status="none";
                        PV.RPC("conveyorRPC", RpcTarget.AllBuffered,PlayerControl.ID,hit.collider.transform.position,hit.collider.transform.rotation);
                }else if(hit.collider.transform.tag=="blue" && (PlayerControl.status=="cloth1" || PlayerControl.status=="cloth2" || PlayerControl.status=="cloth3" || PlayerControl.status=="cloth4")){
                    Debug.Log("bluefunction");
                    //PlayerControl.status="cloth4";
                    PV.RPC("blueRPC", RpcTarget.AllBuffered,PlayerControl.ID);
                }else if(hit.collider.transform.tag=="green" && (PlayerControl.status=="cloth1" || PlayerControl.status=="cloth2" || PlayerControl.status=="cloth3" || PlayerControl.status=="cloth4")){
                    Debug.Log("greenfunction");
                    //PlayerControl.status="cloth4";
                    PV.RPC("greenRPC", RpcTarget.AllBuffered,PlayerControl.ID);
                }else if(hit.collider.transform.tag=="red" && (PlayerControl.status=="cloth1" || PlayerControl.status=="cloth2" || PlayerControl.status=="cloth3" || PlayerControl.status=="cloth4")){
                    Debug.Log("redfunction");
                    //PlayerControl.status="cloth4";
                    PV.RPC("redRPC", RpcTarget.AllBuffered,PlayerControl.ID);
                }
            }
        }
        
        playerGOCollider.enabled=true;
    }

    [PunRPC]
    void cloth1_takeRPC(int parentViewId){
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        GameObject takeGO=Instantiate(cloth1_n,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+0.5f,parentObject.transform.position.z),parentObject.transform.rotation);

        takeGO.transform.parent=parentObject.transform;
    }

    [PunRPC]
    void cloth1RPC(int parentViewId,string GOname){
        Destroy(GameObject.Find(GOname).gameObject);
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        GameObject takeGO=Instantiate(cloth1_n,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+0.5f,parentObject.transform.position.z),parentObject.transform.rotation);

        takeGO.transform.parent=parentObject.transform;
    }

[PunRPC]
    void cloth2_takeRPC(int parentViewId){
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        GameObject takeGO=Instantiate(cloth2_n,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+0.5f,parentObject.transform.position.z),parentObject.transform.rotation);

        takeGO.transform.parent=parentObject.transform;
    }

    [PunRPC]
    void cloth2RPC(int parentViewId,string GOname){
        Destroy(GameObject.Find(GOname).gameObject);
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        GameObject takeGO=Instantiate(cloth2_n,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+0.5f,parentObject.transform.position.z),parentObject.transform.rotation);

        takeGO.transform.parent=parentObject.transform;
    }
    [PunRPC]
    void cloth3_takeRPC(int parentViewId){
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        GameObject takeGO=Instantiate(cloth3_n,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+0.5f,parentObject.transform.position.z),parentObject.transform.rotation);

        takeGO.transform.parent=parentObject.transform;
    }

    [PunRPC]
    void cloth3RPC(int parentViewId,string GOname){
        Destroy(GameObject.Find(GOname).gameObject);
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        GameObject takeGO=Instantiate(cloth3_n,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+0.5f,parentObject.transform.position.z),parentObject.transform.rotation);

        takeGO.transform.parent=parentObject.transform;
    }
    [PunRPC]
    void cloth4_takeRPC(int parentViewId){
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        GameObject takeGO=Instantiate(cloth4_n,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+0.5f,parentObject.transform.position.z),parentObject.transform.rotation);

        takeGO.transform.parent=parentObject.transform;
    }

    [PunRPC]
    void cloth4RPC(int parentViewId,string GOname){
        Destroy(GameObject.Find(GOname).gameObject);
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        GameObject takeGO=Instantiate(cloth4_n,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+0.5f,parentObject.transform.position.z),parentObject.transform.rotation);

        takeGO.transform.parent=parentObject.transform;
    }

    [PunRPC]
    void conveyorRPC(int parentViewId,Vector3 conveyorPosition,Quaternion conveyorRotation){
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        if(parentObject.GetComponent<Transform>().GetChild(1).gameObject.tag=="Cloth1"){
            insGO=cloth1_c;
        }else if(parentObject.GetComponent<Transform>().GetChild(1).gameObject.tag=="Cloth2"){
            insGO=cloth2_c;
        }else if(parentObject.GetComponent<Transform>().GetChild(1).gameObject.tag=="Cloth3"){
            insGO=cloth3_c;
        }else if(parentObject.GetComponent<Transform>().GetChild(1).gameObject.tag=="Cloth4"){
            insGO=cloth4_c;
        }else if(parentObject.GetComponent<Transform>().GetChild(1).gameObject.tag=="Cloth1_blue"){
            insGO=cloth1_blue_c;
        }else if(parentObject.GetComponent<Transform>().GetChild(1).gameObject.tag=="Cloth1_green"){
            insGO=cloth1_green_c;
        }else if(parentObject.GetComponent<Transform>().GetChild(1).gameObject.tag=="Cloth1_red"){
            insGO=cloth1_red_c;
        }else if(parentObject.GetComponent<Transform>().GetChild(1).gameObject.tag=="Cloth2_blue"){
            insGO=cloth2_blue_c;
        }else if(parentObject.GetComponent<Transform>().GetChild(1).gameObject.tag=="Cloth2_green"){
            insGO=cloth2_green_c;
        }else if(parentObject.GetComponent<Transform>().GetChild(1).gameObject.tag=="Cloth2_red"){
            insGO=cloth2_red_c;
        }else if(parentObject.GetComponent<Transform>().GetChild(1).gameObject.tag=="Cloth3_blue"){
            insGO=cloth3_blue_c;
        }else if(parentObject.GetComponent<Transform>().GetChild(1).gameObject.tag=="Cloth3_green"){
            insGO=cloth3_green_c;
        }else if(parentObject.GetComponent<Transform>().GetChild(1).gameObject.tag=="Cloth3_red"){
            insGO=cloth3_red_c;
        }else if(parentObject.GetComponent<Transform>().GetChild(1).gameObject.tag=="Cloth4_blue"){
            insGO=cloth4_blue_c;
        }else if(parentObject.GetComponent<Transform>().GetChild(1).gameObject.tag=="Cloth4_green"){
            insGO=cloth4_green_c;
        }else if(parentObject.GetComponent<Transform>().GetChild(1).gameObject.tag=="Cloth4_red"){
            insGO=cloth4_red_c;
        }
        Destroy(parentObject.GetComponent<Transform>().GetChild(1).gameObject);
        GameObject takeGO=Instantiate(insGO,conveyorPosition,conveyorRotation);
    }

    [PunRPC]
    void blueRPC(int parentViewId){
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        
        if(parentObject.GetComponent<Transform>().GetChild(1).gameObject.tag=="Cloth1"){
            insGO=cloth1_blue;
            PlayerControl.status="cloth1_blue";
        }else if(parentObject.GetComponent<Transform>().GetChild(1).gameObject.tag=="Cloth2"){
            insGO=cloth2_blue;
            PlayerControl.status="cloth2_blue";
        }else if(parentObject.GetComponent<Transform>().GetChild(1).gameObject.tag=="Cloth3"){
            insGO=cloth3_blue;
            PlayerControl.status="cloth3_blue";
        }
        else if(parentObject.GetComponent<Transform>().GetChild(1).gameObject.tag=="Cloth4"){
            insGO=cloth4_blue;
            PlayerControl.status="cloth4_blue";
        }
        Destroy(parentObject.GetComponent<Transform>().GetChild(1).gameObject);
        GameObject takeGO=Instantiate(insGO,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+0.5f,parentObject.transform.position.z),parentObject.transform.rotation);

        takeGO.transform.parent=parentObject.transform;
    }

    [PunRPC]
    void greenRPC(int parentViewId){
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        
        if(parentObject.GetComponent<Transform>().GetChild(1).gameObject.tag=="Cloth1"){
            insGO=cloth1_green;
            PlayerControl.status="cloth1_green";
        }else if(parentObject.GetComponent<Transform>().GetChild(1).gameObject.tag=="Cloth2"){
            insGO=cloth2_green;
            PlayerControl.status="cloth2_green";
        }else if(parentObject.GetComponent<Transform>().GetChild(1).gameObject.tag=="Cloth3"){
            insGO=cloth3_green;
            PlayerControl.status="cloth3_green";
        }
        else if(parentObject.GetComponent<Transform>().GetChild(1).gameObject.tag=="Cloth4"){
            insGO=cloth4_green;
            PlayerControl.status="cloth4_green";
        }
        Destroy(parentObject.GetComponent<Transform>().GetChild(1).gameObject);
        GameObject takeGO=Instantiate(insGO,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+0.5f,parentObject.transform.position.z),parentObject.transform.rotation);

        takeGO.transform.parent=parentObject.transform;
    }

    [PunRPC]
    void redRPC(int parentViewId){
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        
        if(parentObject.GetComponent<Transform>().GetChild(1).gameObject.tag=="Cloth1"){
            insGO=cloth1_red;
            PlayerControl.status="cloth1_red";
        }else if(parentObject.GetComponent<Transform>().GetChild(1).gameObject.tag=="Cloth2"){
            insGO=cloth2_red;
            PlayerControl.status="cloth2_red";
        }else if(parentObject.GetComponent<Transform>().GetChild(1).gameObject.tag=="Cloth3"){
            insGO=cloth3_red;
            PlayerControl.status="cloth3_red";
        }
        else if(parentObject.GetComponent<Transform>().GetChild(1).gameObject.tag=="Cloth4"){
            insGO=cloth4_red;
            PlayerControl.status="cloth4_red";
        }
        Destroy(parentObject.GetComponent<Transform>().GetChild(1).gameObject);
        GameObject takeGO=Instantiate(insGO,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+0.5f,parentObject.transform.position.z),parentObject.transform.rotation);

        takeGO.transform.parent=parentObject.transform;
    }
}

