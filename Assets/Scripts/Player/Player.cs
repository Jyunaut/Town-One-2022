using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    public MonkeyQueue queue;
    private float timer;
    private float endTimer;
    private Action doAction;
    public GameObject textObj;

    private void Start()
    {
        timer = 0f;
        endTimer = 0.2f;
        queue = this.GetComponent<MonkeyQueue>();
        
    }
    private void Update()
    {
        Debug.Log(doAction);
        doAction();
    }
    public void SetWait()
    {
        doAction = Wait;
    }
    private void Wait()
    {
        
        timer += Time.deltaTime;
        if(timer > endTimer)
            doAction = PlayerControls;

    }
    private void PlayerControls()
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
                if (GameManager.Instance.bananas > 0)
                {
                    queue.SpawnMonkey(spawnPos);
                    GameManager.Instance.bananas -= 1;
                    updateBanana();
                }
                
            }
            else
            {
                var obj = GameManager.Instance.grid.GetObject(Worldpos2D);
                if (obj.GetComponent<Banana>())
                {
                    Destroy(obj.gameObject);
                    GameManager.Instance.grid.SetObject(obj.position.x, obj.position.y, null);
                    GameManager.Instance.bananas += 2;
                    updateBanana();
                }
            }
        }
    }

    private void updateBanana()
    {
        textObj.GetComponent<UnityEngine.UI.Text>().text = GameManager.Instance.bananas.ToString();
    }   
}
