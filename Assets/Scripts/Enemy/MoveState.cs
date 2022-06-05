using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class MoveState : State
{
    [SerializeField] private float _speed;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        expand();
        _animator.Play("Fly");
        transform.position = Vector2.MoveTowards(transform.position, Target.transform.position, _speed * Time.deltaTime);
    }

    private void expand()
    {
        if (transform.position.x < Target.transform.position.x)
        {
            _spriteRenderer.flipX = false;
        }

        if (transform.position.x > Target.transform.position.x)
        {
            _spriteRenderer.flipX = true;
        }
    }
}
