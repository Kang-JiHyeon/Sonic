using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 베지어 곡선 그리기
public class JH_Bezier : MonoBehaviour
{
    public Transform start;
    public Transform handle;
    public Transform end;
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = NK_PlayerMove.Instance.gameObject.transform;
    }

    // Update is called once per frame
    float currentTime;
    float flyingSpeed = 3f;
    void Update()
    {
        Draw();

        if (isFlying)
        {
            currentTime += Time.deltaTime;
            player.position = Go(currentTime / flyingSpeed);

            if(Vector3.Distance(player.position, end.position) < 0.5f)
            {
                isFlying = false;
                player.position = end.position;
                currentTime = 0;
                NK_PlayerMove.Instance.enabled = true;
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
        Vector3 pp1 = Vector3.Lerp(start.position, handle.position, ratio);
        Vector3 pp2 = Vector3.Lerp(handle.position, end.position, ratio);
        Vector3 ppp1 = Vector3.Lerp(pp1, pp2, ratio);

        return ppp1;
    }

    bool isFlying = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Player"))
        {
            isFlying = true;
            NK_PlayerMove.Instance.enabled = false;

            Camera.main.gameObject.GetComponent<JH_Camera>().isVertical = false;
            Camera.main.gameObject.GetComponent<JH_Camera>().isHorizontal = true;
            Camera.main.gameObject.GetComponent<JH_Camera>().isCamMove = true;

        }
    }
}
