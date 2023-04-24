using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillOnTouch : MonoBehaviour
{
    private void OnMouseDown()
    {
        FindObjectOfType<GameManager>().AddScore(gameObject);
    }
}
