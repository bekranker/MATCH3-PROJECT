using UnityEngine;

public class MyGrid : MonoBehaviour, IPoolObject
{
    [SerializeField] private Vector2Int _GridSize;
    [SerializeField] private GameObject _CellPrefab;
    [SerializeField] private Pool _Pool;
    [SerializeField] private Vector2 _Offset;
    void Start()
    {
        SetGrid();
    }
    void SetGrid()
    {
        float yPlus = 0, xPlus = 0;
        for (int y = 0; y < _GridSize.y; y++)
        {
            yPlus += 1.5f;
            for (int x = 0; x < _GridSize.x; x++)
            {
                xPlus += 1.5f;
                GameObject tempGrid = _Pool.GetFromPool(_CellPrefab);
                SetPos(new Vector2(_Offset.x - (x + xPlus), _Offset.y - (y + yPlus)), tempGrid.transform);
            }
            xPlus = 0;
        }
    }
    void SetPos(Vector2 currentCellPos, Transform cellT)
    {
        cellT.position = currentCellPos;
    }

}
