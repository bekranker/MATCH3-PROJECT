using System.Collections.Generic;
using UnityEngine;

public class MyGrid : MonoBehaviour
{
    [Header("---Props")]
    [Tooltip("This is level size for X and Y dimensions.")]
    [SerializeField] private Vector2Int _GridSize;
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

    void Start()
    {
        //Initialing the pool for our Cells that will be use, count is the grid area length.
        _Pool.SpawnAllDictionary($"{Constants.Cell_Key}", (_GridSize.x * _GridSize.y) * 2);
        SetGrid();
    }

    /// <summary>
    /// Creating the grid
    /// </summary>
    void SetGrid()
    {
        //The reason we added 1.5f is because Cell covers the Sprite in 1.5f space. Its durability (i.e. xPlus on X, yPlus on Y) should be increased by 1.5f for each axis and added to the current cell bead.
        int cellIndex = 0;
        float yPlus = 0, xPlus = 0;
        for (int y = 1; y <= _GridSize.y; y++)
        {
            yPlus += 1.25f;
            for (int x = 1; x <= _GridSize.x; x++)
            {
                xPlus += 1.25f;
                Cell tempCell = _Pool.GetPoolObject($"{Constants.Cell_Key}");
                tempCell.Init(_sprites[Random.Range(0, _sprites.Count)], new Vector2Int(x, y));
                SetPos(new Vector2(x + xPlus, y + yPlus), tempCell.transform);
                cellIndex++;
            }
            xPlus = 0;
        }
        //Responsive Camera
        _RPCam.SetCamPosAndSize(_GridSize);

    }
    /// <summary>
    /// Changing the position of spawned Cell
    /// </summary>
    /// <param name="currentCellPos">target position</param>
    /// <param name="cellT">current position of the giving cell</param>
    void SetPos(Vector2 currentCellPos, Transform cellT)
    {
        cellT.position = currentCellPos;
    }

}
