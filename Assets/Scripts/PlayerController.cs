using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Attributes")]
    [SerializeField] private float _speed = 5.0f;
    [SerializeField] private float _score = 0f;
    [SerializeField] private int _lives = 3;

    [Header("References")]
    public Rigidbody2D rb;
    public GameController gameController;
    public UIController uiController;

    private Vector2 _movementDirection;

    void Start()
    {
        _movementDirection = Vector2.right;
    }

    void Update()
    {
        ReadInput();
        MovePlayer();
        FlipSprite();
    }

    #region Player Movement
    private void ReadInput()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        if (horizontalInput != 0)
        {
            _movementDirection = new Vector2(horizontalInput, 0).normalized;
        }
        else if (verticalInput != 0)
        {
            _movementDirection = new Vector2(0, verticalInput).normalized;
        }
    }

    private void MovePlayer()
    {
        rb.velocity = _movementDirection * _speed;
    }

    private void FlipSprite()
    {
        if (_movementDirection.x > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
            GetComponent<SpriteRenderer>().flipY = false;
        }
        else if (_movementDirection.x < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            GetComponent<SpriteRenderer>().flipY = false;
        }
        else if (_movementDirection.y > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
            GetComponent<SpriteRenderer>().flipY = true;
        }
        else if (_movementDirection.y < 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
            GetComponent<SpriteRenderer>().flipY = false;
        }
    }

    #endregion

    #region Collision Detection
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            rb.velocity = Vector2.zero;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Collectable"))
        {
            IncreasePlayerScore(1);
            Destroy(collision.gameObject);
        }
    }

    #endregion

    #region Getters and Setters

    private void IncreasePlayerScore(int amount)
    {
        _score += amount;
        uiController.UpdateScore((int)_score);
    }

    public void DecreasePlayerLives(int amount)
    {
        _lives -= amount;
        uiController.UpdateLives(_lives);
        if (_lives <= 0)
        {
            gameController.GameOver();
        }
    }

    #endregion
}
