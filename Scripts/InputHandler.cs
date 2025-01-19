using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    private PlayerControls _controls;
    private Camera _camera;
    [SerializeField] private LayerMask _clickableObjectLayers;
    void Awake()
    {
        _controls = new PlayerControls();
        _camera = Camera.main;
    }

    void OnEnable()
    {
        _controls.Enable();
        _controls.Player.Touch.performed += ClickAction;
    }

    void OnDisable()
    {
        _controls.Player.Touch.performed -= ClickAction;
        _controls.Disable();
    }
    /// <summary>
    /// Touching or clicking function. It will execute the OnClick function where raycast hitted (if it is inherited IClickableObject).
    /// </summary>
    /// <param name="context"></param>
    private void ClickAction(InputAction.CallbackContext context)
    {
        RaycastHit2D hit2D = Physics2D.Raycast(_camera.ScreenToWorldPoint(_controls.Player.Touch.ReadValue<Vector2>()), Vector3.forward, 100, _clickableObjectLayers);
        if (hit2D.collider != null)
        {
            if (hit2D.collider.gameObject.TryGetComponent<IClickableObject>(out IClickableObject clickableObject))
            {
                clickableObject.OnClick();
            }
        }
    }
}
