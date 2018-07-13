using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[RequireComponent(typeof(BoxCollider2D))]
public class SpawnableObject : MonoBehaviour
{
    [Header("Spawnable settings")]
    [SerializeField]
    protected float height;
    public float Height { get { return height; } }
    [SerializeField]
    protected float width;
    public float Width { get { return width; } }
}
