using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MyGrid : MonoBehaviour
{
    [Header("---Props")]
    [Tooltip("This is level size for X and Y dimensions.")]
    [SerializeField] private Vector2Int _gridSize;
    [Tooltip("Please drag and drop Cell prefab in the Prefab Folder.")]
    [SerializeField] private GameObject _CellPrefab;
    [Header("---Components")]
    [Tooltip("This is Pool variable. It is handling the cell Insiante and etc.")]
    [field: SerializeField] private Pool<Cell> _Pool;
    [Tooltip("Please Drag and drop Camera")]
    [SerializeField] private ResponsiveCamera _RPCam;
    [Header("---Assets")]
    [Tooltip("Please Drag and drop all Default Sprites that will be use")]
    [SerializeField] private List<Sprite> _sprites = new();

    private Cell[][] _cellsGrid;

    void Start()
    {
        _cellsGrid = new Cell[_gridSize.y][];
        for (int i = 0; i < _gridSize.y; i++)
        {
            _cellsGrid[i] = new Cell[_gridSize.x];
        }
        //Initialing the pool for our Cells that will be use, count is the grid area length.
        _Pool.SpawnAllDictionary($"{Constants.Cell_Key}", (_gridSize.x * _gridSize.y) * 2);
        SetGrid();
    }

    /// <summary>
    /// Creating the grid
    /// </summary>
    private void SetGrid()
    {
        BlockColor[] selectedBlockColor = (BlockColor[])System.Enum.GetValues(typeof(BlockColor));
        int cellIndex = 0;
        for (int y = 0; y < _gridSize.y; y++)
        {
            for (int x = 0; x < _gridSize.x; x++)
            {
                Cell tempCell = _Pool.GetPoolObject($"{Constants.Cell_Key}");
                int randomColor = Random.Range(0, selectedBlockColor.Count());
                tempCell.MyNode.BlockColor = selectedBlockColor[randomColor];
                tempCell.Init(_sprites[randomColor], new Vector2Int(x, y), _gridSize);
                cellIndex++;
                _cellsGrid[y][x] = tempCell;
            }
        }
        SetPosition(Vector2Int.zero);
        // Responsive Camera
        _RPCam.SetCamPosAndSize(_gridSize);
    }
    private void SetPosition(Vector2Int startPosition)
    {
        float plusY = 0;
        float plusX = 0;


        for (int y = startPosition.y; y < _gridSize.y; y++)
        {
            plusY += 1.2f;
            for (int x = startPosition.x; x < _gridSize.x; x++)
            {
                plusX += 1.25f;
                if (x > 0) // Left Neighboor
                {
                    _cellsGrid[y][x].SetNeighboor(ref _cellsGrid[y][x].MyNode.Left, _cellsGrid[y][x - 1].MyNode);
                }
                if (x < _gridSize.x - 1) // Right Neighboor
                {
                    _cellsGrid[y][x].SetNeighboor(ref _cellsGrid[y][x].MyNode.Right, _cellsGrid[y][x + 1].MyNode);
                }
                if (y > 0) // Down Neighboor
                {
                    _cellsGrid[y][x].SetNeighboor(ref _cellsGrid[y][x].MyNode.Down, _cellsGrid[y - 1][x].MyNode);
                }
                if (y < _gridSize.y - 1) // Up Neighboor
                {
                    _cellsGrid[y][x].SetNeighboor(ref _cellsGrid[y][x].MyNode.Up, _cellsGrid[y + 1][x].MyNode);
                }
                _cellsGrid[y][x].SetPosition(new Vector2Int(x, y), new Vector2(x + plusX, y + plusY));

            }
            plusX = 0;
        }
    }
}