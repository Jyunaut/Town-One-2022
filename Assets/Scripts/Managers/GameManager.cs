using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public Camera cam;

    [field: Header("Grid data")]
    public Grid<GridObject> grid;
    public int gridWidth;
    public int gridHeight;
    public float gridCellSize;
    public Vector3 gridOrigin;
    
    [field: Header("Unit Deletion data")]
    public float threshold;

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;

        grid = new Grid<GridObject>(gridWidth, gridHeight, gridCellSize, gridOrigin, (Grid<GridObject> g, int x, int y) => new GridObject());
    }
}
