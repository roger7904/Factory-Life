using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderMove : MonoBehaviour
{
    private Vector3 start;
    private Vector3 end;
    private float time;
    private bool flag;
    // Start is called before the first frame update
    void Start()
    {
        flag=true;
        start=transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        time+=Time.deltaTime;
        if(flag){
            if(time>=1){
                end=transform.position;
                if(start==end){
                    transform.Translate(0, 0.5f, 0);
                }
                flag=false;
            } 
        }
        
        
    }
}
