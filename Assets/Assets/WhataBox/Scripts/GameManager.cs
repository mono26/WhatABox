using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get { return instance; }
    }

    //Variables para el manejo del score
    public Text scoreText;
    private int collectableScore = 0;
    private int distanceScore = 0;

    //Variables privadas para el movimiento del suelo
    [SerializeField]
    private Vector3 startPosition;
    [SerializeField]
    private Transform floor;
    [SerializeField]
    private float timeScale;

    public float slowDownFactor = 0.3f;
    public float currentSlowTime;
    public float maxSlowTime = 2.0f;

    //Variables para el fin del nivel
    public static bool GameIsOver;
    public GameObject my_GameOverUI;
    public GameObject my_CompleteLevelUI;

    private void Awake()
    {
        //Parte del singleton en donde se asigna la unica instancia de la clase
        if (instance == null)
        {
            instance = this;    
        }
        else
            Destroy(gameObject);

        startPosition = floor.position;
    }
    private void Update()
    {
        timeScale = Time.timeScale;

        distanceScore = Mathf.RoundToInt(Mathf.Abs(floor.position.y - startPosition.y));
        scoreText.text = (collectableScore + distanceScore).ToString();

        if(Time.timeScale == slowDownFactor)
        {
            currentSlowTime += Time.deltaTime;
        }
        if(currentSlowTime > maxSlowTime)
        {
            currentSlowTime = 0f;
            Time.timeScale += 0.3f;
            Mathf.Clamp(Time.timeScale, 0.0f, 1.0f);
            Time.fixedDeltaTime = Time.timeScale * 0.02f;
        }
    }
    public void ChangeScore(int value)
    {
        collectableScore += value;
    }
    public void DoSlowMotion()
    {
        Debug.Log("Activating Slow Motion");
        Time.timeScale = slowDownFactor;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
    }
    public void GameOver()
    {
        GameIsOver = true;
        my_GameOverUI.SetActive(true);
    }
    public void WinLevel()
    {
        GameIsOver = true;
        my_CompleteLevelUI.SetActive(true);
    }
}
