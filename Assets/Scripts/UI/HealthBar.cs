using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public GameObject prefab;
    public GameObject anchorPoint;
     GameObject UIInstance;

    private void Start()
    {
        if (prefab == null)
        {
            Debug.LogError("Healthbar prefab not added!");
        }
        else if(anchorPoint == null)
        {
            Debug.LogError("HealthBar Anchor point not added!");
        }

        var canvases = FindObjectsOfType<Canvas>();
        Canvas canvas = null;
        foreach(Canvas i in canvases)
        {
            if (i.CompareTag("Canvas"))
            {
                canvas = i;
            }
        }


        if (canvas == null)
        {
            Debug.Log("Missing Canvas!");
        }

        UIInstance = Instantiate(prefab, canvas.transform);
        UIInstance.transform.position = anchorPoint.transform.position;


    }

    public void changeHealthBar(int curr, int full)
    {
        float healthPerCent = Mathf.InverseLerp(0, full, curr);
        
        var greenBar = GetGreenBar(healthPerCent);
        if (greenBar&& healthPerCent!=greenBar.fillAmount)
        {
            greenBar.fillAmount = healthPerCent;
        }
    }

    private Image GetGreenBar(float healthPerCent)
    {
        if (UIInstance == null)
            return null;
        var child1 = UIInstance.transform.GetChild(0);
        if (child1 != null)
        {
            var child2 = child1.GetChild(0);
            if (child2 != null)
            {
                var greenBar = child2.GetComponent<Image>();
                if (greenBar) return greenBar;
            }
        }
        Debug.LogError("STH went wrong when finding the Green img!");
        return null;
    }

    public void DestryInstance()
    {
        Destroy(UIInstance);
    }

}
