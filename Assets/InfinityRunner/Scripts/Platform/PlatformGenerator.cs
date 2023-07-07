using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _platformPrefab;
    [SerializeField] private float _spawnDistance;
    [SerializeField] private int _maxPlatforms;
    [SerializeField] private float _platformSpeed;

    private List<GameObject> _spawnedPlatforms = new List<GameObject>();
    private List<Coroutine> _coroutines = new List<Coroutine>();

    private void Start()
    {
        SpawnPlatform();
    }

    private void SpawnPlatform()
    {
        GameObject newPlatform = Instantiate(_platformPrefab, transform.position, Quaternion.identity);
        var spawnCoroutine = StartCoroutine(MovePlatform(newPlatform, _spawnDistance, () => SpawnPlatform()));

        _spawnedPlatforms.Add(newPlatform);
        _coroutines.Add(spawnCoroutine);

        if (_spawnedPlatforms.Count > _maxPlatforms)
        {
            StopCoroutine(_coroutines[0]);
            Destroy(_spawnedPlatforms[0]);

            _coroutines.RemoveAt(0);
            _spawnedPlatforms.RemoveAt(0);
        }
    }

    private IEnumerator MovePlatform(GameObject platform, float distance, Action onPlatformPassedDistance)
    {
        var initialPosition = platform.transform.position;
        var isDistancePassedEventSended = false;

        while (platform)
        {
            platform.transform.Translate(Vector3.back * _platformSpeed * Time.deltaTime);
            var traveledDistance = Mathf.Abs(platform.transform.position.z - initialPosition.z);

            if (!isDistancePassedEventSended && traveledDistance > distance)
            {
                isDistancePassedEventSended = true;
                onPlatformPassedDistance?.Invoke();
            }

            yield return null;
        }
    }
}


