using UnityEngine;

public class Character : MonoBehaviour
{
    
    public float movementSpeed = 25f;
    public float movementDampening = 0.05f;


    private Rigidbody2D _rigidBody;
    private float _moveDirection = 0f;
    private Vector3 _velocity = Vector3.zero;
    private GameManager _gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _gameManager = FindFirstObjectByType<GameManager>();
        
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _moveDirection = Input.GetAxis("Horizontal") * movementSpeed;
        Vector3 targetVelocity = new Vector3(_moveDirection * Time.fixedDeltaTime * 10f, _rigidBody.linearVelocity.y, 0f);
        _rigidBody.linearVelocity = Vector3.SmoothDamp(_rigidBody.linearVelocity, targetVelocity, ref _velocity, movementDampening);

    }
}
