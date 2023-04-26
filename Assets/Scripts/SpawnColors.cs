using UnityEngine;

public class SpawnColors : MonoBehaviour
{
    [SerializeField] ColorObject colorObject;

    [SerializeField] float spawnRate = 1.0f;
    [SerializeField] float spawnIncrementRate = 1.05f;

    [SerializeField] int spawnAmount = 1;
    
    public float buffer = 1f;

    private readonly float _diameterToRadius = 0.5f;
    private readonly float _convertToWorldUnits = 2f;
    private float _minScreenX;
    private float _maxScreenX;

    void Start()
    {
        float screenWidth = Camera.main.orthographicSize * _convertToWorldUnits * Camera.main.aspect;
        _minScreenX = (-screenWidth * _diameterToRadius) + buffer;
        _maxScreenX = (screenWidth * _diameterToRadius) - buffer;
        Spawn();
    }

    private void Spawn()
    {
        for (int i = 0; i < this.spawnAmount; i++)
        {
            float randomX = Random.Range(_minScreenX, _maxScreenX);

            var position = transform.position;
            Vector3 positionOfSpawnedObject = new Vector3(
                randomX,
                position.y,
                position.z
            );

            GameObject newObject = Instantiate(
                colorObject.gameObject,
                positionOfSpawnedObject,
                Quaternion.identity // no rotation
                
            );
            newObject.GetComponent<ColorObject>();
        }

        spawnRate /= spawnIncrementRate;
        Invoke(nameof(Spawn), spawnRate);
    }
}