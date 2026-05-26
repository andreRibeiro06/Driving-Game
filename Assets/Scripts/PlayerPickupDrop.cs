using UnityEngine;

public class PlayerPickupDrop : MonoBehaviour
{
    [SerializeField] private Transform playerCameraTransform;
    [SerializeField] private float pickupDistance = 2.0f;
    [SerializeField] private LayerMask pickupLayerMask;
    [SerializeField] private PlayerInputHandler playerInputHandler;
    [SerializeField] private Transform objectGrabPointTransform;

private ObjectGrabable currentObjectGrabable;
    void Update()
    {
        if (playerInputHandler.GrabTriggered)
        {
            if(currentObjectGrabable == null)
            {
                if(Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHit, pickupDistance, pickupLayerMask))
                {
                    if(raycastHit.transform.TryGetComponent(out currentObjectGrabable))
                    {
                        currentObjectGrabable.Grab(objectGrabPointTransform);
                    }
                }
            }
            else
            {
                currentObjectGrabable.Drop();
                currentObjectGrabable = null;

            }
        }
    }
}
