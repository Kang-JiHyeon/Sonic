using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class JH_PathFollower : MonoBehaviour
{

	public float[] speed;
	public List<Transform> pathList;
	//public Transform pathParent;
	public Transform player;
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
		childIndex = 0;
		listIndex = 0;
		targetPoint = pathList[listIndex].GetChild(childIndex);
		speed = new float[pathList.Count];
		speed[0] = 30f;
		speed[1] = 30f;


	}

	// Update is called once per frame
	void Update()
	{
		if(childIndex >= pathList[listIndex].childCount - 1)
        {
			isCameraMove = false;
			childIndex = 0;
			listIndex++;
			listIndex %= pathList.Count;
			targetPoint = pathList[listIndex].GetChild(childIndex);
		}

		// Ŀ��
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
		// ����
        else
        {
			transform.position = Vector3.Lerp(transform.position, player.position, speed[listIndex] * Time.deltaTime);
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
