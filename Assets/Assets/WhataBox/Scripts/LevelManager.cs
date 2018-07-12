using UnityEngine;
using UnityEngine.UI;

public class LevelManager : Singleton<LevelManager>
{
    [Header("Level Manager settings")]
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
        Destroy(currentSection.gameObject);
        ChangeCurrentSection(nextSection);

        return;
    }
    public void ChangeCurrentSection(LevelGenerator _nextSection)
    {
        nextSection = _nextSection;
        return;
    }
}
