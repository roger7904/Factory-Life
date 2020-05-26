using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C : MonoBehaviour
{
    public Animator c;
    // Start is called before the first frame update
    void Start()
    {
        c.SetBool("flag",true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
