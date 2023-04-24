using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SetObjectColor : MonoBehaviour
{
    private readonly Dictionary<string, Color> _colorBank = new()
    {
        ["Red"] = Color.red,
        ["Green"] = Color.green,
        ["Black"] = Color.black
    };

    private Material _objectMaterial;
    // Start is called before the first frame update
    void Start()
    {
        var objectColor = _colorBank.ElementAt(Random.Range(0, _colorBank.Count));

        gameObject.tag = objectColor.Key;
        
        _objectMaterial = new Material(Shader.Find("Standard"));
        _objectMaterial.color = objectColor.Value;
        gameObject.GetComponent<Renderer>().material = _objectMaterial;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
