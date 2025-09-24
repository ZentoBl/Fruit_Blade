using UnityEngine;
using UnityEngine.InputSystem;

public class Blade : MonoBehaviour
{
    [SerializeField] private float maxDistRaycast = 100;
    [SerializeField] private LayerMask layerMask;

    public PlayerInput playerInput; 
    private InputAction touchPressAction; 
    private InputAction touchPosAction;

    void Start()
    {
        touchPosAction = playerInput.actions["TouchPos"];
        touchPressAction = playerInput.actions["Touchscreen"]; 
    }
    void Update()
    {
        if (!touchPressAction.WasPerformedThisFrame()) return;
        
        Ray ray = Camera.main.ScreenPointToRay(touchPosAction.ReadValue<Vector2>());
        if (Physics.Raycast(ray, out RaycastHit hit, maxDistRaycast, layerMask))
        {
            transform.position = hit.point;
            if (hit.transform.CompareTag("Fruit"))
            {
                hit.transform.GetComponent<SliceableFruit>().Slice();
            }
        }
    }

}
