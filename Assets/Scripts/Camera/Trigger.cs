using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("WinTrigger"))
        {
            GetComponent<CameraPan>().StopPan();
            GameEvent.WinGame();
            UnityEngine.SceneManagement.SceneManager.LoadScene("Win");
        }
        else if (other.CompareTag("Fire"))
        {
            GetComponent<CameraPan>().StopPan();
            GameEvent.LoseGame();
        }
    }
}
