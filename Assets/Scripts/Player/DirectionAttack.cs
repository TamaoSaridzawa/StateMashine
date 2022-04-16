using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionAttack : MonoBehaviour
{
    [SerializeField] MovementController _controller;
    [SerializeField] Player _player;
    private float distance = 2;
    private float _currentPosition;



    private void Start()
    {
        _currentPosition = transform.position.x;
    }

    public void DetermineDirection()
    {
        if (_controller.IslooksRight)
        {
            transform.Translate(new Vector3(_player.transform.position.x + distance, 0, 0), Space.World);
        }
        
    }
}
