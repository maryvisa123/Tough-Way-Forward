using UnityEngine;

// 武器控制 负责控制武器的方向 武器跟随角色 武器发射子弹
public class WeaponControl : MonoBehaviour
{
    public GameObject BulletPrefab; // 子弹预制体
    public Transform ShootTr; // 子弹发射位置
    
    private Rigidbody2D _rigidbody2D;
    private Collider2D _collider2D;

    [SerializeField]
    private Transform FollowTargetTr; // 跟随的目标
        
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _collider2D = GetComponent<Collider2D>();
    }

    private void Update()
    {
        if (!FollowTargetTr)
        {
            return;
        }
        
        // 攻击
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(BulletPrefab, ShootTr.position, transform.rotation);
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!FollowTargetTr)
        {
            return;
        }

        transform.position = FollowTargetTr.position;
        
        Vector3 mousePos = Input.mousePosition;

        // 将鼠标的屏幕坐标转换为世界坐标
        Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, transform.position.z - Camera.main.transform.position.z));
        // 让物体朝向鼠标的位置
        transform.up = worldMousePos - transform.position;
    
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.CompareTag("Player"))
        {
            FollowTargetTr = col.transform;
            
            Destroy(_collider2D);
            Destroy(_rigidbody2D);
        }
    }
}
