using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour, IClickableObject
{
    /// <summary>
    /// Cell's Node. Type is Cell because we want to reach all element's Cell Component for moving them or destroying them.
    /// </summary>
    public Block<Cell> MyNode = new();
    [Tooltip("Sprite Renderer of the cell. Please Drag and drop")]
    [SerializeField] private SpriteRenderer _spriteRenderer;
    /// <summary>
    /// Current Grid Position;
    /// </summary>
    public void OnClick()
    {
        PopBlocks();
    }

    /// <summary>
    /// Setting sprites and Grid Pos
    /// </summary>
    /// <param name="gridPos">Current Grid Position.</param>
    public void Init(Sprite sprite, Vector2Int gridPos, Vector2Int gridSize)
    {
        MyNode.BlockData = gridPos;
        MyNode.Root = this;
        ChangeSprite(sprite);
        _spriteRenderer.sortingOrder = gridPos.x + 1 * gridPos.y + 1;
    }
    public void SetPosition(Vector2Int position, Vector2 targetPosition)
    {
        MyNode.BlockData = position;
        MoveTo(targetPosition);
    }
    public void SetNeighboor(ref Block<Cell> node, Block<Cell> targetNode)
    {
        node = targetNode;
    }
    private void MoveTo(Vector2 to)
    {
        transform.position = to;
    }
    public void PopBlocks()
    {
        List<Block<Cell>> matcheds = MyNode.GetMatchedNeighboors();
        if (matcheds.Count == 0) return;
        foreach (Block<Cell> matchedNeighboorBlock in matcheds)
        {
            Debug.Log(matchedNeighboorBlock.Root.name);
            matchedNeighboorBlock.Root.gameObject.SetActive(false);
        }
        gameObject.SetActive(false);
    }
    /// <summary>
    /// Changing Cell's sprite
    /// </summary>
    /// <param name="sprite">changing sprite, to giving sprite variable</param>
    public void ChangeSprite(Sprite sprite) => _spriteRenderer.sprite = sprite;
}