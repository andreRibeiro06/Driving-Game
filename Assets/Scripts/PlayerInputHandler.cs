using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
public class PlayerInputHandler : MonoBehaviour
{
    
    [Header("Input Action Asset")]
    [SerializeField] private InputActionAsset playerControls;
    
    [Header("Action Map Name Reference")]
    [SerializeField] private string actionMapName = "Player";

    [Header("Action Name References")]
    [SerializeField] private string movement = "Movement";
    [SerializeField] private string rotation = "Rotation";
    [SerializeField] private string jump = "Jump";
    [SerializeField] private string sprint = "Sprint";
    [SerializeField] private string grab = "Grab";
    [SerializeField] private string hold = "Hold";

    private InputAction movementAction;
    private InputAction rotationAction;
    private InputAction jumpAction;
    private InputAction sprintAction;
    private InputAction grabAction;
    private InputAction holdAction;

    public Vector2 MovementInput{get; private set;}
    public Vector2 RotationInput{get; private set;}
    public bool SprintTriggered{get; private set;}

    private void Awake()
    {
        InputActionMap mapReference = playerControls.FindActionMap(actionMapName);

        movementAction = mapReference.FindAction(movement);
        rotationAction = mapReference.FindAction(rotation);
        jumpAction = mapReference.FindAction(jump);
        sprintAction = mapReference.FindAction(sprint);
        grabAction = mapReference.FindAction(grab);
        holdAction = mapReference.FindAction(hold);

        SubsribeActionValuesToInputEvents();
    }

    public bool GrabTriggered => grabAction.WasPerformedThisFrame();
    public bool JumpTriggered => jumpAction.WasPerformedThisFrame();
    public bool HoldTriggered => holdAction.WasPerformedThisFrame();

    private void SubsribeActionValuesToInputEvents()
    {
        movementAction.performed += inputInfo => MovementInput = inputInfo.ReadValue<Vector2>();
        movementAction.canceled += inputInfo => MovementInput = Vector2.zero;

        rotationAction.performed += inputInfo => RotationInput = inputInfo.ReadValue<Vector2>();
        rotationAction.canceled += inputInfo => RotationInput = Vector2.zero;

        sprintAction.performed += inputInfo => SprintTriggered = true;
        sprintAction.canceled += inputInfo => SprintTriggered = false;

    }

    private void OnEnable()
    {
        playerControls.FindActionMap(actionMapName).Enable();
    }

    private void OnDisable()
    {
        playerControls.FindActionMap(actionMapName).Disable();
    }

}
