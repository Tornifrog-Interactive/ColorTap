using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnColors : MonoBehaviour
{
    [SerializeField] ColorObject colorObject;

    [SerializeField] float spawnRate = 1.0f;

    [SerializeField] int spawnAmount = 1;

    [SerializeField] Vector3 velocityOfSpawnedObject;

    [SerializeField] float rotationDirection = 0f;

    public float buffer = 1f;

    private float _screenWidth;

    void Start()
    {
        _screenWidth = Camera.main.orthographicSize * 2 * Camera.main.aspect;

        InvokeRepeating(nameof(Spawn), 0f, this.spawnRate);
    }

    private void Spawn()
    {
        for (int i = 0; i < this.spawnAmount; i++)
        {
            float randomX = Random.Range((-_screenWidth / 2f) + buffer, (_screenWidth / 2f) - buffer);

            var position = transform.position;
            Vector3 positionOfSpawnedObject = new Vector3(
                randomX,
                position.y,
                position.z
            );

            Quaternion rotationOfSpawnedObject = Quaternion.Euler(0f, rotationDirection, 0f);
            GameObject newObject = Instantiate(
                colorObject.gameObject,
                positionOfSpawnedObject,
                rotationOfSpawnedObject
            );
            newObject.GetComponent<ColorObject>();
        }
    }
}