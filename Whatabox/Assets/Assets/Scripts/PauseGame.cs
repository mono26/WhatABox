using UnityEngine;

public class PauseGame : MonoBehaviour
{
    /// Puts the game on pause
    public virtual void PauseAction(bool _isPause)
    {
        LevelManager.Instance.PauseLevel(_isPause);

        return;
    }
}
