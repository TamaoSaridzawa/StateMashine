using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Player _player;
    [SerializeField] private Shop _shop;
    [SerializeField] private Transform _teleportPoint;
    [SerializeField] private ManagerSaveSkill _managerSaveSkill;
    [SerializeField] private float _timeLastAttack;

    private float _currentTime;
    private Vector2 _moveVector;
    private Rigidbody2D _rigidbody2D;
    private AnimationManager _animationManager;

    public bool IslooksRight { get; private set; } = true;

    private void Start()
    {
        _currentTime = _timeLastAttack;
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animationManager = GetComponent<AnimationManager>();
    }

    private void Update()
    {
        _currentTime -= Time.deltaTime;

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

        if (Input.GetMouseButtonDown(0) && _currentTime <= 0)
        {
            Debug.Log(IslooksRight);
            if (_player.CurrentSkill != null)
            {
                //_animationManager.Attack(_player.IndexSkils);
                _player.AppleDamage(_animationManager);
                _currentTime = _timeLastAttack;
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
            _currentTime = _timeLastAttack;
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

        _rigidbody2D.velocity = new Vector2(_moveVector.x * _speed, _rigidbody2D.velocity.y);
    }
}
