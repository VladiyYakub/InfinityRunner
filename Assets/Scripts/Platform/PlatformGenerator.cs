using System.Collections;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] _platformPrefabs;
    [SerializeField] private float _spawnInterval;
    [SerializeField] private float _platformSpeed;

    private float timer = 0f;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= _spawnInterval)
        {
            SpawnPlatform();
            timer = 0f;
        }
    }

    private void SpawnPlatform()
    {
        int randomIndex = Random.Range(0, _platformPrefabs.Length);
        GameObject newPlatform = Instantiate(_platformPrefabs[randomIndex], transform.position, Quaternion.identity);
        StartCoroutine(MovePlatform(newPlatform));
    }

    private IEnumerator MovePlatform(GameObject platform)
    {
        while (true)
        {
            platform.transform.Translate(Vector3.back * _platformSpeed * Time.deltaTime);
            yield return null;
        }
    }
}

