using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Projectile : MonoBehaviour
{
    public float vitesse;
    private GameManager _gameManager;

        

    private void Awake()
    {
        
        
        _gameManager = FindFirstObjectByType<GameManager>();
        
        
    }

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

            Enemy enemyScript = collision.gameObject.GetComponent<Enemy>();
        
            if (enemyScript != null) 
            {
                enemyScript._vie -= 1; 
        
                if (enemyScript._vie <= 0) 
                {
                    
                    _gameManager.IncreementScore(50);
                    _gameManager.combo=true;
                    Destroy(collision.gameObject); 
                }
            }
            



            
            
            Destroy(this.gameObject);
        }

        
    }
}