using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour, IClickableObject
{
    /// <summary>
    /// Cell's Node. Type is Cell because we want to reach all element's Cell Component for moving them or destroying them.
    /// </summary>
    public Node<Cell> MyNode = new();
    /// <summary>
    /// Checking is there have any matches
    /// </summary>
    public bool HasAnyMatch { get; set; }
    [Tooltip("Sprite Renderer of the cell. Please Drag and drop")]
    [SerializeField] private SpriteRenderer _spriteRenderer;
    /// <summary>
    /// Current Grid Position;
    /// </summary>
    private Vector2Int _gridPos;

    public void OnClick()
    {
        Debug.Log("Clicked");
    }
    /// <summary>
    /// Setting sprites and Grid Pos
    /// </summary>
    /// <param name="gridPos">Current Grid Position.</param>
    public void Init(Sprite sprite, Vector2Int gridPos)
    {
        _gridPos = gridPos;
        ChangeSprite(sprite);
        _spriteRenderer.sortingOrder = _gridPos.x * _gridPos.y;
    }
    /// <summary>
    /// Changing Cell's sprite
    /// </summary>
    /// <param name="sprite">changing sprite, to giving sprite variable</param>
    public void ChangeSprite(Sprite sprite) => _spriteRenderer.sprite = sprite;
}