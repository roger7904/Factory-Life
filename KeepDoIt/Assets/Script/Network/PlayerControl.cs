using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PlayerControl : MonoBehaviourPunCallbacks
{
    private float moveSpeed;
    private Rigidbody2D playerRb; 
    //private Collider2D playerCollider;
    public static Vector2 playerDirection;
    private Joystick joystick;
    Vector2 movement; 
    public Animator animator;

    public static int ID;
    public static bool run;
    public GameObject r1;
    public GameObject r2;
    public GameObject l1;
    public GameObject l2;
    public GameObject d1;
    public GameObject d2;


    void Awake(){
        if (!photonView.IsMine){
            this.enabled=false;
        }
        playerRb = GetComponent<Rigidbody2D>();
        //playerCollider = GetComponent<Collider2D>();
        joystick=GameObject.FindGameObjectWithTag("Joystick").GetComponent<Joystick>();
    }

    void Start(){
        ID=photonView.ViewID;
        moveSpeed=4f;
    }
    // Update is called once per frame
    void Update()
    {
        
        joystick=GameObject.FindGameObjectWithTag("Joystick").GetComponent<Joystick>();
        movement.x=joystick.Horizontal;
        movement.y=joystick.Vertical;
        if(movement.x==0 && movement.y==0){
            animator.SetFloat("Horizontal",movement.x);
            animator.SetFloat("Vertical",movement.y);
            animator.SetFloat("Speed",0);
            d1.SetActive(false);
            d2.SetActive(false);
            l1.SetActive(false);
            l2.SetActive(false);
            r1.SetActive(false);
            r2.SetActive(false);
            return;
        }
        animator.SetFloat("Horizontal",movement.x);
        animator.SetFloat("Vertical",movement.y);
        animator.SetFloat("Speed",movement.sqrMagnitude);
        if(Mathf.Abs(movement.x)>Mathf.Abs(movement.y)){
            if(movement.x<0){
                d1.SetActive(false);
                d2.SetActive(false);
                r1.SetActive(false);
                r2.SetActive(false);
                playerDirection=Vector2.left;
                animator.SetBool("left",true);
                animator.SetBool("right",false);
                animator.SetBool("up",false);
                animator.SetBool("down",false);
                if(run){
                    moveSpeed=7f;
                    if(l1.activeSelf){
                        l1.SetActive(false);
                        l2.SetActive(true);
                    }else{
                        l1.SetActive(true);
                        l2.SetActive(false);
                    }
                }else{
                    l1.SetActive(false);
                    l2.SetActive(false);
                    moveSpeed=4f;
                }
            }else{
                d1.SetActive(false);
            d2.SetActive(false);
            l1.SetActive(false);
            l2.SetActive(false);
                playerDirection=Vector2.right;
                animator.SetBool("left",false);
                animator.SetBool("right",true);
                animator.SetBool("up",false);
                animator.SetBool("down",false);

                if(run){
                    moveSpeed=7f;
                    if(r1.activeSelf){
                        r1.SetActive(false);
                        r2.SetActive(true);
                    }else{
                        r1.SetActive(true);
                        r2.SetActive(false);
                    }
                }else{
                    r1.SetActive(false);
                    r2.SetActive(false);
                    moveSpeed=4f;
                }
            }
        }else{
            if(movement.y<0){
                d1.SetActive(false);
            d2.SetActive(false);
            l1.SetActive(false);
            l2.SetActive(false);
            r1.SetActive(false);
            r2.SetActive(false);
                playerDirection=Vector2.down;
                animator.SetBool("left",false);
                animator.SetBool("right",false);
                animator.SetBool("up",false);
                animator.SetBool("down",true);
                if(run){
                    moveSpeed=7f;
                }else{
                    moveSpeed=4f;
                }
            }else{
            l1.SetActive(false);
            l2.SetActive(false);
            r1.SetActive(false);
            r2.SetActive(false);
                playerDirection=Vector2.up;
                animator.SetBool("left",false);
                animator.SetBool("right",false);
                animator.SetBool("up",true);
                animator.SetBool("down",false);
                if(run){
                    moveSpeed=7f;
                    if(d1.activeSelf){
                        d1.SetActive(false);
                        d2.SetActive(true);
                    }else{
                        d1.SetActive(true);
                        d2.SetActive(false);
                        
                    }
                }else{
                    d1.SetActive(false);
                    d2.SetActive(false);
                    moveSpeed=4f;
                }
            }
        }
    }

    void FixedUpdate(){
        if(Mathf.Abs(movement.x)>Mathf.Abs(movement.y)){
            playerRb.MovePosition(playerRb.position+new Vector2(movement.x*moveSpeed,0)*Time.fixedDeltaTime);
        }else{
            playerRb.MovePosition(playerRb.position+new Vector2(0,movement.y*moveSpeed)*Time.fixedDeltaTime);
        }
    }

    public void cast(){
        Debug.Log("call cast function");
        //playerCollider.enabled=false;
        //判斷角色面對方向
        RaycastHit2D hit = Physics2D.Raycast(transform.position, playerDirection,1);
        if (hit.collider != null)
        {
            Debug.Log(hit.collider.name);
        }
        //playerCollider.enabled=true;
    }

    
}
