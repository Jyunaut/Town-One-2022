using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyFirefighter : PlaceableObj
{
    public int attack;
    public float attackSpeed = 1.0f;
    public float timer = 0.0f;

    Vector2Int getDirVec(Direction dir)
    {
        switch (dir)
        {
            case Direction.left:
                return new Vector2Int(-1, 0);
            case Direction.right:
                return new Vector2Int(1, 0);
            case Direction.up:
                return new Vector2Int(0, 1);
            case Direction.down:
                return new Vector2Int(0, -1);
            default:
                return new Vector2Int(0, 0);
        }
    }
    public Quaternion getRotation()
    {
        switch (dir)
        {
            case Direction.left:
                return Quaternion.AngleAxis(180f, Vector3.forward);
            case Direction.right:
                return Quaternion.AngleAxis(0f, Vector3.forward);
            case Direction.up:
                return Quaternion.AngleAxis(-90f, Vector3.forward);
            case Direction.down:
                return Quaternion.AngleAxis(-90f, Vector3.forward);
            default:
                return Quaternion.identity;
        }
    }
    Fire getTarget()
    {
        var dirVec = getDirVec(dir);
        var targetPos = dirVec + position;
        if(targetPos.x >= 0 && targetPos.x < GameManager.Instance.grid.width && targetPos.y>0&&targetPos.y < GameManager.Instance.grid.height)
        {
            var facingObj = GameManager.Instance.grid.GetObject(targetPos.x, targetPos.y);
            return facingObj is Fire ? (Fire)facingObj : null;
        }
        return null;

    }

    void putOutFire(Damageable fire)
    {
        fire.receiveDamage(attack);
    }
    public void RandomRotate()
    {
        dir = (Direction)Random.Range(0, 4);
    }

    protected override void Start()
    {
        base.Start();
    }

    protected void Update()
    {
        DeleteOffMap();
        timer += Time.deltaTime;
        if (timer >= attackSpeed)
        {
            var target = getTarget();
            timer = 0.0f;
            if (target == null)
                return;
            Debug.Log("target found");
            putOutFire(target);

            
        }
    }
    
    private void DeleteOffMap()
    {
        float cameraMin = GameManager.Instance.cam.ViewportToWorldPoint(new Vector3(0, 0, GameManager.Instance.cam.nearClipPlane)).x;
        float threshold = cameraMin - GameManager.Instance.threshold;

        if (this.transform.position.x > threshold)
            return;
        GameManager.Instance.grid.DeleteObject(transform.position);
        GameObject.Destroy(this.gameObject);
    }

}
