using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float JumpForce;
    private Rigidbody2D MyRb;

    Animator myAnimator; //para las animaciones 
    Rigidbody2D Body;
    PolygonCollider2D myCollider;
    float FallingT = -1;


    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        myAnimator.SetBool("runningAct", true);
        Body = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        MGMove();
        Jump();
        FallingAct();
        Shoot();
        EstaEnSuelo();

    }

    bool EstaEnSuelo()
    {
        //return myCollider.IsTouchingLayers(LayerMask.GetMask("Ground"));
        RaycastHit2D colison_suelo = Physics2D.Raycast(myCollider.bounds.center,
        Vector2.down,
        myCollider.bounds.extents.y + 0.1f,
        LayerMask.GetMask("Ground"));



        Debug.DrawRay(myCollider.bounds.center,
        Vector2.down * (myCollider.bounds.extents.y + 0.1f),
        Color.green);



        return (colison_suelo.collider != null);
    }

    void Shoot() 
    {
        if (Input.GetKey(KeyCode.X))
        {
            myAnimator.SetLayerWeight(1, 1);
        }
        else
            myAnimator.SetLayerWeight(1, 0);
    
    
    }

    void MGMove()
    {
        float movH = Input.GetAxis("Horizontal");
        Vector2 movimiento = new Vector2(movH * Time.deltaTime * speed, 0);
        transform.Translate(movimiento);

        if (movH != 0)
        {
            myAnimator.SetBool("runningAct", true);
            if (movH > -0.1f)
            {
                transform.localScale = new Vector2(-1, 1);
            }

            if (movH > 0.1f)
            {
                transform.localScale = new Vector2(1, 1);
            }

        }
        else
        {
            myAnimator.SetBool("runningAct", false);


        }
       
    }

    void Jump() 
    { 
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            if (myCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
            {
                Body.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
                myAnimator.SetTrigger("Jump");
            }
        }
    }

    void FallingAct() 
    { 
        if(Body.velocity.y < FallingT)
        {
            myAnimator.SetBool("Falling", true);
        }

        else 
        {
            myAnimator.SetBool("Falling", false); 
        }
    }
}


// cambiar la direccion segun hacia donde se mueva (mirror?)
