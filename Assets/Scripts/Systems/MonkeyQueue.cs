using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyQueue : MonoBehaviour
{
    public List<GameObject> queue;
    public List<GameObject> monkeyPrefabs;
    public int queueSize;
    public MonkeyQueueUI queueUI;

    private void Start()
    {
        queue = new List<GameObject>();
        for(int i = 0; i < queueSize; i++)
        {
            queue.Add(monkeyPrefabs[Random.Range(0, monkeyPrefabs.Count)]);
        }
        queueUI.UpdateList(this);
    }
    
    private void UpdateList()
    {
        queue.RemoveAt(0);
        queue.Add(monkeyPrefabs[Random.Range(0, monkeyPrefabs.Count)]);
        queueUI.UpdateList(this);
    }

    public void SpawnMonkey(Vector3 position)
    {
        Instantiate(queue[0], position, Quaternion.identity);
        queue[0].GetComponent<MonkeyFirefighter>().SetGridPosition(position);
        UpdateList();
    }
}
