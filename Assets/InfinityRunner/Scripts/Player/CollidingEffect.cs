using UnityEngine;

public class CollidingEffect: MonoBehaviour
{
    [SerializeField] private Material _troquseMaterial;
    [SerializeField] private Material _redMaterial;

    private Renderer _renderer;
    private bool _isSwitched = false;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        _renderer.material = _redMaterial;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!_isSwitched)
        {
            _isSwitched = true;
            _renderer.material = _troquseMaterial;
        }
        else
        {
            _isSwitched = false;
            _renderer.material = _redMaterial;
        }
    }
}

