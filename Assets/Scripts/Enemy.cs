using UnityEngine;
using UnityEngine.EventSystems;

public class Enemy : Character
{

    public float shootspeed=3f;
    float time = 0f;
    float timer=2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _moveDirection = Random.value > 0.5f ? 1 : -1;
        movementSpeed = 18f;
       
    }

    // Update is called once per frame
    void Update()
    {
        //Shoot(shootspeed);

        UpdateMovement();
        Vector2 currentPosition = transform.position;
        currentPosition -= new Vector2(0, 0.5f * Time.deltaTime);
        transform.position = currentPosition;

        
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            _moveDirection = _moveDirection * -1f;
            
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);

        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {   
            _moveDirection = _moveDirection * -1f;
    }


}
