using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonkeyQueueUI : MonoBehaviour
{
    public List<Image> imageBoxes;

    public void UpdateList(MonkeyQueue q)
    {
        for(int i = 0; i < q.queueSize; i++)
        {
            imageBoxes[i].sprite = q.queue[i].GetComponent<SpriteRenderer>().sprite;
        }
    }
}
