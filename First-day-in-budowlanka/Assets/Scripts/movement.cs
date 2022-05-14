using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float moveSpeed = 5;
    private BoxCollider2D boxCollider; 
    public Animator animator;
    private RaycastHit2D hit;
    private Vector3 moveDelta;
    public float bfx=1 , bfy=0;
    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }


    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
     
        //making sure we can move in y 
        hit = Physics2D.BoxCast(transform.position,boxCollider.size,0,new Vector2(0,moveDelta.y),Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Creature","Blocking"));
        if(hit.collider == null) {
            //moving
            transform.Translate(0,moveDelta.y * moveSpeed* Time.deltaTime,0 );
        }

        //making sure we can move in x 
        hit = Physics2D.BoxCast(transform.position,boxCollider.size,0,new Vector2(moveDelta.x,0),Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Creature","Blocking"));
        if(hit.collider == null) {
            //moving
            transform.Translate(moveDelta.x * moveSpeed * Time.deltaTime, 0, 0 );
        }
        
        //reseting moveDelta
        moveDelta = new Vector3(x,y,0);

        //animations
           if(x<0){
            bfx = -1;
        }else if(x>0) {
            bfx = 1;
        }
        
        if(y<0){
            bfy = -1;
            bfx = 0;
        }else if(y>0) {
            bfy = 1;
            bfx = 0;
        }

        animator.SetFloat("Horizontal", x);
        animator.SetFloat("Vertical", y);
        animator.SetFloat("Speed", moveDelta.sqrMagnitude);
        animator.SetFloat("Beforex", bfx);
        animator.SetFloat("Beforey", bfy);


    }
}
