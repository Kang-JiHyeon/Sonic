using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NK_ShuckShuck : MonoBehaviour
{
    public float speed = 10f;
    public TrailRenderer trailRenderer;
    public Vector3[] movements = new Vector3[3] { Vector3.zero, Vector3.zero, Vector3.zero };

    bool isKeyDown;
    float currentTime;
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
        if (isKeyDown)
        {
            currentTime += Time.deltaTime;
            if (currentTime < 0.5f)
            {
                JH_SoundManager.Instance.PlaySound("Shuck");
                trailRenderer.enabled = true;
            }
            else
            {
                isKeyDown = false;
                trailRenderer.enabled = false;
                currentTime = 0;
            }
        }
    }

    public void ShuckShuck()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            isKeyDown = true;
            index--;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            isKeyDown = true;
            index++;
        }

        index = Mathf.Clamp(index, 0, 2);

        transform.position = Vector3.Lerp(transform.position, movements[index], Time.deltaTime * speed);
    }
}
