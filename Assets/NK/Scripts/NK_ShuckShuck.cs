using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NK_ShuckShuck : MonoBehaviour
{
    public float speed = 10f;
    public TrailRenderer trailRenderer;
    public Vector3[] movements = new Vector3[3] {Vector3.zero, Vector3.zero, Vector3.zero};

    CharacterController controller;
    Vector3 movement;
    int index;

    public static NK_ShuckShuck Instance;

    public void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        index = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //print((movements[0] + movements[2]) / 2);
        //movements[1] = (movements[0] + movements[2]) / 2;

    }

    public void ShuckShuck()
    {
        trailRenderer.enabled = false;

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            trailRenderer.enabled = true;
            index--;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            trailRenderer.enabled = true;
            index++;
        }

        index = Mathf.Clamp(index, 0, 2);

        transform.position = Vector3.Lerp(transform.position, movements[index], Time.deltaTime * speed);
    }
}
