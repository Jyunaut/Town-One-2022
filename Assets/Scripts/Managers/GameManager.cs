using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public Camera cam;
    [field: Header("Grid data")]
    public Grid<PlaceableObj> grid;

    public int gridWidth;
    public int gridHeight;
    public float gridCellSize;
    public Vector3 gridOrigin;
    public GameObject floor;
    [field: Header("Unit Deletion data")]
    public float threshold;
    [field: Header("Fire spawning data")]
    public int min;
    public int max;

    public PlaceableObj FirePrefab;
    public GameObject blueLine;
    public GameObject redLine;
    

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;

        grid = new Grid<PlaceableObj>(gridWidth, gridHeight, gridCellSize, gridOrigin, (Grid<PlaceableObj> g, int x, int y) => new PlaceableObj());
        var floorGrid = new Grid<PlaceableObj>(gridWidth, gridHeight, gridCellSize, gridOrigin, (Grid<PlaceableObj> g, int x, int y) => new PlaceableObj());
        floorGrid.generatefloor(floor);

        SpawnFires();

        GameEvent.OnGameLose += LoadLoseScene;
    }

    private void SpawnFires()
    {
        int easyLines = 15;

        System.Random rnd = new System.Random();
        for (int i=0; i < grid.width; i++)
        {
            
            for(int j=0; j < grid.height; j++)
            {
                int randNum = rnd.Next(grid.width);
                if (randNum < i-easyLines)
                {
                    var fireInstance = Instantiate(FirePrefab.gameObject, grid.GetCenterOfCell(i, j), Quaternion.identity).GetComponent<Fire>();
      
                    fireInstance.position = new Vector2Int(i, j);
                    grid.SetObject(i, j, fireInstance);
                    Debug.Log(fireInstance.transform.position);
                }
                
            }
        }

        


    //    if(min < 0 || max > gridWidth)
    //        return;

    //    for (int x = min; x < max; x++)
    //    {
    //        for (int y = 0; y < gridHeight; y++)
    //        {
    //            grid.SetObject(x, y, FirePrefab);
    //            Instantiate(FirePrefab.gameObject, grid.GetCenterOfCell(x,y), Quaternion.identity);
    //        }
    //    }
    }

    public bool checkGridWithinRange(int x)
    {
        var bluePos = blueLine.transform.position;
        var redPos = redLine.transform.position;
        int blueX = 0, blueY = 0, redX = 0, redY = 0;
        grid.GetXY(bluePos, out blueX, out blueY);
        grid.GetXY(redPos, out redX, out redY);

        if (!grid.IsValidXY(blueX, blueY)||!grid.IsValidXY(redX,redY))
        {
            return false;
        }

        if (x >= blueX && x < redX)
        {
            return true;
        }
        else return false;
    }

    private void LoadLoseScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Lose");
    }
}
