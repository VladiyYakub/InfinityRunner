using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _platformPrefab;
    [SerializeField] private float _spawnDistance;
    [SerializeField] private int _maxPlatforms;
    [SerializeField] private float _platformSpeed;
    [SerializeField] private float _spawnInterval;

    private List<GameObject> spawnedPlatforms = new List<GameObject>();
    private float lastSpawnedPosition;

    private void Start()
    {
        lastSpawnedPosition = transform.position.z;
        StartCoroutine(SpawnPlatformCoroutine());
    }

    private void Update()
    {
        if (transform.position.z - lastSpawnedPosition >= _spawnDistance)
        {
            SpawnPlatform();
        }

        if (spawnedPlatforms.Count > _maxPlatforms)
        {
            Destroy(spawnedPlatforms[0]);
            spawnedPlatforms.RemoveAt(0);
        }
    }

    private void SpawnPlatform()
    {
        GameObject newPlatform = Instantiate(_platformPrefab, transform.position, Quaternion.identity);
        spawnedPlatforms.Add(newPlatform);
        lastSpawnedPosition = transform.position.z;

        StartCoroutine(MovePlatform(newPlatform));
    }

    private IEnumerator SpawnPlatformCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(_spawnInterval);
            SpawnPlatform();
        }
    }

    private IEnumerator MovePlatform(GameObject platform)
    {
        Vector3 initialPosition = platform.transform.position;
        float distanceTraveled = 0f;

        while (distanceTraveled < _spawnDistance)
        {
            platform.transform.Translate(Vector3.back * _platformSpeed * Time.deltaTime);
            distanceTraveled = Mathf.Abs(platform.transform.position.z - initialPosition.z);
            yield return null;
        }

        platform.transform.position = initialPosition;
        StartCoroutine(MovePlatform(platform));
    }
}
