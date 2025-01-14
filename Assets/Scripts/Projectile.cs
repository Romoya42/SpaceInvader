using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Projectile : MonoBehaviour
{
    public float vitesse;
    private GameManager _gameManager;

    float time = 0f;
    [SerializeField]float timer=7; 
    // Update is called once per frame

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
        
            if (enemyScript != null) // Vérifie si le script est trouvé
            {
                enemyScript._vie -= 1; // Modifie la variable _vie dans le script Enemy
        
                if (enemyScript._vie <= 0) // Si la vie de l'ennemi tombe à 0 ou moins
                {
                    time = 0f;
                    _gameManager.IncreementScore(100);
                    _gameManager.combo=true;
                    Destroy(collision.gameObject); // Détruire l'ennemi
                }
            }
            



            
            
            Destroy(this.gameObject);
        }

        
    }
}