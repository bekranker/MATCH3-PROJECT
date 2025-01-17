using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour, IClickableObject
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    public CellType CellType;
    private Vector2Int _gridPos;
    public List<Cell> Neighboors;
    public bool HasAnyMatch
    {
        get { return true; }
        set { }
    }
    public void OnClick()
    {
        Debug.Log("Clicked");
    }
    public void Init(Sprite sprite, Vector2Int gridPos)
    {
        _gridPos = gridPos;
        ChangeSprite(sprite);
        _spriteRenderer.sortingOrder = _gridPos.x * _gridPos.y;
    }
    public void ChangeSprite(Sprite sprite) => _spriteRenderer.sprite = sprite;
    void Start() { }
}
