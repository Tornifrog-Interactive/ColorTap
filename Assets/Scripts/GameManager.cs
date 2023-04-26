using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text scoreText;
    public Text currentColorText;
    public Text timeText;
    public int score = 0;
    public int gameTime = 60;
    public float minChangeColorTime = 1f;
    public float maxChangeColorTime = 5f;

    public GameObject spawnerColorObject;
    
    private KeyValuePair<string,Color> _currentColor;
    private readonly int _minRangeForRandom = 0;
    private readonly float _delayInTime = 1f;
    
    private readonly Dictionary<string, Color> _colorBank = new()
    {
        ["Red"] = Color.red,
        ["Green"] = Color.green,
        ["Yellow"] = Color.yellow
    };
    
    // Start is called before the first frame update
    void Start()
    { 
        scoreText.text = $"Score: {score}";
        ChangeColor();
        GameTimer();
    }

    private void ChangeColor()
    {
        _currentColor = _colorBank.ElementAt(Random.Range(_minRangeForRandom, _colorBank.Count));
        currentColorText.text = _currentColor.Key;
        currentColorText.color = _currentColor.Value;

        var delay = Random.Range(minChangeColorTime, maxChangeColorTime);
        Invoke(nameof(ChangeColor), delay);
    }

    private void GameTimer()
    {
        if (gameTime <= 0)
        {
            timeText.text = "Game Over!";
            Destroy(spawnerColorObject);
            return;
        }

        timeText.text = $"{gameTime--} Seconds Left";
        Invoke(nameof(GameTimer), _delayInTime);
    }
    
    public void AddScore(UnityEngine.GameObject other)
    {
        if (other.CompareTag(_currentColor.Key))
        {
            scoreText.text = $"Score: {++score}";
            Destroy(other);
        }
        // we can add something here if he clicks on wrong color.
    }
}
