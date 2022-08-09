using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class JH_PathFollower : MonoBehaviour
{

	public float speed = 10f;
	public Transform pathParent;
	public Transform player;
	Transform targetPoint;
	int index;
	bool isCameraMove = false;

	void OnDrawGizmos()
	{
		Vector3 from;
		Vector3 to;
		for (int a = 0; a < pathParent.childCount - 1; a++)
		{
			from = pathParent.GetChild(a).position;
			to = pathParent.GetChild((a + 1)).position;
			Gizmos.color = new Color(1, 0, 0);
			Gizmos.DrawLine(from, to);
		}
	}
	void Start()
	{
		index = 0;
		targetPoint = pathParent.GetChild(index);
	}

	// Update is called once per frame
	void Update()
	{
		if(index >= pathParent.childCount -1)
        {
			isCameraMove = false;
			index = 0;
        }

        if (isCameraMove)
        {
			transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, speed * Time.deltaTime);
			transform.LookAt(player);

			if (Vector3.Distance(transform.position, targetPoint.position) < 0.1f)
			{
				index++;
                //index %= pathParent.childCount;
                targetPoint = pathParent.GetChild(index);
			}
        }
        else
        {
			transform.position = Vector3.Lerp(transform.position, player.position, speed * Time.deltaTime);
        }
	}
    private void OnTriggerEnter(Collider other)
    {
		print("tigger : " + other.name);
        if (other.gameObject.name.Contains("CurveTrigger"))
        {
			print("tigger??? : " + other.name);
			isCameraMove = true;
		}
    }
}
