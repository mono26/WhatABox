using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public bool IsPaused { get; protected set; }

    [Header("Editor debugging")]
    [SerializeField]
    protected float currentTimeScale = 1f;

    public void TriggerPause(bool _pause)
    {
        IsPaused = _pause;
        if (IsPaused == true)
        {
            //LevelUIManager.Instance.ActivatePauseUI(true);
            Time.timeScale = 0;
            return;
        }
        else if (IsPaused == false)
        {
            //LevelUIManager.Instance.ActivatePauseUI(false);
            Time.timeScale = 1;
            return;
        }
    }

    public void SetTimeScale(float _timeScale)
    {
        Time.timeScale = _timeScale;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;

        return;
    }

    public void ResetTimeScale()
    {
        Time.timeScale = 1f;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;

        return;
    }

    public IEnumerator SlowTimeOverTime(float _targetScale, float _duration)
    {
        SetTimeScale(_targetScale);

        yield return new WaitForSeconds(_duration);

        while(Time.timeScale < 1)
        {
            Time.timeScale += 0.3f;
            Mathf.Clamp(Time.timeScale, 0.0f, 1.0f);

            yield return null;
        }

        yield break;
    }
}
