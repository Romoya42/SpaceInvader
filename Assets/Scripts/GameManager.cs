using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int[] listVague;
    public int listEnemy;

    public TextMeshProUGUI textScore;
    public TextMeshProUGUI texthealth;
    public TextMeshProUGUI texttemp;
    private int _score = 0;
    public Player player;
    public Enemy enemy;
    public Button _start;

    public int _currentHealth;

    float time = 0f;
    public float timer; 

    float time2 = 0f;
    float timer2=2; 

    public bool isTimerRunning = false; 
    private bool playing=false;

    public bool combo=false;
    public int multipleCombo=0;

    
    void Start()
    {
        //enemy= FindFirstObjectByType<Enemy>();
        //_start=FindFirstObjectByType<Start>();
        //player = FindFirstObjectByType<Player>();
        _score = 0;
        _start.gameObject.SetActive(true);
        _start.onClick.AddListener(ButtonStart);
        texthealth.text = "Health: " + _currentHealth.ToString();
        textScore.text = "Score: " + _score.ToString();
    }

    


    void Update()
    {
        
        time2 += Time.deltaTime;
        if (time2 >= timer2)
        {
            multipleCombo=0;
                
            combo=false; 
            
            print("in");

            time2 = 0f;
        }
    }

    public void IncreementScore(int value)
    {
        
        if (combo){
            time2 = 0f;
            print("out");
            multipleCombo++;
            _score = _score+(value * multipleCombo) ;
            textScore.text = "Score: " + _score.ToString();

        }
        
        
    }

    void ButtonStart()
    {
        player.gameObject.SetActive(true);
        _start.gameObject.SetActive(false);
        playing=true;
        StartTimer(2);

    }

    public void StartTimer(float chrono)
    {
        
        timer = chrono;
        isTimerRunning = true;
    }

    public void VagueEnemy()
    {
        
        float _spawnEnemy= Random.Range(-8.5f, 8.5f);
        float _positionX = _spawnEnemy;
        listEnemy=Random.Range(1, 5);


        for (int i = 0; i < listEnemy; i++)
        {
            
            var newenemy = Instantiate(enemy);
            
            newenemy.transform.position = new Vector2(_spawnEnemy,5.4f);
             
            newenemy.transform.rotation = transform.rotation;
            
            if (_positionX < 0){
            _spawnEnemy= _spawnEnemy+1;
            }
            else  _spawnEnemy= _spawnEnemy-1;
        }

        if (listVague.Length > 0  ){
            for (int i = 0; i < listVague.Length; i++)
            StartTimer(listVague[i]);
            
        }
        else StartTimer(Random.Range(5f, 10f));
            
        
    }

    public void UpdateHealth(int health)
    {

        _currentHealth += health;
        texthealth.text = "Health: " + _currentHealth.ToString();
        if(_currentHealth <= 0)
        {
            PlayerDied();
            
        }
    }

    public void PlayerDied(){
        player.gameObject.SetActive(false);
        _start.gameObject.SetActive(true);
        playing=false;
        Enemy[] dead = FindObjectsOfType<Enemy>();

        // Parcourir et détruire chaque Enemy trouvé
        foreach (Enemy enemy in dead)
        {
            Destroy(enemy.gameObject);
        }


    }

}
