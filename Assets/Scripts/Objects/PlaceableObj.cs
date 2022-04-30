using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceableObj : MonoBehaviour
{
    public enum Direction { left, right, up, down };
    public Direction dir;
    public Vector2Int position;

    // Unit deletion data
    private float threshold;
    private float cameraMin;

    protected virtual void Start()
    {
        GameManager.Instance.grid.SetObject(position.x, position.y, this);
    }
    protected virtual void Update()
    {
        DeleteOffMapUnits();
    }
    private void DeleteOffMapUnits()
    {
        cameraMin = GameManager.Instance.cam.ViewportToWorldPoint(new Vector3(0, 0, GameManager.Instance.cam.nearClipPlane)).x;
        threshold = cameraMin - GameManager.Instance.threshold;
        if (this.transform.position.x > threshold)
            return;
        GameManager.Instance.grid.DeleteObject(transform.position);
        GameObject.Destroy(this.gameObject);
    }

}
