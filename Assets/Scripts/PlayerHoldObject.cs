using UnityEngine;

public class PlayerHoldObject : MonoBehaviour
{
    [SerializeField] private Transform playerCameraTransform;
    [SerializeField] private float pickupDistance = 2.0f;
    [SerializeField] private LayerMask holdLayerMask;
    [SerializeField] private PlayerInputHandler playerInputHandler;
    [SerializeField] private Transform objectHoldPointTransform;


    private ObjectHoldable currentObjectHeld;
    private void Update()
    {
        if (playerInputHandler.HoldTriggered)
        {
            if(currentObjectHeld == null)
            {
                if(Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHit, pickupDistance, holdLayerMask))
                {
                    if(raycastHit.transform.TryGetComponent(out currentObjectHeld))
                    {
                        currentObjectHeld.Hold(objectHoldPointTransform);
                    }
                }
            }
            else
            {
                currentObjectHeld.Drop();
                currentObjectHeld = null;
            }
        }
    }
}
