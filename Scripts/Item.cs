using UnityEngine;

public class Item : MonoBehaviour, IClickableObject
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    private Vector2Int _gridPos;
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
