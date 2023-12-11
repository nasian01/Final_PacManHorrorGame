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


    void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
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

    private void MoveTowardsPlayer()
    {
        _isMoving = true;
        Vector2 directionToPlayer = (_playerController.transform.position - transform.position).normalized;
        _rigidbody2D.velocity = directionToPlayer * moveSpeed;
    }

    private void RunFromPlayer()
    {
        _isMoving = true;
        Vector2 directionAwayFromPlayer = (transform.position - _playerController.transform.position).normalized;
        _rigidbody2D.velocity = directionAwayFromPlayer * moveSpeed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _playerController.DecreasePlayerLives(1);
        }
        else
        {
            _isMoving = false; // Allow changing direction on collision
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
