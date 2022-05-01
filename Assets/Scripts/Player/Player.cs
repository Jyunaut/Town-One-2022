using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public MonkeyQueue queue;

    private void Start()
    {
        queue = this.GetComponent<MonkeyQueue>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = Camera.main.nearClipPlane;
            Vector3 Worldpos = Camera.main.ScreenToWorldPoint(mousePos);
            Vector2 Worldpos2D = new Vector2(Worldpos.x, Worldpos.y);

            int x=0, y = 0;
            GameManager.Instance.grid.GetXY(Worldpos, out x, out y);

            if (!GameManager.Instance.grid.GetObject(Worldpos2D) && GameManager.Instance.grid.IsValidXY(Worldpos2D) && GameManager.Instance.checkGridWithinRange(x))
            {
                Vector3 spawnPos = GameManager.Instance.grid.GetCenterOfCell(Worldpos2D);
                queue.SpawnMonkey(spawnPos);
            }

        }
    }
}
