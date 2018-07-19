using UnityEngine;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    [SerializeField]
    protected SceneFader fader;
    [SerializeField]
    protected Button[] levelButtons;

    protected void Start()
    {
        int levelReached = PlayerPrefs.GetInt("levelReached", 1);

        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 1 > levelReached)
                levelButtons[i].interactable = false;
        }

        return;
    }

    public void LoadLevel(string _level)
    {
        LoadManager.LoadScene(_level);

        return;
    }
}
