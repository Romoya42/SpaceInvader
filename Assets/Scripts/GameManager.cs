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
    
    private int _score = 0;
    public Player player;
    public Enemy enemy;
    public StrongEnemy strongenemy;
    public Button _start;

    public int _currentHealth;

    float time = 0f;
    public float timer; 

    float time2 = 0f;
    float timer2=6;

    private bool isTimerRunning = false; 
    private bool playing=false;

    public bool combo=false;
    private int multipleCombo=1;

    
    void Start()
    {
        


        _score = 0;
        _start.gameObject.SetActive(true);
        _start.onClick.AddListener(ButtonStart);
        
        
    }

    


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.R))
        {
            PlayerDied();
        }
        
        time2 += Time.deltaTime;
        if (time2 >= timer2)
        {
            multipleCombo=1;
                
            combo=false; 
            
            

            time2 = 0f;
        }

        if (isTimerRunning)
        {

            time += Time.deltaTime;
            if (time >= timer)
            {
                
                isTimerRunning = false;
                if(playing) VagueEnemy();


                

                time = 0f;
                }
            }

        }

    public void IncreementScore(int value)
    {
        
        if (combo){
            time2 = 0f;
            
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
        _currentHealth = 5;
        texthealth.text = "Health: " + _currentHealth.ToString();
        
        _score = 0;
        textScore.text = "Score: " + _score.ToString();
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
            if (Random.Range(0, 10) < 2)
            {
                newenemy = Instantiate(strongenemy);
                
            }
            

            newenemy.transform.position = new Vector2(_spawnEnemy,5.4f);
             
            
            
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

    
        foreach (Enemy enemy in dead)
        {
            Destroy(enemy.gameObject);
        }


    }

}
