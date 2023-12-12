using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public Sprite ghostSprite;
    public Sprite reverseGhostSprite;
    public PlayerController _playerController;
    public float moveSpeed = 10f;
    private bool _isMoving = false;
    private Rigidbody2D _rigidbody2D;
    private bool _isReverse = false;
    private Vector3 _originalPosition;
    private bool _isFrozen = false;


    void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _originalPosition = transform.position;
        StateController.Instance.AddObserver(this);
    }

    void Update()
    {
        if (_isMoving)
        {
            if (Vector2.Distance(transform.position, _playerController.transform.position) < 0.1f)
            {
                _isMoving = false;
                return;
            }
        }
        else
        {
            if (_isReverse)
            {
                RunFromPlayer();
            }
            else
            {
                MoveTowardsPlayer();
            }
        }
    }

    public void ResetPosition()
    {
        transform.position = _originalPosition;
    }

    public void FreezeEnemy()
    {
        _isFrozen = true;
    }

    public void UnFreezeEnemy()
    {
        _isFrozen = false;
    }

    private void MoveTowardsPlayer()
    {
        if(!_isFrozen)
        {
        _isMoving = true;
        Vector2 directionToPlayer = (_playerController.transform.position - transform.position).normalized;
        _rigidbody2D.velocity = directionToPlayer * moveSpeed;
        }else{
            _rigidbody2D.velocity = Vector2.zero;
        }
    }

    private void RunFromPlayer()
    {
        if(!_isFrozen)
        {
        _isMoving = true;
        Vector2 directionAwayFromPlayer = (transform.position - _playerController.transform.position).normalized;
        _rigidbody2D.velocity = directionAwayFromPlayer * moveSpeed;
        }else{
            _rigidbody2D.velocity = Vector2.zero;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(!_isReverse)
            {
                _playerController.DecreasePlayerLives(1);
            }
            else
            {
                _playerController.ConsumeEnemy();
                ResetPosition();
            }
        }
        else
        {
            _isMoving = false;
        }
    }

    public void SetReverse(bool isReverse)
    {
        if(isReverse)
        {
            GetComponent<SpriteRenderer>().sprite = reverseGhostSprite;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = ghostSprite;
        }
        _isReverse = isReverse;
    }
}
