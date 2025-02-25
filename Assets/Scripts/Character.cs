using Unity.Burst.Intrinsics;
using UnityEngine;

public class Character : MonoBehaviour
{

    public float movementSpeed;
    public float movementDampening = 0.05f;

    public Projectile _projectile;
    protected Rigidbody2D _rigidBody;
    protected float _moveDirection = 0f;
    protected Vector3 _velocity = Vector3.zero;
    protected GameManager _gameManager;
    public int _vie;
    float time;



    private void Awake()
    {

        _rigidBody = GetComponent<Rigidbody2D>();
        _gameManager = FindFirstObjectByType<GameManager>();
        time = 0;


    }




    protected virtual void UpdateMovement()
    {

        

        Vector3 targetVelocity = new Vector3(_moveDirection * movementSpeed * Time.fixedDeltaTime * 10f, _rigidBody.linearVelocity.y, 0f);
        _rigidBody.linearVelocity = Vector3.SmoothDamp(_rigidBody.linearVelocity, targetVelocity, ref _velocity, movementDampening);



    }

    protected void Shoot(float vitesse)
    {

        if (time >= 0.5f)
        {
            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                

                var newProjectile = Instantiate(_projectile);
                newProjectile.vitesse = vitesse;
                newProjectile.transform.position = transform.position;
                newProjectile.transform.rotation = transform.rotation;
                time = 0;
            }
            

        }
        else time += Time.deltaTime;










    }
}
