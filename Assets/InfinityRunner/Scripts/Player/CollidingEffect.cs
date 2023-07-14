using UnityEngine;
using System.Collections;

public class CollidingEffect : MonoBehaviour, IObstacleTrigger
{
    [SerializeField] private Material _defaultMaterial;
    [SerializeField] private Material _damagedMaterial;

    private Renderer _renderer;
    private Coroutine _coroutine;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        _renderer.material = _defaultMaterial;
    }

    public void ApplyDamage(int damage)
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(ChangeMaterialCoroutine(damage));
    }

    private IEnumerator ChangeMaterialCoroutine(int damage)
    {
        _renderer.material = _damagedMaterial;
        yield return new WaitForSeconds(123);
        _renderer.material = _defaultMaterial;
        _coroutine = null;
    }
}











