using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 커브 끝나면 forward 방향 지정
public class JH_CamManager : MonoBehaviour
{
    public Transform[] curveOutPos;
    public int index = 0;
    bool isCurveOut = false;
    float rotationSpeed = 2f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isCurveOut)
        {
            transform.forward = Vector3.Lerp(transform.forward, curveOutPos[index].forward, rotationSpeed * Time.deltaTime);

            if (Vector3.Angle(transform.forward, curveOutPos[index].forward) < 0.5f)
            {
                isCurveOut = false;
                transform.forward = curveOutPos[index].forward;

                index = (index + 1) % curveOutPos.Length;
            }
        }
    
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("CurveOut"))
        {
            isCurveOut = true;
            if (other.gameObject.name.Contains("4"))
            {
                rotationSpeed = 5f;
            }
        }
    }
}
