using UnityEngine;

public class Character : MonoBehaviour
{
    
    public float movementSpeed;
    public float movementDampening = 0.05f;

    public Projectile _projectile;
    private Rigidbody2D _rigidBody;
    protected float _moveDirection = 0f;
    private Vector3 _velocity = Vector3.zero;
    private GameManager _gameManager;
    
    

    
    private void Awake()
    {
        _projectile= FindFirstObjectByType<Projectile>();
        _rigidBody = GetComponent<Rigidbody2D>();
        _gameManager = FindFirstObjectByType<GameManager>();
        
    }




    protected virtual void UpdateMovement()
    {

        //Deplacement
        
        Vector3 targetVelocity = new Vector3(_moveDirection * movementSpeed* Time.fixedDeltaTime * 10f, _rigidBody.linearVelocity.y, 0f);
        _rigidBody.linearVelocity = Vector3.SmoothDamp(_rigidBody.linearVelocity, targetVelocity, ref _velocity, movementDampening);

        

    }

    protected void Shoot(float vitesse)
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            print("shoot");
            var newProjectile = Instantiate(_projectile);
            newProjectile.vitesse=vitesse;
            newProjectile.transform.position = transform.position;
            newProjectile.transform.rotation = transform.rotation;
        }
        

    }



    

}
