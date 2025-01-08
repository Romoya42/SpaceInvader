using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Button StartButton;
    public TextMeshProUGUI textScore;
    private int score = 0;
    public Character character;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        score = 0;

    }

    // Update is called once per frame
    void Update()
    {

    }

    void IncreementScore()
    {

        score = score++;
        textScore.text = score.ToString();
    }

    void ButtonStart()
    {
        print("start");

    }
}
