using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Grid<T>
{
    public int x, y;
    public float cellsize;
    public int width, height;
    public Vector3 origin;
    public T[,] grid;
    public bool debugLines = true;


    public void generatefloor(GameObject obj)
    {
        for(int i = 0; i < width; i++)
        {
            for(int j = 0; j < height; j++)
            {
                Vector3 pos = GetWorldPosition(i, j);
                var floor = GameObject.Instantiate(obj).transform.GetChild(0).GetComponent<ColoredFloor>();
                floor.position = new Vector2Int(i, j);
                floor.gameObject.transform.position = pos+ Vector3.one * GameManager.Instance.grid.cellsize *0.5f;
            }
        }
    }

    public Grid(int w, int h, float c, Vector3 o,Func<Grid<T>, int, int, T> CreateGridObject)
    {   
        width = w;
        height = h;
        cellsize = c;
        origin = o;
        grid = new T[width, height];

        for (int x = 0; x < grid.GetLength(0); x++)
        {
            for (int y = 0; y < grid.GetLength(1); y++)
            {
                grid[x, y] = CreateGridObject(this, x, y);
            }
        }

        if (debugLines)
        {
            for (int x = 0; x < grid.GetLength(0); x++)
            {
                for (int y = 0; y < grid.GetLength(1); y++)
                {
                    Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x, y + 1), Color.black, 100f);
                    Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x + 1, y), Color.black, 100f);
                }
            }
            Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width, height), Color.black, 100f);
            Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.black, 100f);
        }
    }

    public bool IsValidXY(int x, int y)
    {
        if (x < 0 || y < 0 || x > width || y > height)
            return false;
        return true;
    }
    public bool IsValidXY(Vector3 p)
    {
        GetXY(p, out int x, out int y);
        return IsValidXY(x,y);
    }
    public void SetObject(int x, int y, T l)
    {
        if (x < 0 || y < 0 || x > width || y > height)
        {
            Debug.Log("invalid xy");
            return;
        }

        grid[x, y] = l;
    }
    public void SetObject(Vector3 p, T l)
    {
        int x, y;
        GetXY(p, out x, out y);
        if (x < 0 || y < 0 || x > width || y > height)
        {
            Debug.Log("invalid xy");
            return;
        }
        SetObject(x, y, l);
    }
    public T GetObject(int x, int y)
    {
        if (x < 0 || y < 0 || x > width || y > height)
        {
            return default(T);
        }
        return grid[x, y];
    }
    public T GetObject(Vector3 p)
    {
        int x, y;
        GetXY(p, out x, out y);
        return GetObject(x, y);
    }
    public void GetXY(Vector3 worldPosition, out int x, out int y)
    {
        x = Mathf.FloorToInt((worldPosition - origin).x / cellsize);
        y = Mathf.FloorToInt((worldPosition - origin).y / cellsize);
    }
    public Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x, y) * cellsize + origin;
    }
    public Vector3 GetCenterOfCell(int x, int y)
    {
        Vector3 cellOrigin = GetWorldPosition(x, y);
        float half = cellsize * 0.5f;
        return new Vector3(cellOrigin.x + half, cellOrigin.y + half);

    }
    public Vector3 GetCenterOfCell(Vector3 p)
    {
        int x, y;
        GetXY(p, out x, out y);
        return GetCenterOfCell(x, y);
    }
    public void DeleteObject(int x, int y)
    {
        grid[x, y] = default(T);
    }
    public void DeleteObject(Vector3 p)
    {
        int x, y;
        GetXY(p, out x, out y);
        grid[x, y] = default(T);
    }
}
