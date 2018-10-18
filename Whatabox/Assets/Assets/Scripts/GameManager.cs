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
        if (IsPaused == true) {
            Time.timeScale = 0;
        }
        else if (IsPaused == false) {
            Time.timeScale = 1;
        }
        return;
    }

    public void SetTimeScale(float _targetTimeScale)
    {
        currentTimeScale = _targetTimeScale;
        Time.timeScale = currentTimeScale;
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
