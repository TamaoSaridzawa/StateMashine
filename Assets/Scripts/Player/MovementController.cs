using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private float _speed;
    [SerializeField] private Player _player;
    [SerializeField] private Shop _shop;
    [SerializeField] private Transform _teleportPoint;
    [SerializeField] private ManagerSaveSkill _managerSaveSkill;

    private Vector2 _moveVector;
    private Rigidbody2D _rigidbody2D;
    private AnimationManager _animationManager;

    public bool IslooksRight { get; private set; } = true;

    private void Start()
    {
        
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animationManager = GetComponent<AnimationManager>();
    }

    private void Update()
    {
        _managerSaveSkill.InitTeleport();

        _managerSaveSkill.InitDressingHealth();

        _moveVector.x = Input.GetAxis("Horizontal");

        if (_moveVector.x == 0)
        {
            _rigidbody2D.velocity = new Vector2(0, _rigidbody2D.velocity.y);
            _animationManager.Idle();
        }
        else
        {
            if (IslooksRight == false && _moveVector.x > 0)
            {
              
                Flip();
            }
            else if (IslooksRight == true &&_moveVector.x < 0)
            {
                Flip();
            }
            Walk();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _player.SetPosition(_teleportPoint);
        }

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(IslooksRight);
            if (_player.CurrentSkill != null)
            {
                _animationManager.Attack(_player.IndexSkils);
                _player.AppleDamage();
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OpenShopMenu();
        }

        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            CloseShopMenu();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            _player.NextSkill();
        }
    }

    public void Flip()
    {
        IslooksRight = !IslooksRight;
        transform.Rotate(0f, 180f, 0f);
    }

    private void CloseShopMenu()
    {
        _shop.gameObject.SetActive(false);
    }

    private void OpenShopMenu()
    {
        _shop.gameObject.SetActive(true);
    }

    private void Walk()
    {
        _animationManager.Run();

        //if (_moveVector.x < 0)
        //{
           
        //    IslooksRight = true;
        //}

        //if (_moveVector.x > 0)
        //{
        //    //transform.Rotate(0f, 180f, 0f);
        //    IslooksRight = false;
        //}

        _rigidbody2D.velocity = new Vector2(_moveVector.x * _speed, _rigidbody2D.velocity.y);
    }
}
