using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Projectile : MonoBehaviour
{
    public float vitesse;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(0, vitesse * Time.deltaTime));
    }

    private void OnCollisionEnter2D(Collision2D collision)

    {
        
        if (collision.gameObject.CompareTag("Wall"))
        {
            
            Destroy(this.gameObject);
        }




        if (collision.gameObject.CompareTag("Enemy"))
        {
            
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }

        
    }
}