using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class GoblinMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 50f;
    [SerializeField] private float _timeScaleAnimation = 1f;
    [SerializeField, Range(-1f,1f)] private float _direction;
    [SerializeField] private float _aliveTime = 0f;

    [SerializeField] private Transform _mainCharacterPosition;

    private SkeletonAnimation _skeletonAnimation;

    private Vector2 _deltaPosition;

    private void Start()
    {
        _skeletonAnimation = GetComponent<SkeletonAnimation>();
        _skeletonAnimation.timeScale = _timeScaleAnimation;

        if (_direction == 0)
            _direction = 1;
        else if (_direction < 0)
            _direction = -1;
        else
            _direction = 1;

        _deltaPosition = new Vector2(_mainCharacterPosition.position.x - transform.position.x, transform.position.y);

        StartCoroutine(GoblinSpawnRoutine());
    }

    void Update()
    {
        transform.Translate(_direction * _speed * Time.deltaTime, 0, 0);
    }

    private IEnumerator GoblinSpawnRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(_aliveTime);

            transform.position = new Vector2(_mainCharacterPosition.position.x - _deltaPosition.x, transform.position.y);
        }
    }
}
