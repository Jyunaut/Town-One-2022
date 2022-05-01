using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyQueue : MonoBehaviour
{
    public List<GameObject> queue;
    public List<GameObject> monkeyPrefabs;
    public int queueSize;

    private void Start()
    {
        for(int i = 0; i < queueSize; i++)
            queue[i] = monkeyPrefabs[Random.Range(0, monkeyPrefabs.Count-1)];
    }

    private void UpdateList()
    {
        for (int i = 1; i < queueSize; i++)
            queue[i-1] = queue[i];
        queue[queueSize-1] = monkeyPrefabs[Random.Range(0, monkeyPrefabs.Count-1)];
    }

    public void SpawnMonkey(Vector3 position)
    {
        Instantiate(queue[0], position, Quaternion.identity);
        UpdateList();
    }
}
