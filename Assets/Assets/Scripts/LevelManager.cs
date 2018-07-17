using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : Singleton<LevelManager>
{
    [Header("Level Manager settings")]
    [SerializeField]
    protected string mainMenuScene;
    [SerializeField]
    protected float maxSlowTime = 2.0f;
    [SerializeField]
    protected float slowDownFactor = 0.3f;

    [Header("Components")]
    [SerializeField]
    protected Transform floor;
    [SerializeField]
    protected GameObject gameOverUI;
    [SerializeField]
    protected LevelGenerator prefab;
    [SerializeField]
    protected Text scoreText;


    [Header("Editor debugging")]
    [SerializeField]
    protected LevelGenerator currentSection;
    [SerializeField]
    protected LevelGenerator nextSection;
    protected int collectableScore = 0;
    protected int distanceScore = 0;
    [SerializeField]
    protected Vector3 startPosition;
    [SerializeField]
    protected bool gameIsOver;

    private void Start()
    {
        startPosition = floor.position;

        return;
    }
    private void Update()
    {
        distanceScore = Mathf.RoundToInt(Mathf.Abs(floor.position.y - startPosition.y));
        scoreText.text = (collectableScore + distanceScore).ToString();

        return;
    }
    public void ChangeScore(int value)
    {
        collectableScore += value;
    }

    public void GameOver()
    {
        gameIsOver = true;
        gameOverUI.SetActive(true);
    }

    public void CreateMoreSection()
    {
        Vector2 position = currentSection.transform.position;
        position.y = position.y + currentSection.HeightBounds;
        nextSection = Instantiate(prefab, position, Quaternion.identity);

        return;
    }

    public void DestroyOldSection()
    {
        Destroy(currentSection.gameObject, 3f);
        ChangeCurrentSection(nextSection);

        return;
    }
    public void ChangeCurrentSection(LevelGenerator _nextSection)
    {
        currentSection = _nextSection;
        return;
    }

    public void QuitLevel()
    {
        Time.timeScale = 1;
        LoadManager.LoadScene(mainMenuScene);
        //SoundManager.Instance.StopSound();
        return;
    }

    public void RetryLevel()
    {
        //EventManager.TriggerEvent(new GameEvent(GameEventTypes.UnPause));
        LoadManager.LoadScene(SceneManager.GetActiveScene().name);
        return;
    }
}
