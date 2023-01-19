using System.Collections.Generic;
using UnityEngine;

public class JH_Bezier : MonoBehaviour
{
    // ������ ��� Control Points
    public List<Vector3> cPoints = new List<Vector3>();

    // ������ ��� �̷�� ��ǥ ����Ʈ 
    public List<Vector3> points = new List<Vector3>();

    void Start()
    {
        cPoints.Add(transform.position);
        for(int i=0; i<transform.childCount; i++)
        {
            cPoints.Add(transform.GetChild(i).position);
        }
    }

    void Update()
    {
        DrawCurve();
    }

    // ������ � �׸��� �Լ�
    private void DrawCurve()
    {
        points.Clear();

        for (int i = 0; i < 100; i++)
        {
            Vector3 p = GetPoint(0.01f * i);
            points.Add(p);
        }

        for (int i = 0; i < 99; i++)
        {
            Debug.DrawLine(points[i], points[i + 1], Color.red);
        }
    }

    // ������ ��� �̷�� ���� ��ǥ�� ��� �Լ�
    public Vector3 GetPoint(float ratio)
    {
        Vector3 q0 = Vector3.Lerp(cPoints[0], cPoints[1], ratio);
        Vector3 q1 = Vector3.Lerp(cPoints[1], cPoints[2], ratio);
        Vector3 b = Vector3.Lerp(q0, q1, ratio);

        return b;
    }
}


