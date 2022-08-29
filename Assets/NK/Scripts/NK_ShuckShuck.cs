using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NK_ShuckShuck : MonoBehaviour
{
    public float speed = 10f;
    public TrailRenderer trailRenderer;
    public Vector3[] movements = new Vector3[3] { Vector3.zero, Vector3.zero, Vector3.zero };

    int index;

    public static NK_ShuckShuck Instance;

    public void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        index = 1;
    }
    bool isPlay = false;
    int curIndex = 0;
    // Update is called once per frame
    void Update()
    {

    }

    public void ShuckShuck()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            index--;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            index++;
        }

        index = Mathf.Clamp(index, 0, 2);

        transform.position = Vector3.Lerp(transform.position, movements[index], Time.deltaTime * speed);

        if (Vector3.Distance(transform.position, movements[index]) < 0.5f)
        {
            isPlay = true;
            trailRenderer.enabled = false;
        }

        // index변화가 생기면 Sound를 출력하고 싶다.
        if(Mathf.Abs(curIndex - index) > 0)
        {
            curIndex = index;
            JH_SoundManager.Instance.PlaySound("Shuck");
            trailRenderer.enabled = true;
        }
    }
}
