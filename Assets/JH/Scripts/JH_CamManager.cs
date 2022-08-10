using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// curvePos �±׸� ���� ������Ʈ�� 
public class JH_CamManager : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset;
    Vector3 dir;
    float dirX, dirY;
    float spinSpeed = 2f;
    // Start is called before the first frame update
    public static JH_CamManager Instance;
    Vector3 groundAxis;
    Vector3 rayPos;

    //public Transform curvePos;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        //rayPos = transform.position + new Vector3(0, 1, 0);
        offset = new Vector3(0, 5, -9);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + offset;
        //transform.rotation = Quaternion.Euler(NK_PlayerMove.Instance.dir.y, NK_PlayerMove.Instance.dir.x, 0);
        //transform.LookAt(player.transform);
        //Ray();
    }

    private void Ray()
    {
        // Ray �ʿ�
        // ���� ��ġ, �ü� ����
        // ī�޶󿡼� �÷��̾� ��ġ�� ���̸� ���.
        Ray ray = new Ray(rayPos, player.transform.position);

        // RaycastHit
        RaycastHit hitInfo;

        // Ray�� ������.
        // ���� �浹�ߴٸ�
        if (Physics.Raycast(ray, out hitInfo, 1000))
        {
            // �ε��� ������ Trasform ������ �˰� �ʹ�.
            groundAxis = hitInfo.transform.InverseTransformPoint(hitInfo.transform.position);
            //groundAxis = hitInfo.transform.transform.position;
            print(groundAxis);

            transform.forward = groundAxis;
        }
    }
}

// Ŀ�� Ʈ���� �ߵ� -> CamManager ȸ��
