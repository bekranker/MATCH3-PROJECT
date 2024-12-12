using UnityEngine;

public class MyGrid : MonoBehaviour, IPoolObject
{
    [Header("---Props")]
    [SerializeField] private Vector2Int _GridSize;
    [SerializeField] private GameObject _CellPrefab;
    [Header("---Components")]
    [SerializeField] private Pool _Pool;
    [SerializeField] private ResponsiveCamera _RPCam;
    void Start()
    {
        SetGrid();
    }

    //The reason we added 1.5f is because Cell covers the Sprite in 1.5f space. Its durability (i.e. xPlus on X, yPlus on Y) should be increased by 1.5f for each axis and added to the current cell bead.
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
                SetPos(new Vector2(x + xPlus, y + yPlus), tempGrid.transform);
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
