using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CastbtnControl : MonoBehaviour
{
    private RaycastHit2D[] hitarray;
    private string status;
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
        status="none";
    }
    void Update(){
        playerGO = PhotonView.Find(PlayerControl.ID).gameObject;
    }
    public void cast(){
        playerGOCollider = playerGO.GetComponent<Collider2D>();
        playerGOCollider.enabled=false;
        Debug.Log("call cast function statis:"+status);
        if(PlayerControl.playerDirection==Vector2.down){
            hitarray=Physics2D.RaycastAll(playerGO.transform.position, PlayerControl.playerDirection,1.2f);
        }else{
            hitarray=Physics2D.RaycastAll(playerGO.transform.position, PlayerControl.playerDirection,1f);
        }
        foreach (RaycastHit2D hit in hitarray)
        {
            if (hit.collider != null)
            {
                if(hit.collider.transform.tag=="Cloth1_take" && status=="none"){
                    status="cloth1";
                    PV.RPC("cloth1_takeRPC", RpcTarget.AllBuffered,PlayerControl.ID);
                }else if(hit.collider.transform.tag=="Cloth1" && status=="none"){
                    status="cloth1";
                    PV.RPC("cloth1RPC", RpcTarget.AllBuffered,PlayerControl.ID,hit.collider.name);
                }else if(hit.collider.transform.tag=="Cloth2_take" && status=="none"){
                    status="cloth2";
                    PV.RPC("cloth2_takeRPC", RpcTarget.AllBuffered,PlayerControl.ID);
                }else if(hit.collider.transform.tag=="Cloth2" && status=="none"){
                    status="cloth2";
                    PV.RPC("cloth2RPC", RpcTarget.AllBuffered,PlayerControl.ID,hit.collider.name);
                }else if(hit.collider.transform.tag=="Cloth3_take" && status=="none"){
                    status="cloth3";
                    PV.RPC("cloth3_takeRPC", RpcTarget.AllBuffered,PlayerControl.ID);
                }else if(hit.collider.transform.tag=="Cloth3" && status=="none"){
                    status="cloth3";
                    PV.RPC("cloth3RPC", RpcTarget.AllBuffered,PlayerControl.ID,hit.collider.name);
                }else if(hit.collider.transform.tag=="Cloth4_take" && status=="none"){
                    status="cloth4";
                    PV.RPC("cloth4_takeRPC", RpcTarget.AllBuffered,PlayerControl.ID);
                }else if(hit.collider.transform.tag=="Cloth4" && status=="none"){
                    status="cloth4";
                    PV.RPC("cloth4RPC", RpcTarget.AllBuffered,PlayerControl.ID,hit.collider.name);
                }else if(hit.collider.transform.tag=="Conveyor" && status!="none"){
                    status="none";
                    PV.RPC("conveyorRPC", RpcTarget.AllBuffered,PlayerControl.ID,hit.collider.transform.position,hit.collider.transform.rotation);
                }else if(hit.collider.transform.tag=="Cloth1_blue" && status=="none"){
                    status="cloth1_blue";
                    PV.RPC("cloth1_blueRPC", RpcTarget.AllBuffered,PlayerControl.ID,hit.collider.name);
                }else if(hit.collider.transform.tag=="Cloth1_green" &&  status=="none"){
                    status="cloth1_green";
                    PV.RPC("cloth1_greenRPC", RpcTarget.AllBuffered,PlayerControl.ID,hit.collider.name);
                }else if(hit.collider.transform.tag=="Cloth1_red" && status=="none"){
                    status="cloth1_red";
                    PV.RPC("cloth1_redRPC", RpcTarget.AllBuffered,PlayerControl.ID,hit.collider.name);
                }else if(hit.collider.transform.tag=="Cloth2_blue" && status=="none"){
                    status="cloth2_blue";
                    PV.RPC("cloth2_blueRPC", RpcTarget.AllBuffered,PlayerControl.ID,hit.collider.name);
                }else if(hit.collider.transform.tag=="Cloth2_green" &&  status=="none"){
                    PV.RPC("cloth2_greenRPC", RpcTarget.AllBuffered,PlayerControl.ID,hit.collider.name);
                }else if(hit.collider.transform.tag=="Cloth2_red" && status=="none"){
                    status="cloth2_red";
                    PV.RPC("cloth2_redRPC", RpcTarget.AllBuffered,PlayerControl.ID,hit.collider.name);
                }else if(hit.collider.transform.tag=="Cloth3_blue" && status=="none"){
                    status="cloth3_blue";
                    PV.RPC("cloth3_blueRPC", RpcTarget.AllBuffered,PlayerControl.ID,hit.collider.name);
                }else if(hit.collider.transform.tag=="Cloth3_green" &&  status=="none"){
                    status="cloth3_green";
                    PV.RPC("cloth3_greenRPC", RpcTarget.AllBuffered,PlayerControl.ID,hit.collider.name);
                }else if(hit.collider.transform.tag=="Cloth3_red" && status=="none"){
                    status="cloth3_red";
                    PV.RPC("cloth3_redRPC", RpcTarget.AllBuffered,PlayerControl.ID,hit.collider.name);
                }else if(hit.collider.transform.tag=="Cloth4_blue" && status=="none"){
                    status="cloth4_blue";
                    PV.RPC("cloth4_blueRPC", RpcTarget.AllBuffered,PlayerControl.ID,hit.collider.name);
                }else if(hit.collider.transform.tag=="Cloth4_green" &&  status=="none"){
                    status="cloth4_green";
                    PV.RPC("cloth4_greenRPC", RpcTarget.AllBuffered,PlayerControl.ID,hit.collider.name);
                }else if(hit.collider.transform.tag=="Cloth4_red" && status=="none"){
                    status="cloth4_red";
                    PV.RPC("cloth4_redRPC", RpcTarget.AllBuffered,PlayerControl.ID,hit.collider.name);
                }else if(hit.collider.transform.tag=="blue" && status=="cloth1"){
                    status="cloth1_blue";
                    PV.RPC("blueyeing1RPC", RpcTarget.AllBuffered,PlayerControl.ID);
                }else if(hit.collider.transform.tag=="blue" && status=="cloth2"){
                    status="cloth2_blue";
                    PV.RPC("blueyeing2RPC", RpcTarget.AllBuffered,PlayerControl.ID);
                }else if(hit.collider.transform.tag=="blue" && status=="cloth3"){
                    status="cloth3_blue";
                    PV.RPC("blueyeing3RPC", RpcTarget.AllBuffered,PlayerControl.ID);
                }else if(hit.collider.transform.tag=="blue" && status=="cloth4"){
                    status="cloth4_blue";
                    PV.RPC("blueyeing4RPC", RpcTarget.AllBuffered,PlayerControl.ID);
                }else if(hit.collider.transform.tag=="green" && status=="cloth1"){
                    status="cloth1_green";
                    PV.RPC("greenyeing1RPC", RpcTarget.AllBuffered,PlayerControl.ID);
                }else if(hit.collider.transform.tag=="green" && status=="cloth2"){
                    status="cloth2_green";
                    PV.RPC("greenyeing2RPC", RpcTarget.AllBuffered,PlayerControl.ID);
                }else if(hit.collider.transform.tag=="green" && status=="cloth3"){
                    status="cloth3_green";
                    PV.RPC("greenyeing3RPC", RpcTarget.AllBuffered,PlayerControl.ID);
                }else if(hit.collider.transform.tag=="green" && status=="cloth4"){
                    status="cloth4_green";
                    PV.RPC("greenyeing4RPC", RpcTarget.AllBuffered,PlayerControl.ID);
                }else if(hit.collider.transform.tag=="red" && status=="cloth1"){
                    status="cloth1_red";
                    PV.RPC("redyeing1RPC", RpcTarget.AllBuffered,PlayerControl.ID);
                }else if(hit.collider.transform.tag=="red" && status=="cloth2"){
                    status="cloth2_red";
                    PV.RPC("redyeing2RPC", RpcTarget.AllBuffered,PlayerControl.ID);
                }else if(hit.collider.transform.tag=="red" && status=="cloth3"){
                    status="cloth3_red";
                    PV.RPC("redyeing3RPC", RpcTarget.AllBuffered,PlayerControl.ID);
                }else if(hit.collider.transform.tag=="red" && status=="cloth4"){
                    status="cloth4_red";
                    PV.RPC("redyeing4RPC", RpcTarget.AllBuffered,PlayerControl.ID);
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
        if(parentObject.GetComponent<Transform>().childCount>1){
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
        }
        if(parentObject.GetComponent<Transform>().childCount>1){
            Destroy(parentObject.GetComponent<Transform>().GetChild(1).gameObject);
        }
        GameObject takeGO=Instantiate(insGO,new Vector3(conveyorPosition.x+0.1f,conveyorPosition.y,conveyorPosition.z) ,conveyorRotation);
    }
    [PunRPC]
    void blueyeing1RPC(int parentViewId){
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        insGO=cloth1_blue;
        if(parentObject.GetComponent<Transform>().childCount>1){
            Destroy(parentObject.GetComponent<Transform>().GetChild(1).gameObject);
        }
        GameObject takeGO=Instantiate(insGO,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+0.5f,parentObject.transform.position.z),parentObject.transform.rotation);
        takeGO.transform.parent=parentObject.transform;
    }
    [PunRPC]
    void blueyeing2RPC(int parentViewId){
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        insGO=cloth2_blue;
        if(parentObject.GetComponent<Transform>().childCount>1){
            Destroy(parentObject.GetComponent<Transform>().GetChild(1).gameObject);
        }
        GameObject takeGO=Instantiate(insGO,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+0.5f,parentObject.transform.position.z),parentObject.transform.rotation);
        takeGO.transform.parent=parentObject.transform;
    }
    [PunRPC]
    void blueyeing3RPC(int parentViewId){
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        insGO=cloth3_blue;
        if(parentObject.GetComponent<Transform>().childCount>1){
            Destroy(parentObject.GetComponent<Transform>().GetChild(1).gameObject);
        }
        GameObject takeGO=Instantiate(insGO,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+0.5f,parentObject.transform.position.z),parentObject.transform.rotation);
        takeGO.transform.parent=parentObject.transform;
    }
    [PunRPC]
    void blueyeing4RPC(int parentViewId){
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        insGO=cloth4_blue;
        if(parentObject.GetComponent<Transform>().childCount>1){
            Destroy(parentObject.GetComponent<Transform>().GetChild(1).gameObject);
        }
        GameObject takeGO=Instantiate(insGO,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+0.5f,parentObject.transform.position.z),parentObject.transform.rotation);
        takeGO.transform.parent=parentObject.transform;
    }
    [PunRPC]
    void redyeing1RPC(int parentViewId){
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        insGO=cloth1_red;
        if(parentObject.GetComponent<Transform>().childCount>1){
            Destroy(parentObject.GetComponent<Transform>().GetChild(1).gameObject);
        }
        GameObject takeGO=Instantiate(insGO,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+0.5f,parentObject.transform.position.z),parentObject.transform.rotation);
        takeGO.transform.parent=parentObject.transform;
    }
    [PunRPC]
    void redyeing2RPC(int parentViewId){
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        insGO=cloth2_red;
        if(parentObject.GetComponent<Transform>().childCount>1){
            Destroy(parentObject.GetComponent<Transform>().GetChild(1).gameObject);
        }
        GameObject takeGO=Instantiate(insGO,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+0.5f,parentObject.transform.position.z),parentObject.transform.rotation);
        takeGO.transform.parent=parentObject.transform;
    }
    [PunRPC]
    void redyeing3RPC(int parentViewId){
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        insGO=cloth3_red;
        if(parentObject.GetComponent<Transform>().childCount>1){
            Destroy(parentObject.GetComponent<Transform>().GetChild(1).gameObject);
        }
        GameObject takeGO=Instantiate(insGO,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+0.5f,parentObject.transform.position.z),parentObject.transform.rotation);
        takeGO.transform.parent=parentObject.transform;
    }
    [PunRPC]
    void redyeing4RPC(int parentViewId){
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        insGO=cloth4_red;
        if(parentObject.GetComponent<Transform>().childCount>1){
            Destroy(parentObject.GetComponent<Transform>().GetChild(1).gameObject);
        }
        GameObject takeGO=Instantiate(insGO,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+0.5f,parentObject.transform.position.z),parentObject.transform.rotation);
        takeGO.transform.parent=parentObject.transform;
    }
    [PunRPC]
    void greenyeing1RPC(int parentViewId){
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        insGO=cloth1_green;
        if(parentObject.GetComponent<Transform>().childCount>1){
            Destroy(parentObject.GetComponent<Transform>().GetChild(1).gameObject);
        }
        GameObject takeGO=Instantiate(insGO,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+0.5f,parentObject.transform.position.z),parentObject.transform.rotation);
        takeGO.transform.parent=parentObject.transform;
    }
    [PunRPC]
    void greenyeing2RPC(int parentViewId){
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        insGO=cloth2_green;
        if(parentObject.GetComponent<Transform>().childCount>1){
            Destroy(parentObject.GetComponent<Transform>().GetChild(1).gameObject);
        }
        GameObject takeGO=Instantiate(insGO,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+0.5f,parentObject.transform.position.z),parentObject.transform.rotation);
        takeGO.transform.parent=parentObject.transform;
    }
    [PunRPC]
    void greenyeing3RPC(int parentViewId){
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        insGO=cloth3_green;
        if(parentObject.GetComponent<Transform>().childCount>1){
            Destroy(parentObject.GetComponent<Transform>().GetChild(1).gameObject);
        }
        GameObject takeGO=Instantiate(insGO,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+0.5f,parentObject.transform.position.z),parentObject.transform.rotation);
        takeGO.transform.parent=parentObject.transform;
    }
    [PunRPC]
    void greenyeing4RPC(int parentViewId){
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        insGO=cloth4_green;
        if(parentObject.GetComponent<Transform>().childCount>1){
            Destroy(parentObject.GetComponent<Transform>().GetChild(1).gameObject);
        }
        GameObject takeGO=Instantiate(insGO,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+0.5f,parentObject.transform.position.z),parentObject.transform.rotation);
        takeGO.transform.parent=parentObject.transform;
    }
    [PunRPC]
    void cloth1_blueRPC(int parentViewId,string GOname){
        Destroy(GameObject.Find(GOname).gameObject);
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        GameObject takeGO=Instantiate(cloth1_blue,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+0.5f,parentObject.transform.position.z),parentObject.transform.rotation);
        takeGO.transform.parent=parentObject.transform;
    }
    [PunRPC]
    void cloth1_greenRPC(int parentViewId,string GOname){
        Destroy(GameObject.Find(GOname).gameObject);
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        GameObject takeGO=Instantiate(cloth1_green,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+0.5f,parentObject.transform.position.z),parentObject.transform.rotation);
        takeGO.transform.parent=parentObject.transform;
    }
    [PunRPC]
    void cloth1_redRPC(int parentViewId,string GOname){
        Destroy(GameObject.Find(GOname).gameObject);
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        GameObject takeGO=Instantiate(cloth1_red,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+0.5f,parentObject.transform.position.z),parentObject.transform.rotation);
        takeGO.transform.parent=parentObject.transform;
    }
    [PunRPC]
    void cloth2_blueRPC(int parentViewId,string GOname){
        Destroy(GameObject.Find(GOname).gameObject);
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        GameObject takeGO=Instantiate(cloth2_blue,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+0.5f,parentObject.transform.position.z),parentObject.transform.rotation);
        takeGO.transform.parent=parentObject.transform;
    }
    [PunRPC]
    void cloth2_greenRPC(int parentViewId,string GOname){
        Destroy(GameObject.Find(GOname).gameObject);
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        GameObject takeGO=Instantiate(cloth2_green,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+0.5f,parentObject.transform.position.z),parentObject.transform.rotation);
        takeGO.transform.parent=parentObject.transform;
    }
    [PunRPC]
    void cloth2_redRPC(int parentViewId,string GOname){
        Destroy(GameObject.Find(GOname).gameObject);
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        GameObject takeGO=Instantiate(cloth2_red,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+0.5f,parentObject.transform.position.z),parentObject.transform.rotation);
        takeGO.transform.parent=parentObject.transform;
    }
    [PunRPC]
    void cloth3_blueRPC(int parentViewId,string GOname){
        Destroy(GameObject.Find(GOname).gameObject);
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        GameObject takeGO=Instantiate(cloth3_blue,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+0.5f,parentObject.transform.position.z),parentObject.transform.rotation);
        takeGO.transform.parent=parentObject.transform;
    }
    [PunRPC]
    void cloth3_greenRPC(int parentViewId,string GOname){
        Destroy(GameObject.Find(GOname).gameObject);
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        GameObject takeGO=Instantiate(cloth3_green,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+0.5f,parentObject.transform.position.z),parentObject.transform.rotation);
        takeGO.transform.parent=parentObject.transform;
    }
    [PunRPC]
    void cloth3_redRPC(int parentViewId,string GOname){
        Destroy(GameObject.Find(GOname).gameObject);
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        GameObject takeGO=Instantiate(cloth3_red,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+0.5f,parentObject.transform.position.z),parentObject.transform.rotation);
        takeGO.transform.parent=parentObject.transform;
    }
    [PunRPC]
    void cloth4_blueRPC(int parentViewId,string GOname){
        Destroy(GameObject.Find(GOname).gameObject);
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        GameObject takeGO=Instantiate(cloth4_blue,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+0.5f,parentObject.transform.position.z),parentObject.transform.rotation);
        takeGO.transform.parent=parentObject.transform;
    }
    [PunRPC]
    void cloth4_greenRPC(int parentViewId,string GOname){
        Destroy(GameObject.Find(GOname).gameObject);
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        GameObject takeGO=Instantiate(cloth4_green,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+0.5f,parentObject.transform.position.z),parentObject.transform.rotation);
        takeGO.transform.parent=parentObject.transform;
    }
    [PunRPC]
    void cloth4_redRPC(int parentViewId,string GOname){
        Destroy(GameObject.Find(GOname).gameObject);
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        GameObject takeGO=Instantiate(cloth4_red,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+0.5f,parentObject.transform.position.z),parentObject.transform.rotation);
        takeGO.transform.parent=parentObject.transform;
    }
}

