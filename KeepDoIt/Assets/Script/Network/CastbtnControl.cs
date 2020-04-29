using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CastbtnControl : MonoBehaviour
{
    private PhotonView PV;
    public GameObject cloth1;
    private GameObject playerGO;


    void Start(){
        PV=GetComponent<PhotonView>();  
    }

    void Update(){
        playerGO = PhotonView.Find(PlayerControl.ID).gameObject;
    }
    public void cast(){
        Debug.Log("call cast function");
        //playerCollider.enabled=false;
        
        RaycastHit2D hit = Physics2D.Raycast(playerGO.transform.position, PlayerControl.playerDirection,1);
        if (hit.collider != null)
        {
            Debug.Log(hit.collider.name);
            if(hit.collider.name=="cloth1"){
                PV.RPC("cloth1RPC", RpcTarget.AllBuffered,PlayerControl.ID);
            }
        }
        //playerCollider.enabled=true;
    }

    [PunRPC]
    void cloth1RPC(int parentViewId){
        Debug.Log(parentViewId);
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        Debug.Log(parentObject.name);
        GameObject takeGO=Instantiate(cloth1,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+0.5f,parentObject.transform.position.z),parentObject.transform.rotation);

        takeGO.transform.parent=parentObject.transform;
    }

//     [PunRPC]
//     private void RPC_InstantiateCloth(int parentViewId) {
//         GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
//         GameObject clone = Instantiate(Top[topNum].name, parentObject.transform.position, parentObject.transform.rotation, 0);
//         clone.transform.parent = parentObject.transform;
//     }

}

