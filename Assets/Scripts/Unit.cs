using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{

    Vector2Int pos;
    Direction dir;
    int attck;

    enum Direction {left,right,up,down};
    Vector2Int position;
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
        var facingObj = GameManager.Instance.grid.GetObject(targetPos.x, targetPos.y);
        return facingObj is Fire ? (Fire)facingObj : null;
    }

    void putOutFire(Damageable fire)
    {
        fire.receiveDamage(attck);
    }

    void rotate(Direction dir)
    {
        this.dir = dir;
        var rotationEular = getRotation(dir);
        transform.eulerAngles = rotationEular;
    }

    private void Update()
    {
        var target = getTarget();
        if (target!=null)
        {
            putOutFire(target);
        }
    }
}
