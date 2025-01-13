using UnityEngine;

public class Enemy : Character
{

    public float shootspeed=3f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        movementSpeed = 18f;
        _moveDirection = Random.value > 0.5f ? 1 : -1;
        print(_moveDirection);

    }

    // Update is called once per frame
    void Update()
    {
        //Shoot(shootspeed);
        UpdateMovement();
    }


    private void OnCollisionEnter2D(Collision2D collision)

    {
        _moveDirection = _moveDirection * -1f;
        
    }

    
}
