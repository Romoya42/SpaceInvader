using UnityEngine;

public class StrongEnemy : Enemy
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _vie = 2;
        _moveDirection = Random.value > 0.5f ? 1 : -1;
        movementSpeed = 22f;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateFall();
        UpdateMovement();
    }
}
