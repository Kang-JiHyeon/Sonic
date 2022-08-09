using PathCreation;
using PathCreation.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class NK_PathFollower : MonoBehaviour
{
    public PathCreator pathCreator;
    public EndOfPathInstruction endOfPathInstruction;
    public float speed = 20;
    public float distanceTravelled;

    RoadMeshCreator roadMeshCreator;
    NK_PlayerMove playerMove;
    NK_PlayerJump playerJump;
    GameObject player;

    void Start()
    {
        playerMove = GetComponent<NK_PlayerMove>();
        player = transform.GetChild(0).gameObject;
        //playerJump = player.GetComponent<NK_PlayerJump>();
    }

    void Update()
    {
        if (pathCreator != null)
        {
            playerMove.enabled = false;
            //playerJump.enabled = false;

            distanceTravelled += speed * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
            //transform.up = Vector3.Cross(pathCreator.path.GetDirectionAtDistance(distanceTravelled, endOfPathInstruction),
            //    pathCreator.path.GetNormalAtDistance(distanceTravelled, endOfPathInstruction));
            transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
            transform.Rotate(0, 0, 90);
            //transform.forward = pathCreator.path.GetDirectionAtDistance(distanceTravelled, endOfPathInstruction);

            if (transform.position == pathCreator.path.GetPoint(pathCreator.path.NumPoints - 1))
            {
                pathCreator = null;
                distanceTravelled = 0;
                //NK_PlayerMove.Instance.dir = Vector3.zero;
                playerMove.enabled = true;
                //playerJump.enabled = true;
            }
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
        if (rigid)
        {
            if (rigid.CompareTag("Rollercoaster"))
            {
                pathCreator = rigid.GetComponent<PathCreator>();
                roadMeshCreator = rigid.GetComponent<RoadMeshCreator>();
                // Subscribed to the pathUpdated event so that we're notified if the path changes during the game
                pathCreator.pathUpdated += OnPathChanged;
            }
        }
    }
}