using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public Grid<GridObject> grid;
    public int gridWidth;
    public int gridHeight;
    public float gridCellSize;
    public Vector3 gridOrigin;

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;

        grid = new Grid<GridObject>(gridWidth, gridHeight, gridCellSize, gridOrigin, (Grid<GridObject> g, int x, int y) => new GridObject());
    }
}
