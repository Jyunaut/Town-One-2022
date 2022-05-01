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
    Vector3 getRotation(Direction dir)
    {
        switch (dir)
        {
            case Direction.left:
                return new Vector3(0, 0, 90);
            case Direction.right:
                return new Vector3(0, 0, -90);
            case Direction.up:
                return new Vector3(0, 0, 0);
            case Direction.down:
                return new Vector3(0, 0, 180);
            default:
                return Vector3.zero;
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

    void rotate(Direction dir)
    {
        this.dir = dir;
        var rotationEular = getRotation(dir);
        transform.eulerAngles = rotationEular;
    }

    protected override void Start()
    {
        base.Start();
    }
    protected override void Update()
    {
        base.Update();
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
}
