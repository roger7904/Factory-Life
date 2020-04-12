using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CastbtnControl : MonoBehaviour
{
    private PhotonView PV;
    public GameObject cherry;


    void Start(){
        PV=GetComponent<PhotonView>();  
    }
    public void cast(){
        Debug.Log("call cast function");
        //playerCollider.enabled=false;
        
        RaycastHit2D hit = Physics2D.Raycast(transform.position, PlayerControl.playerDirection,1);
        if (hit.collider != null)
        {
            Debug.Log(hit.collider.name);
        }
        //playerCollider.enabled=true;
        //if (PV.IsMine) {
            //Debug.Log("ismine");
            PV.RPC("testRPC", RpcTarget.AllBuffered,PlayerControl.ID);
        //}
    }

    [PunRPC]
    void testRPC(int parentViewId){
        Debug.Log(parentViewId);
        GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
        Debug.Log(parentObject.name);
        GameObject takeGO=Instantiate(cherry,new Vector3(parentObject.transform.position.x,parentObject.transform.position.y+0.5f,parentObject.transform.position.z),parentObject.transform.rotation);

        takeGO.transform.parent=parentObject.transform;
    }

//     [PunRPC]
//     private void RPC_InstantiateCloth(int parentViewId) {
//         GameObject parentObject = PhotonView.Find(parentViewId).gameObject;
//         GameObject clone = Instantiate(Top[topNum].name, parentObject.transform.position, parentObject.transform.rotation, 0);
//         clone.transform.parent = parentObject.transform;
//     }

}

