using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBehaviour : MonoBehaviour
{
    private float _length;
    private float _startPosition;
    [SerializeField] private GameObject _camera;
    [SerializeField, Range(0f, 1f)] private float _parallaxEffect;

    private const string _mysteryHouseTag = "Mystery House";
    private const string _goblinTag = "Goblin";
    string _femaleGoblinTag = "Female Goblin";

    //[SerializeField] private Transform _followTarget = null;
    //[SerializeField, Range(0f, 1f)] private float _parallaxStrength = 0.1f;
    //[SerializeField] private bool _disableVerticalParallax;

    //private Vector3 _targetPreviousPosition;

    void Start()
    {
        //if (!_followTarget)
        //    _followTarget = Camera.main.transform;

        //_targetPreviousPosition = _followTarget.position;

        if (_camera == null)
            return;

        _startPosition = transform.position.x;
        _length = _camera.GetComponent<Camera>().pixelWidth;
    }

    void Update()
    {
        float tmp = _camera.transform.position.x * (1 - _parallaxEffect);
        float distance = (_camera.transform.position.x * _parallaxEffect);

        transform.position = new Vector3(_startPosition + distance, transform.position.y, transform.position.z);

        if (tmp > _startPosition + _length)
        {
            _startPosition += _length;

            if (transform.CompareTag(_mysteryHouseTag) ) 
            { 
                _startPosition *= 1.35f;

            }

        }
        //var deltaPosition = _followTarget.position - _targetPreviousPosition;

        //if (_disableVerticalParallax)
        //    deltaPosition.y = 0;

        //_targetPreviousPosition = _followTarget.position;

        //transform.position += deltaPosition * _parallaxStrength;
    }
}
