using UnityEngine;

public class ResponsiveCamera : MonoBehaviour
{
    [SerializeField] private Camera _MainCamera;

    //It is the responsive function.;
    public void SetCamPosAndSize(Vector2Int gridSize)
    {
        Vector3 tempPos = new Vector3((gridSize.x * 2.5f) / 2, (gridSize.y * 2.5f) / 2, -10);
        _MainCamera.transform.position = tempPos;
    }

}
