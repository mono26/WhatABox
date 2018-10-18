using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerLevelRecicle : MonoBehaviour
{
    [SerializeField]
    protected LevelGenerator sectionOwner;

    protected void OnTriggerEnter2D(Collider2D _collision)
    {
        if(_collision.CompareTag("Player"))
            LevelManager.Instance.DestroyOldSection();

        return;
    }
}
