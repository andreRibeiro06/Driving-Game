using UnityEngine;

public class ObjectGrabable : MonoBehaviour
{
    private Rigidbody objectRigidBody;
    private Transform objectGrabPointTransform;

    private void Awake()
    {
        objectRigidBody = GetComponent<Rigidbody>();
    }

    public void Grab(Transform objectGrabPointTransform)
    {
        this.objectGrabPointTransform = objectGrabPointTransform;
        objectRigidBody.useGravity = false;
        objectRigidBody.linearVelocity = Vector3.zero; 
        objectRigidBody.angularVelocity = Vector3.zero;
    }

    public void Drop()
    {
        this.objectGrabPointTransform = null;
        objectRigidBody.useGravity = true;
    }

    private void FixedUpdate()
    {
        if(objectGrabPointTransform != null)
        {
            float speedModifier = 10f;
            Vector3 directionToTarget = objectGrabPointTransform.position - transform.position;
            objectRigidBody.linearVelocity = directionToTarget * speedModifier;
        }
    }

}
