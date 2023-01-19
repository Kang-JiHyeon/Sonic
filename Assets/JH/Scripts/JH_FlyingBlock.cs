using UnityEngine;

public class JH_FlyingBlock : MonoBehaviour
{
    public Transform player;
    public JH_Bezier bezier;
    public bool isFlying = false;
    float flyingSpeed = 0.3f;
    float currentTime = 0f;

    public static JH_FlyingBlock Instance;

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        player = NK_PlayerMove.Instance.gameObject.transform;
        bezier = transform.GetComponent<JH_Bezier>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isFlying)
            Fly();
    }

    void Fly()
    {
        currentTime += Time.deltaTime;
        player.position = bezier.GetPoint(currentTime * flyingSpeed);

        if (Vector3.Distance(player.position, bezier.cPoints[2]) < 0.5f)
        {
            currentTime = 0;
            player.position = bezier.cPoints[2];
            isFlying = false;
            NK_PlayerMove.Instance.enabled = true;
            NK_PathFollower.Instance.enabled = true;
            Camera.main.gameObject.GetComponent<JH_Camera>().isCamMove = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        bool isHor;

        if (other.gameObject.name.Contains("Player"))
        {
            isFlying = true;
            NK_PlayerMove.Instance.enabled = false;
            NK_PathFollower.Instance.enabled = false;


            if (gameObject.name.Contains("FlyingBlock_H"))
            {
                isHor = true;
            }
            else
            {
                isHor = false;
            }

            Camera.main.gameObject.GetComponent<JH_Camera>().isHorizontal = isHor;
            Camera.main.gameObject.GetComponent<JH_Camera>().isCamMove = true;

            //사운드 재생
            if (gameObject.name.Contains("Ring"))
                JH_SoundManager.Instance.PlaySound("FlyingRing");
            else
                JH_SoundManager.Instance.PlaySound("FlyingBlock");
        }
    }
}
