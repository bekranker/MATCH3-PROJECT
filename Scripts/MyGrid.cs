using System.Collections.Generic;
using UnityEngine;

public class MyGrid : MonoBehaviour
{
    [Header("---Props")]
    [SerializeField] private Vector2Int _GridSize;
    [SerializeField] private GameObject _CellPrefab;
    [SerializeField] private GameObject _ItemPrefabTriangle, _ItemPrefabSquare, _ItemPrefabCircle;
    [Header("---Components")]
    [field: SerializeField] private Pool<Item> _Pool;
    [SerializeField] private ResponsiveCamera _RPCam;
    [Header("---Assets")]
    [SerializeField] private List<Sprite> _sprites = new();

    void Start()
    {
        _Pool.SpawnAllDictionary("Grid", (_GridSize.x * _GridSize.y) * 2);
        SetGrid();
    }

    //The reason we added 1.5f is because Cell covers the Sprite in 1.5f space. Its durability (i.e. xPlus on X, yPlus on Y) should be increased by 1.5f for each axis and added to the current cell bead.
    void SetGrid()
    {
        int cellIndex = 0;
        float yPlus = 0, xPlus = 0;
        for (int y = 1; y <= _GridSize.y; y++)
        {
            yPlus += 1.25f;
            for (int x = 1; x <= _GridSize.x; x++)
            {
                xPlus += 1.25f;
                Item tempGrid = _Pool.GetPoolObject("Grid");
                tempGrid.Init(_sprites[Random.Range(0, _sprites.Count)], new Vector2Int(x, y));
                SetPos(new Vector2(x + xPlus, y + yPlus), tempGrid.transform);
                cellIndex++;
            }
            xPlus = 0;
        }
        _RPCam.SetCamPosAndSize(_GridSize);

    }
    void SetPos(Vector2 currentCellPos, Transform cellT)
    {
        cellT.position = currentCellPos;
    }

}
