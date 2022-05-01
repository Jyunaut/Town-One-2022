using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceableObj : MonoBehaviour
{
    public enum Direction { left, right, up, down };
    public Direction dir;
    public Vector2Int position;

    protected virtual void Start()
    {
        GameManager.Instance.grid.SetObject(transform.position, this);
    }
}