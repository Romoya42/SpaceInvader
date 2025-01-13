using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int[] listVague;
    public int listEnemy;
    public TextMeshProUGUI textScore;
    private int _score = 0;
    public Player player;
    public Enemy enemy;
    public Button _start;

    private int Life;

    public float time = 0f;
    public float timer; 
    public bool isTimerRunning = false; 

    
    void Start()
    {
        //enemy= FindFirstObjectByType<Enemy>();
        //_start=FindFirstObjectByType<Start>();
        //player = FindFirstObjectByType<Player>();
        _score = 0;
        _start.gameObject.SetActive(true);
        _start.onClick.AddListener(ButtonStart);
    }

    


    void Update()
    {
        if (isTimerRunning)
        {
            
            time += Time.deltaTime;
            if (time >= timer)
            {
                isTimerRunning = false;
                VagueEnemy();
                
          
                
                time = 0f;
            }
        }

    }

    void IncreementScore(int value)
    {

        _score = _score+value;
        textScore.text = _score.ToString();
    }

    void ButtonStart()
    {
        player.gameObject.SetActive(true);
        _start.gameObject.SetActive(false);
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
        print(_spawnEnemy);
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
        StartTimer(Random.Range(5f, 10f));
            
        
    }

}
