using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NK_PlayerHMove : MonoBehaviour
{
    Vector3 playerPos;

    // Start is called before the first frame update
    void Start()
    {
        playerPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        float min = playerPos.z - 0.1f;
        float max = playerPos.z + 0.1f;

        transform.position = new Vector3(
            transform.position.x,
            transform.position.y,
            Mathf.Clamp(transform.position.z, min, max));

        NK_PlayerMove.Instance.Move(v, -h);
    }

    Vector3 ClampPosition(Vector3 position)
    {
        return new Vector3(
            transform.position.x,
            transform.position.y,
            Mathf.Clamp(position.z, playerPos.z - 0.1f, playerPos.z + 0.1f));
    }
}
