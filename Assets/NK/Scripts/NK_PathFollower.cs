using PathCreation;
using PathCreation.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class NK_PathFollower : MonoBehaviour
{
    public PathCreator pathCreator;
    public EndOfPathInstruction endOfPathInstruction;
    public float speed = 5;
    RoadMeshCreator roadMeshCreator;
    public float distanceTravelled;

    void Start()
    {

    }

    void Update()
    {
        if (pathCreator != null)
        {
            distanceTravelled += speed * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
            transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
            transform.forward = pathCreator.path.GetDirectionAtDistance(distanceTravelled, endOfPathInstruction);
            transform.up = Vector3.Cross(pathCreator.path.GetDirectionAtDistance(distanceTravelled, endOfPathInstruction), 
                pathCreator.path.GetNormalAtDistance(distanceTravelled, endOfPathInstruction));
        }
    }

    // If the path changes during the game, update the distance travelled so that the follower's position on the new path
    // is as close as possible to its position on the old path
    void OnPathChanged()
    {
        distanceTravelled = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody rigid = hit.collider.gameObject.GetComponent<Rigidbody>();
        if (rigid.CompareTag("Rollercoaster"))
        {
            pathCreator = rigid.GetComponent<PathCreator>();
            roadMeshCreator = rigid.GetComponent<RoadMeshCreator>();
            // Subscribed to the pathUpdated event so that we're notified if the path changes during the game
            pathCreator.pathUpdated += OnPathChanged;
        }
    }
}

