using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float moveSpeed = 5;
    public Animator animator;
    private Vector3 moveDelta;
    public float bfx=1 , bfy=0;
   


    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
     
    
        transform.Translate(moveDelta.x * moveSpeed * Time.deltaTime ,moveDelta.y * moveSpeed* Time.deltaTime,0 );
        
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
