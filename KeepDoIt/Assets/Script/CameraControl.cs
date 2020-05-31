using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    private GameObject playerTransform;

    void Start()
    {
        playerTransform=GameObject.FindGameObjectWithTag("Player");
    }

    
    void LateUpdate()
    {
        playerTransform=GameObject.FindGameObjectWithTag("Player");
        Vector3 temp =transform.position;
        temp.x=playerTransform.transform.position.x;
        temp.y=playerTransform.transform.position.y+1.5f;
        transform.position=temp;
    }
}