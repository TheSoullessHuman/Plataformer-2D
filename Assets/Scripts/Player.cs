using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed;
    private Rigidbody2D MyRb;

    Animator myAnimator; //para las animaciones 

    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();

        myAnimator.SetBool("runningAct", true);

        
    }

    // Update is called once per frame
    void Update()
    {
        
        MGMove();

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
            transform.localScale 

        }
       
    }

}
// mover el personaje
// cambiar la direccion segun hacia donde se mueva (mirror?)
//cambiar la animacion cambiando runningAct
