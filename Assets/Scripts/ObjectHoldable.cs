using JetBrains.Annotations;
using UnityEngine;

public class ObjectHoldable : MonoBehaviour
{
    private Vector3 objectOffset;
    private Rigidbody objectRigidBody;
    private Transform objectHoldPointTransform;

    private void Awake()
    {
        objectRigidBody = GetComponent<Rigidbody>();
    }

    public void Hold(Transform objectHoldPointTransform)
    {
        this.objectHoldPointTransform = objectHoldPointTransform;
        objectRigidBody.useGravity = false;
        GetComponent<Collider>().enabled = false;
        objectRigidBody.transform.rotation = Quaternion.identity;
        objectOffset = objectRigidBody.transform.position - GetComponent<Collider>().bounds.center;
        
    }

    public void Drop()
    {
        this.objectHoldPointTransform = null;
        objectRigidBody.useGravity = true;        
        GetComponent<Collider>().enabled = true;
    }

    private void Update()
    {
        if(objectHoldPointTransform != null)
        {
            transform.position = objectHoldPointTransform.position;
            transform.rotation = objectHoldPointTransform.rotation;        
        }
    }

}
