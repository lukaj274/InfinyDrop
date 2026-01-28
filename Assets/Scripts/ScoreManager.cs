using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static int Score;
    public static int ScoreMultiplier;
    
    public TMP_Text scoreText;
    public int scoreMultiplier;

    private GameObject _player;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Score = 0;
        _player = GameObject.Find("Player");
        var controller = _player.GetComponent<PlayerController>();

        controller.fallSpeed *= ScoreMultiplier;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.SetText(Score.ToString());
    }
}
