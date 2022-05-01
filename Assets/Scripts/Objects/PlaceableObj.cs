using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceableObj : MonoBehaviour
{
    public enum Direction { left, right, up, down };
    public Direction dir;
    public Vector2Int position;

    public void SetGridPosition(Vector3 pos)
    {
        GameManager.Instance.grid.SetObject(pos, this);
    }
}