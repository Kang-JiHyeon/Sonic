using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 베지어 곡선 그리기
public class JH_Bezier : MonoBehaviour
{
    public Transform p1;
    public Transform p2;
    public Transform p3;
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    float currentTime;
    float flyingSpeed = 10f;
    void Update()
    {
        Draw();

        if (isFlying)
        {
            currentTime += Time.deltaTime;
            player.position = Go(currentTime / flyingSpeed);

            if(Vector3.Distance(player.position, p3.position) < 0.1f)
            {
                isFlying = false;
                player.position = p3.position;
                currentTime = 0;
                player.gameObject.GetComponent<NK_PlayerMove>().enabled = true;
            }
        }
    }
    public List<Vector3> list = new List<Vector3>();
    private void Draw()
    {
        list.Clear();
        for (int i = 0; i < 100; i++)
        {
            Vector3 p = Go(0.01f * i);
            list.Add(p);
        }
        for (int i = 0; i < 99; i++)
        {
            Debug.DrawLine(list[i], list[i + 1], Color.red);
        }
    }


    Vector3 Go(float ratio)
    {
        Vector3 pp1 = Vector3.Lerp(p1.position, p2.position, ratio);
        Vector3 pp2 = Vector3.Lerp(p2.position, p3.position, ratio);
        Vector3 ppp1 = Vector3.Lerp(pp1, pp2, ratio);

        return ppp1;
    }

    bool isFlying = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Player"))
        {
            isFlying = true;
            player.gameObject.GetComponent<NK_PlayerMove>().enabled = false;

            Camera.main.gameObject.GetComponent<JH_Camera>().isVertical = false;
            Camera.main.gameObject.GetComponent<JH_Camera>().isHorizontal = true;
        }
    }
}
