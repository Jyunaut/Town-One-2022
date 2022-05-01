using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactRandomizer : MonoBehaviour
{
    [SerializeField] private List<GameObject> _factList;

    private void Start()
    {
        _factList[Random.Range(0, _factList.Count-1)].SetActive(true);
    }
}
