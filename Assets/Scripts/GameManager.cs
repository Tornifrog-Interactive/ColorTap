using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEditor.UI;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text scoreText;
    public Text currentColorText;
    public int score = 0;
    public float minChangeColorTime = 1f;
    public float maxChangeColorTime = 5f;

    private KeyValuePair<string,Color> _currentColor;
    
    private readonly Dictionary<string, Color> _colorBank = new()
    {
        ["Red"] = Color.red,
        ["Green"] = Color.green,
        ["Black"] = Color.black
    };
    
    // Start is called before the first frame update
    void Start()
    { 
        scoreText.text = $"Score: {score}";
        ChangeColor();
    }

    private void ChangeColor()
    {
        _currentColor = _colorBank.ElementAt(Random.Range(0, _colorBank.Count));
        currentColorText.text = _currentColor.Key;
        currentColorText.color = _currentColor.Value;

        var delay = Random.Range(minChangeColorTime, maxChangeColorTime);
        Invoke(nameof(ChangeColor), delay);
    }

    public void AddScore(UnityEngine.GameObject other)
    {
        if (other.CompareTag(_currentColor.Key))
        {
            scoreText.text = $"Score: {++score}";
            Destroy(other);
        }
        // we can add something here if he dose something bad.
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
