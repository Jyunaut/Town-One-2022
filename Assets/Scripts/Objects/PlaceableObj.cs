using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceableObj : MonoBehaviour
{
    public enum Direction { left, right, up, down };
    public Direction dir;
    public Vector2Int position;

    private void Start()
    {
        GameManager.Instance.grid.SetObject(position.x, position.y, this);
        transform.position = GameManager.Instance.grid.GetWorldPosition(position.x, position.y)+Vector3.one*0.5f * GameManager.Instance.grid.cellsize;
    }

}
