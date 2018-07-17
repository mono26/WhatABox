using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [Header("Player settings")]
    [SerializeField]
    protected float acceleration;
    [SerializeField]
    protected float maxSpeed;
    [SerializeField]
    protected Rigidbody2D body;
    [SerializeField]
    protected float mapWith;
    [SerializeField]
    protected float slowMotionValue = 0.5f;
    [SerializeField]
    protected float slowMotionDuration = 3f;

    [Header("Editor debugging")]
    [SerializeField]
    protected bool left;
    [SerializeField]
    protected bool right;
    [SerializeField]
    protected float horizontalInput;

    protected void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    protected void Update()
    {
        if (left == true)
        {
            horizontalInput = -1f * Mathf.Lerp(-horizontalInput, maxSpeed, acceleration / 10f);
        }
        if (right == true)
        {
            horizontalInput = 1f * Mathf.Lerp(horizontalInput, maxSpeed, acceleration / 10f);
        }
        else if (left == false && right == false)
        {
            horizontalInput = 0f;
        }

        return;
    }

    protected void FixedUpdate()
    {
        Vector2 newPosition = body.position + Vector2.right * horizontalInput * Time.fixedDeltaTime;
        newPosition.x = Mathf.Clamp(newPosition.x, -mapWith/2 , mapWith/2);
        body.MovePosition(newPosition);

        return;
    }
    //Eventos Creados
    public void LeftPressed()
    {
        left = true;
        right = false;
    }
    public void RightPressed()
    {
        right = true;
        left = false;
    }
    public void LeftReleased()
    {
        right = false;
        left = false;
    }
    public void RightReleased()
    {
        right = false;
        left = false;
    }

    //Eventos internos de Unity
    private void OnCollisionEnter2D(Collision2D _collision)
    {
        if(_collision.gameObject.CompareTag("Falling"))
        {
            LevelManager.Instance.GameOver();
            GameManager.Instance.TriggerPause(true);
        }

        return;
    }
    private void OnTriggerEnter2D(Collider2D _collider)
    {
        if (_collider.CompareTag("Collectable"))
        {
            LevelManager.Instance.ChangeScore(5);
            GameObject.Destroy(_collider.gameObject);
        }
        if (_collider.CompareTag("SlowMotion"))
        {
            GameManager.Instance.SlowTimeOverTime(slowMotionValue, slowMotionDuration);
            GameObject.Destroy(_collider.gameObject);
        }
        if (_collider.CompareTag("EndOfLevel"))
        {
            LevelManager.Instance.GameOver();
        }
        if(_collider.CompareTag("SpeedUp"))
        {
            Floor.Instance.SpeedUp(0.25f);
        }

        return;
    }
}
