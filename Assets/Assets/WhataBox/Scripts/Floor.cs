using UnityEngine;

public class Floor : MonoBehaviour
{
    private static Floor instance;
    public static Floor Instance
    {
        get { return instance; }
    }

    public float speed = 1f;
    public float increaseRate;

    private void Awake()
    {
        //Parte del singleton en donde se asigna la unica instancia de la clase
        if (instance == null)
        {
            instance = this;
        }
        else
            Destroy(gameObject);
    }
    void Update()
    {
        Vector2 newPosition = transform.position + Vector3.up;
        transform.position = Vector3.MoveTowards(transform.position, newPosition, speed * Time.deltaTime);
    }
    public void SpeedUp(float value)
    {
        speed += value;
    }
}
