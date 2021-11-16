using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    [SerializeField] int damagePoints;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int darDamagePoints()
    {
        return damagePoints;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject objeto = collision.gameObject;
        string etiqueta = objeto.tag;
        if (etiqueta != "Player")
        {
            Destroy(this.gameObject);
        }

    }

}
