using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NK_ShuckShuck : MonoBehaviour
{
    public float speed = 3f;
    public TrailRenderer trailRenderer;
    public Vector3[] movements = new Vector3[3] {Vector3.zero, Vector3.zero, Vector3.zero};

    CharacterController cc;
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
        cc = GetComponent<CharacterController>();
        trailRenderer.enabled = true;
        movement = cc.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            movement = movements[Mathf.Clamp(index - 1, 0, 2)];
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            movement = movements[Mathf.Clamp(index + 1, 0, 2)];
        }

        transform.position = Vector3.Lerp(transform.position, movement, Time.deltaTime * speed);
    }
}
