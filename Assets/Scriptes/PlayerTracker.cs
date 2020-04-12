using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
    [SerializeField] private float _far;
    [SerializeField] private GameObject _player;
    [SerializeField] private float _step;
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(_player.transform.position.x, transform.position.y, _far), _step * Time.deltaTime);
    }
}
