using UnityEngine;

public class Player : Character
{
    public float shootspeed=5f;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        movementSpeed = 25f;
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       _moveDirection = Input.GetAxis("Horizontal"); 
       UpdateMovement();
       Shoot(shootspeed);
    }
}
