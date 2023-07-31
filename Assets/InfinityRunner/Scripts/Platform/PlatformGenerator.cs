﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{

    [SerializeField] private GameObject _platformPrefab;
    [SerializeField] private GameObject _emptyplatformPrefab;

    [SerializeField] private float _spawnDistance;
    [SerializeField] private int _maxPlatforms;
    [SerializeField] private float _platformSpeed;
    [SerializeField] private int _prespawnCount;

    [SerializeField] private int _emptyPlatformsPrespawnCount;

    private List<GameObject> _spawnedPlatforms = new List<GameObject>();
    private List<Coroutine> _coroutines = new List<Coroutine>();

    private void Start()
    {        
        for (int i = _prespawnCount; i > 0; i--)
        {
            Vector3 offset = new Vector3(0f, 0f, -_spawnDistance * i);            
            SpawnPlatform(offset, false);
        }

        SpawnPlatform(Vector3.zero);
    }

    private void SpawnPlatform(Vector3 offset, bool isLoopSpawn = true)
    {
        GameObject newPlatform = null;

        if (_emptyPlatformsPrespawnCount >0)
        {
             newPlatform = Instantiate(_emptyplatformPrefab,  transform.position + offset, Quaternion.identity);

            _emptyPlatformsPrespawnCount--;
        }
        else
        {
            newPlatform = Instantiate(_platformPrefab, transform.position + offset, Quaternion.identity);
        }        

        Coroutine spawnCoroutine = null;

        if (isLoopSpawn)
        {
            spawnCoroutine = StartCoroutine(MovePlatform(newPlatform, _spawnDistance, () => SpawnPlatform(offset)));
        }
        else
        {
            spawnCoroutine = StartCoroutine(MovePlatform(newPlatform, _spawnDistance, null));
        }
       

        _coroutines.Add(spawnCoroutine);
        _spawnedPlatforms.Add(newPlatform);

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
        var isDistancePassedEventSent = false;

        while (platform)
        {
            platform.transform.Translate(Vector3.back * _platformSpeed * Time.deltaTime);
            var traveledDistance = Mathf.Abs(platform.transform.position.z - initialPosition.z);

            if (!isDistancePassedEventSent && traveledDistance > distance)
            {
                isDistancePassedEventSent = true;
                onPlatformPassedDistance?.Invoke();
            }
            yield return null;
        }
    }
}
