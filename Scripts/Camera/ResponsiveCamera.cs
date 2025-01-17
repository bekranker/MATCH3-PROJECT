using UnityEngine;

public class ResponsiveCamera : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    private const float _minOrthographicSize = 7f;
    //It is the responsive function;
    public void SetCamPosAndSize(Vector2Int gridSize)
    {
        Vector3 tempPos = new Vector3((gridSize.x * 2.5f) / 2, (gridSize.y * 2.5f) / 2, -10);
        _mainCamera.transform.position = tempPos;

        float gridHeight = gridSize.y * 2.5f;
        float gridWidth = gridSize.x * 2.5f;

        // Calculating ratio of the screen
        float aspectRatio = (float)Screen.width / Screen.height;

        float sizeByHeight = gridHeight / 2f;
        float sizeByWidth = gridWidth / (2f * aspectRatio);

        _mainCamera.orthographicSize = Mathf.Max(Mathf.Max(sizeByHeight, sizeByWidth) + 1, _minOrthographicSize);
    }

}
