using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float my_Acceleration;
    public float my_MaxSpeed;
    public Rigidbody2D my_RigidBody;
    public float my_MapWith;
    public float my_HorizontalInput;

    public bool left;
    public bool right;

    private void Start()
    {
        my_RigidBody = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        if(left)
        {
            my_HorizontalInput = -1f * Mathf.Lerp(-my_HorizontalInput, my_MaxSpeed, my_Acceleration/10f);
        }
        if(right)
        {
            my_HorizontalInput = 1f * Mathf.Lerp(my_HorizontalInput, my_MaxSpeed, my_Acceleration/10f);
        }
        else if(!left && !right)
        {
            my_HorizontalInput = 0f;
        }
        Vector2 newPosition = my_RigidBody.position + Vector2.right * my_HorizontalInput * Time.fixedDeltaTime;
        newPosition.x = Mathf.Clamp(newPosition.x, -my_MapWith, my_MapWith);
        my_RigidBody.MovePosition(newPosition);
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
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Falling"))
        {
            GameManager.Instance.GameOver();
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Collectable"))
        {
            GameManager.Instance.ChangeScore(5);
            GameObject.Destroy(col.gameObject);
        }
        if (col.CompareTag("SlowMotion"))
        {
            GameManager.Instance.DoSlowMotion();
            GameObject.Destroy(col.gameObject);
        }
        if (col.CompareTag("EndOfLevel"))
        {
            GameManager.Instance.WinLevel();
        }
        if(col.CompareTag("SpeedUp"))
        {
            Floor.Instance.SpeedUp(0.25f);
        }
    }
}
