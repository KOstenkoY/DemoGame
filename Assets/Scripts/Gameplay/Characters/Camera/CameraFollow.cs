using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private float _cameraFollowSpeed = 425f;

    private void LateUpdate()
    {
        transform.Translate(Vector2.right.x * _cameraFollowSpeed * Time.deltaTime, 0, 0);
    }
}
