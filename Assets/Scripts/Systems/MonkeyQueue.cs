using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyQueue : MonoBehaviour
{
    public GameObject[] queue;
    public GameObject prefab;
    public int queueSize;

    private void Start()
    {
        queue = new GameObject[queueSize];

        for(int i = 0; i < queueSize; i++)
        {
            queue[i] = Instantiate(prefab) as GameObject;
            queue[i].SetActive(false);
            queue[i].GetComponent<MonkeyFirefighter>().RandomRotate();
        }
    }

    private void UpdateList()
    {
        for (int i = 1; i < queueSize; i++)
        {
            queue[i - 1] = queue[i];
        }
        queue[queueSize - 1] = Instantiate(prefab) as GameObject;
        queue[queueSize - 1].SetActive(false);
        queue[queueSize - 1].GetComponent<MonkeyFirefighter>().RandomRotate();
    }

    public void SpawnMonkey(Vector3 position)
    {
        queue[0].transform.position = position;
        queue[0].GetComponent<MonkeyFirefighter>().SetGridPosition(position);
        queue[0].GetComponent<MonkeyFirefighter>().SetRotation();
        queue[0].SetActive(true);
        UpdateList();
    }
}
