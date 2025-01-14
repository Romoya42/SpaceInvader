using UnityEngine;
using UnityEngine.EventSystems;

public class Enemy : Character
{

    public float shootspeed=3f;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _moveDirection = Random.value > 0.5f ? 1 : -1;
        movementSpeed = 18f;
       
    }

    // Update is called once per frame
    void Update()
    {
        

        UpdateMovement();
        UpdateFall();



    }

    protected void UpdateFall()
    {
        Vector2 currentPosition = transform.position;
        currentPosition -= new Vector2(0, 0.5f * Time.deltaTime);
        transform.position = currentPosition;
    }


    protected void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            _moveDirection = _moveDirection * -1f;
            
        }   

    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {   

       _moveDirection = _moveDirection * -1f;
       if (collision.gameObject.CompareTag("Player"))
       {
           _gameManager.combo = false;
           _gameManager.UpdateHealth(-1);
           
           _vie--;

           if (_vie <= 0)
           {
               Destroy(this.gameObject); 
           }
       }
       
       if (collision.gameObject.layer == LayerMask.NameToLayer("KillBox"))
        {
            _gameManager.UpdateHealth(-1);
            Destroy(this.gameObject);
        }
    }

    public void EndGame()
    {
        Destroy(this.gameObject);
    }


}
