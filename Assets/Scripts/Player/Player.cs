using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlaceableObj Tower;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = Camera.main.nearClipPlane;
            Vector3 Worldpos = Camera.main.ScreenToWorldPoint(mousePos);
            Vector2 Worldpos2D = new Vector2(Worldpos.x, Worldpos.y);

            if (GameManager.Instance.grid.GetObject(Worldpos2D) == null)
            {
                Vector3 spawnPos = GameManager.Instance.grid.GetCenterOfCell(Worldpos2D);
                Instantiate(Tower.gameObject, spawnPos, Quaternion.identity);
                GameManager.Instance.grid.SetObject(Worldpos2D, Tower);
            }
        }
    }
}
