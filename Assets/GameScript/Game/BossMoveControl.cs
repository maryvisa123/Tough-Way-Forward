using UnityEngine;

//Boss Movement and Attack Control
public class BossMoveControl : MonoBehaviour
{
    public Transform[] MoveTargets; 
    public Vector2 MoveIntervalTime; 
    public Vector2 AttackIntervalTime; 
    public float MoveSpeed; 
    public GameObject BulletPrefab; 
    public Transform shootTr; 
    
    private int moveTargetIndex; 
    private float IntervalTime;
    private float attackIntervalTime; 
    private Player _player; 
    
    // Start is called before the first frame update
    void Start()
    {
        IntervalTime = Random.Range(MoveIntervalTime.x, MoveIntervalTime.y);
        attackIntervalTime = Random.Range(AttackIntervalTime.x, AttackIntervalTime.y);
        _player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IntervalTime <= 0) 
        {
            Vector3 targetPos = MoveTargets[moveTargetIndex].position;
            Vector3 direction = targetPos - transform.position;
            Vector3 moveDis = MoveSpeed * Time.deltaTime * direction.normalized;
            if (direction.magnitude < 0.05f || moveDis.magnitude >= direction.magnitude)
            {
                transform.position = targetPos;
                moveTargetIndex = Random.Range(0, MoveTargets.Length);
                IntervalTime = Random.Range(MoveIntervalTime.x, MoveIntervalTime.y);
            }
            else
            {
                transform.position += moveDis;
            }
        }else
        {
            IntervalTime -= Time.deltaTime;
        }

        Attack();
    }

  
    private void Attack()
    {
        if (attackIntervalTime <= 0)
        {
            attackIntervalTime = Random.Range(AttackIntervalTime.x, AttackIntervalTime.y);

            GameObject bullet = Instantiate(BulletPrefab);
            bullet.transform.position = shootTr.position;
            bullet.transform.up = _player.transform.position - shootTr.position;
        }else
        {
            attackIntervalTime -= Time.deltaTime;
        }
    }
}
