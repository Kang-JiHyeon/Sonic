using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class JH_PathFollower : MonoBehaviour
{
	public float[] speed;
	public List<Transform> pathList;
	//public Transform pathParent;
	public Vector3 offset;
	Transform player;
	Transform targetPoint;
	int childIndex;
	int listIndex;
	public bool isCameraMove = false;

	void OnDrawGizmos()
	{
		Vector3 from;
		Vector3 to;

		for(int i = 0; i< pathList.Count; i++)
        {
			for (int j = 0; j < pathList[i].childCount - 1; j++)
			{
				from = pathList[i].GetChild(j).position;
				to = pathList[i].GetChild((j + 1)).position;
				Gizmos.color = new Color(1, 0, 0);
				Gizmos.DrawLine(from, to);
			}

        }
	}
	void Start()
	{
		player = GameObject.Find("Player").transform;
        offset = new Vector3(0, 5, -10);

        childIndex = 0;
		listIndex = 0;
		targetPoint = pathList[listIndex].GetChild(childIndex);
        speed = new float[pathList.Count];
        speed[0] = 50f;
        speed[1] = 45f;

	}

    // Update is called once per frame
    void LateUpdate()
	{
		if(childIndex >= pathList[listIndex].childCount - 1)
        {
			isCameraMove = false;
			childIndex = 0;
			listIndex++;
			listIndex %= pathList.Count;
			targetPoint = pathList[listIndex].GetChild(childIndex);
		}

		// 커브
        if (isCameraMove)
        {
			transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, speed[listIndex] * Time.deltaTime);
			transform.LookAt(player);

			if (Vector3.Distance(transform.position, targetPoint.position) < 0.1f)
			{
				childIndex++;
                targetPoint = pathList[listIndex].GetChild(childIndex);
			}
        }
		// 직선
        else
        {
			transform.position = Vector3.Lerp(transform.position, player.position, NK_PlayerMove.Instance.speed * Time.deltaTime);
			childIndex = 0;
		}
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("CurveTrigger"))
        {
			isCameraMove = true;
		}
    }
}
