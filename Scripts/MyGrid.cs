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


    private Vector2Int[] _cells = new Vector2Int[100];


    void Start()
    {

        _Pool.SpawnAllDictionary();
        SetGrid();
    }

    //The reason we added 1.5f is because Cell covers the Sprite in 1.5f space. Its durability (i.e. xPlus on X, yPlus on Y) should be increased by 1.5f for each axis and added to the current cell bead.
    void SetGrid()
    {

        int indexX = 0, indexY = 0, cellIndex = 0;
        float yPlus = 0, xPlus = 0;
        for (int y = 0; y < _GridSize.y; y++)
        {
            indexY++;
            yPlus += 1.5f;
            for (int x = 0; x < _GridSize.x; x++)
            {
                indexX++;
                _cells[cellIndex] = new Vector2Int(indexX, indexY);
                xPlus += 1.5f;
                Item tempGrid = _Pool.GetPoolObject("Grid");
                SetPos(new Vector2(x + xPlus, y + yPlus), tempGrid.transform);
                cellIndex++;
            }
            xPlus = 0;
            indexX = 0;
        }
        _RPCam.SetCamPosAndSize(_GridSize);

    }
    void SetPos(Vector2 currentCellPos, Transform cellT)
    {
        cellT.position = currentCellPos;
    }

}
