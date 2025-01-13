using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int listEnemy;
    public TextMeshProUGUI textScore;
    private int _score = 0;
    public Player player;
    public Enemy enemy;
    public Button _start;

    float _spawnEnemy;

    private float time = 0f;
    private float timer; 
    private bool isTimerRunning = false; 

    
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
            if (timer >= timer)
            {   
                VagueEnemy();
          
                isTimerRunning = false;
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

    public void StartTimer(float timer)
    {
        isTimerRunning = true;
        time = 0f; 
    }

    public void VagueEnemy()
    {
        for (int i = 0; i < listEnemy; i++)
        {
            var newenemy = Instantiate(enemy);
            
            newenemy.transform.position = new Vector2(_spawnEnemy,5.4f);
            newenemy.transform.rotation = transform.rotation;

            //changer ça pour que ça spawn plus loin avec nouvelle variable
            if (_spawnEnemy < 0){
            _spawnEnemy= _spawnEnemy+1;
            }
            else  _spawnEnemy= _spawnEnemy-1;
            
            //faire se deplacer les enemy vers le bas

            //demarrer un nouvelle vague avec un timer
        }
    }

}
